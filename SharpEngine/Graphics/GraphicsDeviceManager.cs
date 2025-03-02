
using SFML.Graphics;
using SFML.Window;
using SharpEngine.Helpers;

namespace SharpEngine.Graphics;

public class GraphicsDeviceManager
{
    SharpWindow _renderWindow;
    GraphicsContext? currentContext;
    ContextSettings _currentSettings;
    
    /// <summary>
    /// Gets the current view port space.
    /// </summary>
    public Viewport Viewport 
    {
        get 
        {
             var view = _renderWindow.renderWindow.GetViewport(_renderWindow.renderWindow.GetView());

             return new Viewport(view.Left, view.Top, view.Width, view.Height);
        }
    }


    /// <summary>
    /// Gets the current context.
    /// </summary>
    public GraphicsContext? CurrentContext => currentContext;

    /// <summary>
    /// Initialize a new instance of <see cref="GraphicsDeviceManager"/>
    /// </summary>
    /// <param name="window"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public GraphicsDeviceManager(SharpWindow window) 
    {
        if(window == null) throw new ArgumentNullException(nameof(window));

        this._renderWindow = window;
    }

    /// <summary>
    /// Apply changes to the underlaying renderer.
    /// </summary>
    /// <param name="context"></param>
    public void ApplyChanges(GraphicsContext context) 
    {
        try 
        {
            View view = new (new FloatRect(0, 0, context.Resulotion.Width, context.Resulotion.Height));
            _renderWindow.renderWindow.Size = new ((uint)context.Resulotion.Width, (uint)context.Resulotion.Height);
            _renderWindow.renderWindow.SetView(view);
            _renderWindow.renderWindow.SetFramerateLimit((uint)context.FrameLimit);
            _renderWindow.renderWindow.SetVerticalSyncEnabled(context.Vsync);

            int antialisingLevel = context.Antialising.Mode switch 
            {
                AntialisingMode.MSAA_2 => 2,
                AntialisingMode.MSAA_4 => 4,
                AntialisingMode.MSAA_6 => 6,
                AntialisingMode.MSAA_8 => 8,
                AntialisingMode.None => 0,
                _ => throw new ArgumentOutOfRangeException(nameof(currentContext.Antialising.Mode))
            };

            if(context.Antialising.Enabled) _currentSettings.AntialiasingLevel = (uint)antialisingLevel;

            _currentSettings.DepthBits = (uint)context.DepthBit;
            _currentSettings.StencilBits = (uint)context.StencilBit;

        }
        catch {}

        currentContext = context;
    }

    
#nullable disable

    internal (bool value, RenderWindow window) _createFromWindow(string title, BitsPerPixel bitsPerPixel = BitsPerPixel.Default)
    {
        bool value = false;
        RenderWindow window;
        try 
        {
            if(currentContext == null) 
            {
                currentContext = new GraphicsContext(60, true, false, new (800, 600));
            }


            VideoMode video = new VideoMode(
              (uint)currentContext.Resulotion.Width,
              (uint)currentContext.Resulotion.Height,
              (uint)bitsPerPixel
            );

            Styles style = Styles.None;

            if(currentContext.IsFullScreen) style |= Styles.Fullscreen;
            else if(currentContext.Resizable) {style -= Styles.Fullscreen; style|= Styles.Resize;}
            else {style = Styles.Close;}

            int antialisingLevel = currentContext.Antialising.Mode switch 
            {
                AntialisingMode.MSAA_2 => 2,
                AntialisingMode.MSAA_4 => 4,
                AntialisingMode.MSAA_6 => 6,
                AntialisingMode.MSAA_8 => 8,
                AntialisingMode.None => 0,
                _ => throw new ArgumentOutOfRangeException(nameof(currentContext.Antialising.Mode))
            };

            _currentSettings = new ();

            if(currentContext.Antialising.Enabled)
            {
                _currentSettings.AntialiasingLevel = (uint)antialisingLevel;
            }

            _currentSettings.DepthBits = (uint)currentContext.DepthBit;
            _currentSettings.StencilBits = (uint)currentContext.StencilBit;
            
            window = new RenderWindow(video, title, style, _currentSettings);

            window.SetActive(true);
            window.SetView(
                SFMLHelper.SFMLView(new (
                    0, 0,
                    currentContext.Resulotion.Width,
                    currentContext.Resulotion.Height
                ))
            );
            window.SetFramerateLimit((uint)currentContext.FrameLimit);

            value = true;
            return (value, window);
        }
        catch(Exception)
        {
            throw;
        }
    }
}
