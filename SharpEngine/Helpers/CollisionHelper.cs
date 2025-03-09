using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpEngine.Helpers;

internal class CollisionHelper
{
    /// <summary>
    /// Checks if two rectangles are colliding.
    /// </summary>
    /// <param name="rect1Pos">Position of the first rectangle.</param>
    /// <param name="rect1Size">Size of the first rectangle.</param>
    /// <param name="rect2Pos">Position of the second rectangle.</param>
    /// <param name="rect2Size">Size of the second rectangle.</param>
    /// <returns>True if the rectangles are colliding, otherwise false.</returns>
    public static bool CheckRectangleCollision(Vector2 rect1Pos, Vector2 rect1Size, Vector2 rect2Pos, Vector2 rect2Size)
    {
        return rect1Pos.X < rect2Pos.X + rect2Size.X &&
               rect1Pos.X + rect1Size.X > rect2Pos.X &&
               rect1Pos.Y < rect2Pos.Y + rect2Size.Y &&
               rect1Pos.Y + rect1Size.Y > rect2Pos.Y;
    }

    /// <summary>
    /// Checks if a rectangle and a point are colliding.
    /// </summary>
    /// <param name="rectPos">Position of the rectangle.</param>
    /// <param name="rectSize">Size of the rectangle.</param>
    /// <param name="point">Position of the point.</param>
    /// <returns>True if the point is inside the rectangle, otherwise false.</returns>
    public static bool CheckRectanglePointCollision(Vector2 rectPos, Vector2 rectSize, Vector2 point)
    {
        return point.X >= rectPos.X &&
               point.X <= rectPos.X + rectSize.X &&
               point.Y >= rectPos.Y &&
               point.Y <= rectPos.Y + rectSize.Y;
    }
}