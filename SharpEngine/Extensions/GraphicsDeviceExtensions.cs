using SharpEngine.Helpers;

namespace SharpEngine.Extensions;
public static class GraphicsDeviceExtensions
{
    /// <summary>
    /// Changes the size of the <see cref="SharpWindow"/>
    /// </summary>
    /// <param name="graphics"></param>
    /// <param name="width"></param>
    /// <param name="height"></param>
    public static void SetSize(this Graphics.GraphicsDevice graphics, int width, int height)
    {
        NullHelper.IsNullThrow(width, nameof(width));
        NullHelper.IsNullThrow(height, nameof(height));

        graphics.Window.renderWindow.Size = new SFML.System.Vector2u(
            (uint)width,
            (uint)height
        );
    }

    /// <summary>
    /// Changes the size of the <see cref="SharpWindow"/>
    /// </summary>
    /// <param name="graphics"></param>
    /// <param name="size"></param>
    public static void SetSize(this Graphics.GraphicsDevice graphics, Size size)
    {
        NullHelper.IsNullThrow(size, nameof(size));

        graphics.Window.renderWindow.Size = new SFML.System.Vector2u(
            (uint)size.Width,
            (uint)size.Height
        );
    }

    /// <summary>
    /// Sets the view of the <see cref="SharpWindow"/>
    /// </summary>
    /// <param name="graphics"></param>
    /// <param name="rect"></param>
    public static void SetView(this Graphics.GraphicsDevice graphics, Rectangle rect)
    {
        NullHelper.IsNullThrow(rect, nameof(rect));

        graphics.Window.renderWindow.SetView(SFMLHelper.SFMLView(rect));
    }

    /// <summary>
    /// Enables vsync.
    /// </summary>
    /// <param name="graphics"></param>
    public static void EnableVSyncronization(this Graphics.GraphicsDevice graphics)
    {
        graphics.Window.renderWindow.SetVerticalSyncEnabled(true);
    }

    /// <summary>
    /// Disables vsync.
    /// </summary>
    /// <param name="graphics"></param>
    public static void DisableVSyncronization(this Graphics.GraphicsDevice graphics)
    {
        graphics.Window.renderWindow.SetVerticalSyncEnabled(false);
    }
}
