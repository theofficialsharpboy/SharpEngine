
using SharpEngine.Graphics;
using SharpEngine.Input;

namespace SharpEngine.Scene;

#nullable disable
public class SceneSystem : DrawableComponent
{
    readonly List<Scene> tempScenes = new ();
    readonly List<Scene> scenes     = new ();
    
    private SpriteBatch spriteBatch;
    private InputSystem inputSystem;
    private bool initialized = false;

    /// <summary>
    /// Gets the <see cref="InputSystem"/>
    /// </summary>
    public InputSystem Input => inputSystem;

    /// <summary>
    /// Gets the <see cref="SpriteBatch"/>
    /// </summary>
    public SpriteBatch SpriteBatch => spriteBatch;

    /// <summary>
    /// Initialize a new instance of <see cref="SceneSystem"/>
    /// </summary>
    /// <param name="window"></param>
    public SceneSystem(SharpWindow window) : base(window)
    {
        initialized = false;
        inputSystem = new ();
    }

    public override void Activate()
    {
        base.Activate();

        spriteBatch = new (Window.GraphicsDevice);

        if(!initialized)
        {
            foreach(var scene in scenes)
            {
                scene.Activate();
            }

            initialized = true;
        }
    }

    public override void Update(Time time)
    {
        base.Update(time);

        inputSystem.Update();

        tempScenes.Clear();

        foreach(var scene in scenes) tempScenes.Add(scene);

        bool otherScreenHasFocus = !Window.renderWindow.IsOpen;
        bool coveredByOtherScreen = false;

        while(tempScenes.Count > 0)
        {
            var scene = tempScenes[tempScenes.Count -1];
            tempScenes.RemoveAt(tempScenes.Count -1);
            scene.Update(time, otherScreenHasFocus, coveredByOtherScreen);

            if(scene.State == SceneState.TransitionOn || scene.State == SceneState.Active)
            {
                if(!otherScreenHasFocus) 
                {
                    scene.HandleInput(inputSystem);
                    otherScreenHasFocus = true;
                }

                if(!scene.IsPopup) coveredByOtherScreen = true;
            }
        }
    }

    /// <summary>
    /// Adds a scene.
    /// </summary>
    /// <param name="scene"></param>
    public void Add(Scene scene) 
    {
        scene.SceneSystem = this;
        scene.Exiting = false;

        if(initialized) scene.Activate();
        
        scenes.Add(scene);
    }

    /// <summary>
    /// Removes a scene.
    /// </summary>
    /// <param name="scene"></param>
    public void RemoveScene(Scene scene) 
    {
        scenes.Remove(scene);
        tempScenes.Remove(scene);
    }

    public override void Draw(Time time)
    {
        base.Draw(time);

        foreach(var scene in scenes)
        {
            if(scene.State == SceneState.Hidden) continue;

            scene.Draw(time, spriteBatch);
        }
    }
}
