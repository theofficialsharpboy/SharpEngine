using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SFML.Graphics;
using SharpEngine.Helpers;

namespace SharpEngine.Content;

public class Texture2D : Texture
{
    /// <summary>
    /// Initalize a new instance of <see cref="Texture2D"/>
    /// </summary>
    /// <param name="filePath"></param>
    public Texture2D(string filePath) : base(filePath)
    {
    }

    /// <summary>
    /// Initialize a new instance of <see cref="Texture2D"/>
    /// </summary>
    /// <param name="filePath"></param>
    /// <param name="area"></param>
    public Texture2D(string filePath, Rectangle area) : base(filePath, SFMLHelper.SFMLRect(area))
    {
    }

    /// <summary>
    /// Initialize a new instance of <see cref="Texture2D"/>
    /// </summary>
    /// <param name="image"></param>
    internal Texture2D(SFML.Graphics.Image image) : base(image)
    {

    }
}