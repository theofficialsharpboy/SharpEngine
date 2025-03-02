using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SFML.Window;

namespace SharpEngine;

public class Size
{
    int _width, _height;

    /// <summary>
    /// Gets the width.
    /// </summary>
    public int Width => _width;

    /// <summary>
    /// Gets the height.
    /// </summary>
    public int Height => _height;

    /// <summary>
    /// Initialize a new instance of <see cref="Size"/>
    /// </summary>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public Size(int width, int height) 
    {
        if(width < int.MinValue || width > int.MaxValue) throw new ArgumentOutOfRangeException(nameof(width));
        if(height < int.MinValue || height > int.MaxValue) throw new ArgumentOutOfRangeException(nameof(height));

        _width = width;
        _height = height;
    }
}
