using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SharpEngine.Controls;
using SharpEngine.Graphics;
using SharpEngine.Input;

namespace SharpEngine.Scene;
#nullable disable

public abstract class Scene
{
    List<Control> controls;

    /// <summary>
    /// Gets a bool value indecating whether this <see cref="Scene"/> is a popup.
    /// </summary>
    public bool IsPopup 
    {
        get;
        protected set;
    }

    /// <summary>
    /// Gets the <see cref="Scene"/> state.
    /// </summary>
    public SceneState State 
    {
        get;
        private set;
    } = SceneState.TransitionOn;

    /// <summary>
    /// Gets the transitioning on time.
    /// </summary>
    public TimeSpan TransitionOnTime 
    {
        get;
        protected set;
    } = TimeSpan.Zero;

    /// <summary>
    /// Gets the transitioning off time.
    /// </summary>
    public TimeSpan TransitionOffTime 
    {
        get;
        protected set;
    } = TimeSpan.Zero;

    /// <summary>
    /// Gets the transition position.
    /// </summary>
    public float TransitionPosition 
    {
        get;
        protected set;
    }

    /// <summary>
    /// Gets the transition alpha color.
    /// </summary>
    public float TransitionAlpha => 1f - TransitionPosition;

    /// <summary>
    /// Gets the scene System.
    /// </summary>
    public SceneSystem SceneSystem
    {
        get;
        internal set;
    }

    /// <summary>
    /// Gets the scene name.
    /// </summary>
    public string Name
    {
        get;
    }

    /// <summary>
    /// Gets a bool value indecating whether this <see cref="Scene"/> is exiting.
    /// </summary>
    public bool Exiting 
    {
        get;
        internal set;
    }

    /// <summary>
    /// Initailize a new instance of <see cref="Scene"/>
    /// </summary>
    /// <param name="name"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public Scene(string name) 
    {
        if(string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));

        this.Name = name;
        this.controls = new ();
    }

    /// <summary>
    /// Update this scene.
    /// </summary>
    /// <param name="time"></param>
    /// <param name="otherScreenHasFocus"></param>
    /// <param name="coveredByScreen"></param>
    public virtual void Update(Time time, bool otherScreenHasFocus, bool coveredByScreen)
    {
        if(Exiting)
        {
            State = SceneState.TransitionOff;

            if(!UpdateTimeTransition(time, TransitionOffTime, 1)) 
            {
                SceneSystem.RemoveScene(this);
            }
        }
        else if(coveredByScreen)
        {
            State = UpdateTimeTransition(time, TransitionOffTime, 1) ? SceneState.TransitionOff : SceneState.Active;
        }
        else
        {
            State = UpdateTimeTransition(time, TransitionOnTime, -1) ? SceneState.TransitionOn : SceneState.Active;
        }

        foreach(var control in controls) control.Update(time);
    }

    /// <summary>
    /// Handle this scenes input.
    /// </summary>
    /// <param name="inputSystem"></param>
    public virtual void HandleInput(InputSystem inputSystem)
    {
        foreach(var control in controls) control.HandleInput(inputSystem);
    }

    /// <summary>
    /// Draw this scene.
    /// </summary>
    /// <param name="time"></param>
    public virtual void Draw(Time time, SpriteBatch spriteBatch)
    {
        foreach(var control in controls) control.Draw(time, spriteBatch);
    }

    /// <summary>
    /// Load all cotent of this scene.
    /// </summary>
    public abstract void Activate();

    private bool UpdateTimeTransition(Time time, TimeSpan timeSpan, int direction)
    {
        float transitionDelta;

        if(timeSpan == TimeSpan.Zero) transitionDelta = 1;
        else transitionDelta = (float)(time.Enlapsed.TotalMilliseconds / timeSpan.TotalMilliseconds);

        TransitionPosition += transitionDelta * direction;

        if(direction < 0 && TransitionPosition <= 0 || direction > 0 || TransitionPosition >= 1)
        {
            TransitionPosition = Math.Clamp(TransitionPosition, 0, 1);
            return false;
        }

        return true;
    }

    /// <summary>
    /// Exit this <see cref="Scene"/>
    /// </summary>
    public void Exit() 
    {
        if(TransitionOffTime == TimeSpan.Zero) SceneSystem.RemoveScene(this);
        else Exiting = true;
    }

    /// <summary>
    /// Adds a control.
    /// </summary>
    /// <param name="control"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public void AddControl(Control control) 
    {
        if(control == null) throw new ArgumentNullException(nameof(control));

        controls.Add(control);
    }

    /// <summary>
    /// Removes this control.
    /// </summary>
    /// <param name="control"></param>
    public void RemoveControl(Control control)
    {
        controls.Remove(control);
    }
}
