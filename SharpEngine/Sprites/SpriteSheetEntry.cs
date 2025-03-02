using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SharpEngine.Helpers;

namespace SharpEngine.Sprites;

public class SpriteSheetEntry
{
    /// <summary>
    /// Gets the position of this sprite on the spritesheet
    /// </summary>
    public Point Position {get;}

    /// <summary>
    /// Gets the width of the sprite.
    /// </summary>
    public int Width {get;}

    /// <summary>
    /// Gets the height of the sprite.
    /// </summary>
    public int Height {get;}

    /// <summary>
    /// Initialize a new instance of <see cref="SpriteSheetEntry"/>
    /// </summary>
    /// <param name="position"></param>
    /// <param name="width"></param>
    /// <param name="height"></param>
    public SpriteSheetEntry(Point position, int width, int height) 
    {
        NullHelper.IsNullThrow(position, nameof(position));
        NullHelper.IsNullThrow(width, nameof(width));
        NullHelper.IsNullThrow(height, nameof(height));

        Position = position;
        Width = width;
        Height = height;
    }
}
