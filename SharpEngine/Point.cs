using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharpEngine;

public class Point
{
    int x, y;

    /// <summary>
    /// Gets or sets the x position.
    /// </summary>
    public int X { get => x; set => x = value; }

    /// <summary>
    /// Gets or sets the y position.
    /// </summary>
    public int Y { get => y; set => y = value; }

    /// <summary>
    /// Initialize a new instance of <see cref="Point"/>
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public Point(int x, int y)
    {
        if(x < int.MinValue || x > int.MaxValue) throw new ArgumentOutOfRangeException(nameof(x));
        if(y < int.MinValue || y > int.MaxValue) throw new ArgumentOutOfRangeException(nameof(y));

        this.x = x;
        this.y = y;
    }

    public static Point operator +(Point a, Point b) => new Point(a.X + b.X, a.Y + b.Y);
    public static Point operator -(Point a, Point b) => new Point(a.x - b.x, b.y - b.y);
}
