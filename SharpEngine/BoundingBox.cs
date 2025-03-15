

using SharpEngine.Helpers;

namespace SharpEngine;

public class BoundingBox
{
    /// <summary>
    /// Gets the bounds.
    /// </summary>
    public Rectangle Bounds
    {
        get;
        private set;
    }

    /// <summary>
    /// Gets the position.
    /// </summary>
    public Vector2 Position
    {
        get => new(Bounds.X, Bounds.Y);
    }

    /// <summary>
    /// Initialize a new instance of <see cref="BoundingBox"/>
    /// </summary>
    /// <param name="bounds"></param>
    public BoundingBox(Rectangle bounds)
    {
        NullHelper.IsNullThrow(bounds, nameof(bounds));

        Bounds = bounds;
    }

    /// <summary>
    /// Gets a value indicating whether this <see cref="BoundingBox"/> contains a point.
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public bool Intersects(BoundingBox other)
    {
        NullHelper.IsNullThrow(other, nameof(other));

        return Bounds.InteractWith(other.Bounds);
    }

    /// <summary>
    /// Copies from another bounding box.
    /// </summary>
    /// <param name="other"></param>
    public void Copy(BoundingBox other)
    {
        NullHelper.IsNullThrow(other, nameof(other));

        Bounds = other.Bounds;
    }
}
