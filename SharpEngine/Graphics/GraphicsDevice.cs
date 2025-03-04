
using SFML.Graphics;
using SFML.Window;
using SharpEngine.Content;
using SharpEngine.Helpers;

namespace SharpEngine.Graphics;
public class GraphicsDevice
{
    /// <summary>
    /// Gets the window this <see cref="GraphicsDevice"/> is attached to.
    /// </summary>
    public SharpWindow Window
    {
        get;
    }
    
    /// <summary>
    /// Initalize a new instance of <see cref="GraphicsDevice"/>
    /// </summary>
    /// <param name="window"></param>
    public GraphicsDevice(SharpWindow window)
    {
        NullHelper.IsNullThrow(window, nameof(window));

        Window = window;
    }

    /// <summary>
    /// Gets the current view port space.
    /// </summary>
    public Viewport Viewport 
    {
        get 
        {
             var view = window.renderWindow.GetViewport(window.renderWindow.GetView());
             return new Viewport(view.Left, view.Top, view.Width, view.Height);
        }
    }

    /// <summary>
    /// Draws a <see cref="Drawable"/> to the screen.
    /// </summary>
    public void Draw(Drawable drawable, BlendMode blendMode, Effect effect) 
    {
        window.renderWindow.Draw(drawable, new RenderStates(blendMode, Transform.Identity, null, SFMLHelper.SFMLShader(effect)));
    }

    /// <summary>
    /// Draws a <see cref="Drawable"/> to the screen.
    /// </summary>
    public void Draw(Drawable drawable, BlendMode blendMode) 
    {
        window.renderWindow.Draw(drawable, new RenderStates(blendMode));
    }

    /// <summary>
    /// Draws a <see cref="Drawable"/> to the screen.
    /// </summary>
    public void Draw(Drawable drawable, Effect effect)
    {
        window.renderWindow.Draw(drawable, new RenderStates(BlendMode.None, Transform.Identity, null, SFMLHelper.SFMLShader(effect)));
    }

    /// <summary>
    /// Draws a <see cref="Drawable"/> to the screen.
    /// </summary>
    public void Draw(Drawable drawable) 
    {
        window.renderWindow.Draw(drawable);
    }

    /// <summary>
    /// Clears the color.
    /// </summary>
    /// <param name="color"></param>
    public void Clear(Color color) 
    {
        window.renderWindow.Clear(SFMLHelper.SFMLColor(color));
    }
}
