using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharpEngine.Graphics;

public class Resulotion
{
    int width, height;
    AspectRatio ratio;

    /// <summary>
    /// Gets the width.
    /// </summary>
    public int Width => width;

    /// <summary>
    /// Gets the height.
    /// </summary>
    public int Height => height;

    /// <summary>
    /// Gets the aspect ratio.
    /// </summary>
    public AspectRatio AspectRatio => ratio;

    /// <summary>
    /// Initialize a new instance of <see cref="Resulotion"/>
    /// </summary>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public Resulotion(int width, int height)
    {
        if(width < 0 || width > int.MaxValue) throw new ArgumentOutOfRangeException(nameof(width));
        if(height < 0 || height > int.MaxValue) throw new ArgumentOutOfRangeException(nameof(height));

        this.width = width;
        this.height = height;
        this.ratio = AspectRatio.Create(width, height);
    }
}
