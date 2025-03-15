using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SFML.Graphics;
using SharpEngine.Content;
using SharpEngine.Controls.EventArgs;
using SharpEngine.Controls.Exceptions;
using SharpEngine.Extensions;
using SharpEngine.Graphics;
using SharpEngine.Helpers;
using SharpEngine.Input;
using SharpEngine.Input.Devices;
using SharpEngine.Input.States.Keyboard;
using SharpEngine.Input.States.Mouse;

namespace SharpEngine.Controls;


#nullable disable

public abstract class Control
{
    #region fields and events

    /// <summary>
    /// Raised when mouse has moved.
    /// </summary>
    public event ControlEventHandler<MouseEventArgs> MouseMoved;

    /// <summary>
    /// Raised when mouse is hovering.
    /// </summary>
    public event ControlEventHandler MouseHover;

    /// <summary>
    /// Raised when mouse has left this bounds.
    /// </summary>
    public event ControlEventHandler MouseLeave;

    /// <summary>
    /// Raised when mouse has left clicked.
    /// </summary>
    public event ControlEventHandler MouseClick;

    /// <summary>
    /// Raised when a key has been pressed.
    /// </summary>
    public event ControlEventHandler<KeyEventArgs> KeyDown;

    /// <summary>
    /// Raised when clicked.
    /// </summary>
    public event ControlEventHandler<object, System.EventArgs> Click;

    /// <summary>
    /// Raised when gained focus.
    /// </summary>
    public event ControlEventHandler Focused;

    /// <summary>
    /// Raised when lost focus.
    /// </summary>
    public event ControlEventHandler LostFocus;

    /// <summary>
    /// Raised when a key is up.
    /// </summary>
    public event ControlEventHandler<KeyEventArgs> KeyUp;

    #endregion

    #region properties

    /// <summary>
    /// Gets the text.
    /// </summary>
    public string Text 
    {
        get;
        set;
    }

    /// <summary>
    /// Gets the font.
    /// </summary>
    public SpriteFont Font 
    {
        get;
        set;
    }

    /// <summary>
    /// Gets or sets the background color.
    /// </summary>
    public Color Background 
    {
        get;
        set;
    } = Color.Black;

    /// <summary>
    /// Gets the size.
    /// </summary>
    public Size Size 
    {
        get
        {
            Size size = new (0, 0);
            if(!string.IsNullOrWhiteSpace(Text)) 
            {
                if(Font != null)
                {
                    Size s = null;
                    var fontSize = Font.Measure(Text);
                    var fontSpacing = Font.LineSpacing(Text);

                    s = new (fontSize.Width - (int)fontSpacing, fontSize.Height - (int)fontSpacing);

                    return s;
                }
            }

            return size;
        }
        set{}
    }

    /// <summary>
    /// Gets the position.
    /// </summary>
    public Vector2 Position 
    {
        get;
        set;
    }

    /// <summary>
    /// Gets the parent scene.
    /// </summary>
    public Scene.Scene Parent
    {
        get;
        internal set;
    }

    /// <summary>
    /// Gets the default color of the text.
    /// </summary>
    public Color Foreground 
    {
        get;
        set;
    }

    /// <summary>
    /// Gets or sets weather this <see cref="Control"/> has focus.
    /// </summary>
    public bool IsFocused 
    {
        get;
        private set;
    }

    /// <summary>
    /// Gets the bounds of this control.
    /// </summary>
    public Rectangle Bounds => new ((int)Position.X, (int)Position.Y, Size.Width, Size.Height);
    #endregion

    #region constructors

    #endregion

    #region internal voids

    #endregion
    #region public voids
    internal void HandleInput(InputSystem inputSystem) => OnHandleInput(inputSystem);
    internal void Draw(Time time, SpriteBatch spriteBatch) =>  OnDraw(time, spriteBatch);
    internal void Update(Time time) => OnUpdate(time);
    #endregion

    #region protected voids
    protected virtual void OnKeyDown(Keys key) => KeyDown?.Invoke(new (key));
    protected virtual void OnMouseMove(Point position) => MouseMoved?.Invoke(new (position));
    protected virtual void OnMouseHover() => MouseHover?.Invoke();
    protected virtual void OnMouseLeave() => MouseLeave?.Invoke();
    protected virtual void OnClick() => Click?.Invoke(this, new System.EventArgs());
    protected virtual void OnMouseClick() => MouseClick?.Invoke();
    protected virtual void OnDraw(Time time, SpriteBatch spritebatch)
    {
        spritebatch.Begin();
        var rectangle = spritebatch.CreateRectangle((Size.Width + 10), (Size.Height +10), Color.White);
        var position = new Vector2(
            (Position.X + (int)rectangle.Size.X /2 - Size.Width /2) -5,
            Position.Y + (int)rectangle.Size.Y /2 - Size.Height /2
        );
        spritebatch.Draw(rectangle, position, Background);
        spritebatch.End();
    }
    protected virtual void OnUpdate(Time time) {}
    protected virtual void OnFocused() => Focused?.Invoke();
    protected virtual void OnLostFocus() => LostFocus?.Invoke();
    protected virtual void OnKeyUp(Keys key) => KeyUp?.Invoke(new (key));

    protected virtual void OnHandleInput(InputSystem inputSystem) 
    {
        if(inputSystem == null) return;

        var mouse = inputSystem?.FindFromType<Mouse>();
        var keyboard = inputSystem?.FindFromType<Keyboard>();
        
        if(mouse == null) return;
        if(keyboard == null) return;
        
        var mouseBounds = new Rectangle((int)mouse.Position.X, (int)mouse.Position.Y, 1, 1);
    
        if(mouseBounds.InteractWith(Bounds))
        {
            OnMouseHover();

            if(mouse.IsButtonDown(MouseButton.Left)) 
            {
                OnClick();
                OnMouseClick();
                OnFocused();
                
                IsFocused = false;
            }

            OnMouseMove(new ((int)mouse.Position.X, (int)mouse.Position.Y));
        }
        else
        {
            OnMouseLeave();
            OnLostFocus();
            
            IsFocused = false;
        }

        List<string> keysList = new (EnumHelper.GetNames<Keys>());
        keysList.RemoveAt(keysList.Count -1);

        foreach(var key in keysList)
        {
            var k = EnumHelper.Parse<Keys>(key);

            if(keyboard.IsNewKeyDown(k))
            {
                OnKeyDown(k);
            }
            
            if(keyboard.IsKeyUp(k))
            {
                OnKeyUp(k);
            }
        }
    }
    #endregion
}
