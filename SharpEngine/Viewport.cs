

using SharpEngine.Helpers;

namespace SharpEngine;

public class Viewport
{
    /// <summary>
    /// Gets the x position.
    /// </summary>
    public int X {get;}

    /// <summary>
    /// Gets the y position.
    /// </summary>
    public int Y {get;}

    /// <summary>
    /// Gets the width.
    /// </summary>
    public int Width {get;}

    /// <summary>
    /// Gets the height.
    /// </summary>
    public int Height {get;}

    /// <summary>
    /// Initialize a new instance of <see cref="Viewport"/>
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="width"></param>
    /// <param name="height"></param>
    public Viewport(int x, int y, int width, int height)
    {
        NullHelper.IsNullThrow(x, nameof(x));
        NullHelper.IsNullThrow(y, nameof(y));
        NullHelper.IsNullThrow(width, nameof(width));
        NullHelper.IsNullThrow(height, nameof(height));

        X = x;
        Y = y;
        Width = width;
        Height = height;
    }
}
