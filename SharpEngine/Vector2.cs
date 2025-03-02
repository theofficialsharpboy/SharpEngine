using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace SharpEngine;

public class Vector2
{
    /// <summary>
    /// Gets the x position.
    /// </summary>
    public float X{get;set;}

    /// <summary>
    /// Gets the y position.
    /// </summary>
    public float Y{get;set;}
    
    /// <summary>
    /// Initialize a new instance of <see cref="Vector2"/>
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public Vector2(float x, float y)
    {
        if(x < float.MinValue || x > float.MaxValue) throw new ArgumentOutOfRangeException(nameof(x));
        if(y < float.MinValue || y > float.MaxValue) throw new ArgumentOutOfRangeException(nameof(y));

        X = x;
        Y = y;
    }

    /// <summary>
    /// Returns the distance between another <see cref="Vector2"/>
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public float Distance(Vector2 value)
    {
        float v = X - Y;
        float v1 = value.X - value.Y;

        return MathF.Sqrt(
            (v * v) +
            (v1 * v1)
        );
    }

    /// <summary>
    /// Returns the distance between two vectors.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="value1"></param>
    /// <returns></returns>
    public static float Distance(Vector2 value, Vector2 value1) 
    {
        float v = value.X - value1.X, v2 = value.Y - value1.Y;
        return MathF.Sqrt(
            (v * v) +
            (v2 * v2)
        );
    }

    /// <summary>
    /// Clamps the specified value within a range.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="min"></param>
    /// <param name="max"></param>
    public static void Clamp(Vector2 value, Vector2 min, Vector2 max)
    {
        value.X = Math.Clamp(value.X, min.X, max.X);
        value.Y = Math.Clamp(value.Y, min.Y, max.Y);
    }

    /// <summary>
    /// Creates a bew <see cref="Vector2"/> that contains members from another vector rounded towards positive infinity.
    /// </summary>
    public static void Ceiling(Vector2 value) 
    {
        value.X = (float)Math.Ceiling(value.X);
        value.Y = (float)Math.Ceiling(value.Y);
    }

    /// <summary>
    /// Creates a bew <see cref="Vector2"/> that contains members from another vector rounded towards positive infinity.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="result"></param>
    public static void Ceiling(Vector2 value, out Vector2 result)
    {
        result = new (
            (float)Math.Ceiling(value.X),
            (float)Math.Ceiling(value.Y)
        );
    }

    public static Vector2 operator +(Vector2 vect, Vector2 vect2) => new Vector2(vect.X + vect2.X, vect.Y + vect2.Y);
    public static Vector2 operator -(Vector2 vect, Vector2 vect2) => new Vector2(vect.X - vect2.X, vect.Y - vect2.Y);
    public static Vector2 operator /(Vector2 vect, Vector2 vect2) => new Vector2(vect.X /vect2.X, vect.Y /vect2.Y);
    public static Vector2 operator *(Vector2 vect, Vector2 vect2) => new Vector2(vect.X * vect.X, vect.Y *vect2.Y);

    public static bool operator <(Vector2 vect, Vector2 vect2) => vect.X < vect2.X && vect.Y < vect2.Y;
    public static bool operator >(Vector2 vect, Vector2 vect2) => vect.X > vect2.X && vect.Y > vect2.Y;
    public static bool operator <=(Vector2 vect, Vector2 vect2) => vect.X <= vect2.X && vect.Y <= vect2.Y;
    public static bool operator >=(Vector2 vect, Vector2 vect2) => vect.X >= vect2.X && vect.Y >= vect2.Y;
}
