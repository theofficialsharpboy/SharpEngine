
#nullable disable

using System.Diagnostics;
using SFML.Graphics;
using SFML.System;
using SharpEngine.Content;
using SharpEngine.Graphics;
using SharpEngine.Helpers;
using SharpEngine.Scene;
using SharpEngine.Sprites;

namespace SharpEngine;

public record class SharpWindowEventArgs(SharpWindow window);
public delegate void SharpWindowEventHandler<T>(T e);
public delegate void SharpWindowEventHandler();

public class SharpWindow
{
    #region fields
    internal RenderWindow renderWindow = null;
    GraphicsDeviceManager graphicsDeviceManager;
    ContentManager contentManager;
    List<DrawableComponent> components;
    const int target = 60;
    float timeTillNextFrame = 1f / target;
    bool mouseVisable = false;
    Stopwatch _gameTimer;
    bool _initalized = false;
    Time time;
    SceneSystem _sceneSystem;
    internal static SharpWindow Instance;
    List<SpriteSheet> spriteSheets;
    List<double> frameRates = new List<double>(); 
    int _frameCount = 0;
    double _enlapsedTime = 0;
    double _fps;
    double _fpsLatency;
    SharpWindowFrameInfo frameInfo;
    GraphicsDevice graphicsDevice;
    #endregion

    #region properties

    /// <summary>
    /// Gets the graphics device.
    /// </summary>
    public GraphicsDevice GraphicsDevice 
    {
        get => graphicsDevice;
    }

    /// <summary>
    /// Gets the frame buffer info (i.e, FPS, Latency, etc).
    /// </summary>
    public SharpWindowFrameInfo FrameBufferInfo => frameInfo;

    /// <summary>
    /// Gets the <see cref="DrawableComponent"/>s
    /// </summary>
    public List<DrawableComponent> Component => components;

    /// <summary>
    /// Gets the graphics device manager.
    /// </summary>
    public GraphicsDeviceManager GraphicsDeviceManager => graphicsDeviceManager;

    /// <summary>
    /// Gets the content manager.
    /// </summary>
    public ContentManager ContentManager => contentManager;

    /// <summary>
    /// Gets or sets whether to display the mouse cursor.
    /// </summary>
    public bool IsMouseVisable 
    {
        get => mouseVisable;
        set 
        {
            mouseVisable = value;
            renderWindow.SetMouseCursorVisible(value);
        }
    }

    /// <summary>
    /// Gets or sets the window title.
    /// </summary>
    public string Title 
    {
        get;
        set;
    }


    /// <summary>
    /// Gets a bool value indecating whether this <see cref="SharpWindow"/> is focused.
    /// </summary>
    public bool IsFocused 
    {
        get;
        private set;
    }

    /// <summary>
    /// Gets or sets a bool value indecating whether to draw when focused.
    /// </summary>
    /// <remarks>True; will call Draw() events when focused only; other false.
    public bool DrawWhenFocused 
    {
        get;
        set;
    } = true;

    /// <summary>
    /// Gets or sets whether this <see cref="SharpWindow"/> is running at a fixed time span.
    /// </summary>
    public bool IsFixedTimeSpan 
    {
        get;
        set;
    } = false;

    /// <summary>
    /// Gets a bool value indecating whether this window is active.
    /// </summary>
    public bool IsActive 
    {
        get 
        {
            bool active = false;

            if(!NullHelper.IsNull(renderWindow))
            {
                 active = renderWindow.IsOpen && IsFocused;
            }
            
            return active;
        }
    }

    /// <summary>
    /// Gets the collection of <see cref="SpriteSheet"/>s
    /// </summary>
    public List<SpriteSheet> SpriteSheets => spriteSheets;

    /// <summary>
    /// Gets the scene system.
    /// </summary>
    public SceneSystem SceneSystem => _sceneSystem;
    #endregion

    #region events

    /// <summary>
    /// Raised before <see cref="SharpWindow.Run"/> is called.
    /// </summary>
    public event SharpWindowEventHandler<SharpWindowEventArgs> BeforeRun;

    /// <summary>
    /// Raised when lost focus.
    /// </summary>
    public event SharpWindowEventHandler<SharpWindowEventArgs> LostFocus;

    /// <summary>
    /// Raised when gained focus.
    /// </summary>
    public event SharpWindowEventHandler<SharpWindowEventArgs> Focused;

    /// <summary>
    /// Raised when closed.
    /// </summary>
    public event SharpWindowEventHandler Closed;
    #endregion

    #region constructors

    public SharpWindow()
    {
       graphicsDeviceManager = new (this);
       contentManager = new (this);
       components = new ();
       _gameTimer = new ();
       spriteSheets = new ();
       graphicsDevice = new (this);
    }
    
