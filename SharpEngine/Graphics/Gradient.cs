using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SFML.Graphics;
using SharpEngine.Content;
using SharpEngine.Helpers;

namespace SharpEngine.Graphics;

public class Gradient
{
    /// <summary>
    /// Gets the colors of this <see cref="Gradient"/>
    /// </summary>
    public ICollection<Color> Colors {get;}

    /// <summary>
    /// Gets the direction of this <see cref="Gradient"/>
    /// </summary>
    public GradientDirection Direction {get;}

    /// <summary>
    /// Initialize a new instance of <see cref="Gradient"/>
    /// </summary>
    /// <param name="colors"></param>
    public Gradient(ICollection<Color> colors, GradientDirection? direction)
    {
        NullHelper.IsNullThrow(colors, nameof(colors));
        if(!direction.HasValue) throw new ArgumentNullException(nameof(direction));

        this.Colors = colors;
        this.Direction = direction.Value;
    }
}
