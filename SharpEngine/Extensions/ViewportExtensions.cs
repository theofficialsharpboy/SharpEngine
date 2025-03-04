using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpEngine.Extensions;
public static class ViewportExtensions
{

    /// <summary>
    /// Creates a rectangle with the <see cref="Viewport"/> position, and size.
    /// </summary>
    /// <param name="viewport"></param>
    /// <returns>A rectangle based of the <see cref="Viewport"/></returns>
    public static Rectangle ToRect(this Viewport viewport)
    {
        return new Rectangle(viewport.X, viewport.Y, viewport.Width, viewport.Height);
    }
}
