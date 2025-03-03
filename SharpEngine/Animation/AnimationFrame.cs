using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SharpEngine.Helpers;

namespace SharpEngine.Animation;

public class AnimationFrame
{
    /// <summary>
    /// Gets the frame width.
    /// </summary>
    public int Width 
    {
        get;
    }

    /// <summary>
    /// Gets the height.
    /// </summary>
    public int Height 
    {
        get;
    }

    /// <summary>
    /// Gets the x position of this frame.
    /// </summary>
    public int X 
    {
        get;
    }

    /// <summary>
    /// Gets the y position of this frame.
    /// </summary>
    public int Y 
    {
        get;
    }

    /// <summary>
    /// Gets the position.
    /// </summary>
    public Point Position => new (X, Y);

    /// <summary>
    /// Gets the size.
    /// </summary>
    public Size Size => new (Width, Height);

    /// <summary>
    /// Initialize a new instance of <see cref="AnimationFrame"/>
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="width"></param>
    /// <param name="height"></param>
    public AnimationFrame(int x, int y, int width, int height)
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

    /// <summary>
    /// Initialize a new instance of <see cref="AnimationFrame"/>
    /// </summary>
    /// <param name="position"></param>
    /// <param name="size"></param>
    public AnimationFrame(Point position, Size size) 
    {
        NullHelper.IsNullThrow(position, nameof(position));
        NullHelper.IsNullThrow(size, nameof(size));

        X = position.X;
        Y = position.Y;
        Width = size.Width;
        Height = size.Height;
    }
}
