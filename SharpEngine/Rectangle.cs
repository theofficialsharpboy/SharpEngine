using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;

namespace SharpEngine;

public class Rectangle
{
    int x, y, width, height;

    /// <summary>
    /// Gets the x position.
    /// </summary>
    public int X => x;

    /// <summary>
    /// Gets the y position.
    /// </summary>
    public int Y => y;

    /// <summary>
    /// Gets the width of this rectangle.
    /// </summary>
    public int Width => width;

    /// <summary>
    /// Gets the height of this rectangle.
    /// </summary>
    public int Height => height;

    /// <summary>
    /// Gets the left face of this rectangle.
    /// </summary>
    public int Left => x;

    /// <summary>
    /// Gets the right face of this rectangle.
    /// </summary>
    public int Right => x + width;

    /// <summary>
    /// Gets the top of this rectangle.
    /// </summary>
    public int Top => y;

    /// <summary>
    /// Gets the bottom of this rectangle.
    /// </summary>
    public int Bottom => y + height;

    /// <summary>
    /// Gets the position.
    /// </summary>
    public Point Position => new (X, Y);
    
    /// <summary>
    /// Gets the size.
    /// </summary>
    public Size Size => new(width, height);

    ///<summary>
    ///Initialize a new instance of <see cref="Rectangle"/>
    ///</summary>
    public Rectangle(int x, int y, int width, int height) 
    {
        if(x < int.MinValue || x > int.MaxValue) throw new ArgumentOutOfRangeException(nameof(x));
        if(y < int.MinValue || y > int.MaxValue) throw new ArgumentOutOfRangeException(nameof(y));
        if(width < int.MinValue || width > int.MaxValue) throw new ArgumentOutOfRangeException(nameof(width));
        if(height < int.MinValue || height > int.MaxValue) throw new ArgumentOutOfRangeException(nameof(height));

        this.x = x;
        this.y = y;
        this.width = width;
        this.height = height;
    }

    /// <summary>
    /// Inflate this rectangle.
    /// </summary>
    /// <param name="hInflate">Horizontal.</param>
    /// <param name="vInflate">Vertical</param>
    public void Inflate(int hInflate, int vInflate)
    {
        if(hInflate < int.MinValue || hInflate > int.MaxValue) throw new ArgumentOutOfRangeException(nameof(hInflate));
        if(vInflate < int.MinValue || vInflate > int.MaxValue) throw new ArgumentOutOfRangeException(nameof(vInflate));

        x += hInflate;
        y += vInflate;
        width += hInflate;
        height += vInflate;
    }


    /// <summary>
    /// Gets a bool value indecating whether this <see cref="Rectangle"/> intersects the specified <see cref="Rectangle"/>
    /// </summary>
    /// <param name="rectangle"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public bool InteractWith(Rectangle rectangle) 
    {
        if(rectangle == null) throw new ArgumentNullException(nameof(rectangle));

        return 
            Left < rectangle.Right &&
            Right < rectangle.Left &&
            Top < rectangle.Bottom &&
            Bottom < rectangle.Top;
    }
}