    #endregion

    #region private method
    void _doRun() 
    {
        SharpWindowEventArgs eventArgs = new SharpWindowEventArgs(this);
        renderWindow.Closed += (s, e)=> {
            foreach(var component in components)
            {
                component.Deactivate();
            }

            if(renderWindow.IsOpen)
            {
                renderWindow.Close();
            }
            
            Closed?.Invoke();
        };

        renderWindow.LostFocus += (s, e)=> 
        {
            LostFocus?.Invoke(eventArgs);
            IsFocused = false;
        };

        renderWindow.GainedFocus += (s, e) =>
        {
            Focused?.Invoke(eventArgs);
            IsFocused = true;
        };


        _gameTimer.Reset();
        _gameTimer.Start();

        Clock _sfmlClock = new ();
        frameInfo = new ();

        SFML.System.Time deltaTime = new ();
        float totalSeconds = 0f;
        float fixedTime = 0;

        float timeScale = 1f;
        do 
        {
            renderWindow.DispatchEvents();

         
            if(IsFixedTimeSpan)
            {
                if(fixedTime >= timeTillNextFrame)
                {
                    if(DrawWhenFocused) 
                    {
                        if(IsFocused) 
                        {
                            Update(time);
                            fixedTime = 0;
                            Draw(time);
                        }
                    }
                    else 
                    {
                        Update(time);
                        fixedTime = 0;
                        Draw(time);
                    }
                }
            } 
            else 
            {
                if(DrawWhenFocused) 
                {
                    if(IsFocused) 
                    {
                        Update(time);
                        Draw(time);
                    }
                }
                else 
                {
                    Update(time);
                    Draw(time);
                }
            }
            
            time.Delta = deltaTime.AsSeconds();
            time.Scale = timeScale;
            time.Enlapsed = TimeSpan.FromSeconds(deltaTime.AsSeconds());
            time.Total = TimeSpan.FromSeconds(totalSeconds);

            deltaTime = _sfmlClock.Restart();
            deltaTime *= timeScale;
            totalSeconds += deltaTime.AsSeconds();
            fixedTime += deltaTime.AsMilliseconds();

            #region frame buffer info
            try 
            {
                _enlapsedTime += time.Enlapsed.TotalSeconds;
                _frameCount++;
                if(_enlapsedTime >= 0.2f)
                {
                    _fps = _frameCount / _enlapsedTime;
                    _fpsLatency = (1000.0f / _fps);
                    _frameCount = 0;
                    _enlapsedTime = 0;
                }

                frameInfo.UpdateFrames(_fps, _frameCount);
            }
            catch {}

            Collect();
            #endregion

        } while(renderWindow.IsOpen);
    }

    #endregion

    #region public methods

    /// <summary>
    /// Collects the garbish memory.
    /// </summary>
    /// <remarks> Used to clear garbish memory bytes. (If not done properly, Fonts will throw erorrs).
    protected virtual void Collect() 
    {
        GC.Collect();
    }

    protected virtual void Activate() 
    {
        _sceneSystem = new (this);
        components.Add(_sceneSystem);
        
        foreach(var drawable in components)
        {
            drawable.Activate();
        }
    }
    protected virtual void Draw(Time time)
    {
        foreach(var drawable in components)
        {
            drawable.Draw(time);
        }

        foreach(var sheet in spriteSheets) 
        {
            sheet.Draw(time);
        }

        renderWindow.Display();
    }
    protected virtual void Update(Time time)
    {
        foreach(var drawable in components)
        {
            drawable.Update(time);
        }      
    }

    /// <summary>
    /// Initialize this window.
    /// </summary>
    protected virtual void Initialize() 
    {
    }

    /// <summary>
    /// Run this window.
    /// </summary>
    public void Run() 
    {
        Initialize();

        BeforeRun?.Invoke(new (this));
        time = new Time();

        if(!_initalized)
        {
            (bool value, RenderWindow window) = graphicsDeviceManager._createFromWindow(Title);

            if(value) this.renderWindow = window;
            else throw new Exception("Unable to create graphics device manager.");

            _gameTimer.Start();

            Activate();

            Instance = this;

            _initalized = true;
        }

        _doRun();
    }

    /// <summary>
    /// Sets the window icon.
    /// </summary>
    /// <param name="image"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public void SetIcon(Image image) 
    {
        if(renderWindow == null) throw new ArgumentNullException(nameof(image));
        renderWindow.SetIcon((uint)image.Size.X, (uint)image.Size.Y, image.Pixels);
    }
    
    #endregion
}
