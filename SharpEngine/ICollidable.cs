using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpEngine;
public interface ICollidable
{
    /// <summary>
    /// Gets the bounds.
    /// </summary>
    Rectangle Bounds { get; }

    /// <summary>
    /// Gets a <see cref="Boolean"/> value indicating whether the object has collided with another object.
    /// </summary>
    /// <param name="other"></param>
    bool CollidesWith(ICollidable other);
}
