using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpEngine.Extensions;
public static class Verctor2Extensions
{
    /// <summary>
    /// Adds a vector2 positon, onto this one.
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static Vector2 Add(this Vector2 a, Vector2 b)
    {
        return new Vector2(a.X + b.X, a.Y + b.Y);
    }

    /// <summary>
    /// Removes a vector2 position, from this one.
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static Vector2 Minus(this Vector2 a, Vector2 b)
    {
        var x = a.X - b.X;
        var y = a.Y - b.Y;

        return new Vector2(x, y);
    }
}
