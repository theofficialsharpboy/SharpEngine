using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SFML.Graphics;
using SharpEngine.Content;

namespace SharpEngine.Helpers;

internal static class TextureHelper
{
    public static Texture2D Generate(int width,int height, Color color)
    {
        NullHelper.IsNullThrow(width, nameof(width));
        NullHelper.IsNullThrow(height, nameof(height));
        NullHelper.IsNullThrow(color, nameof(color));

        Image image = new ((uint)width, (uint)height);

        for(int i = 0; i < width;i++)
        {
            for(int j = 0; j < height; j++)
            {
                image.SetPixel((uint)i, (uint)j, SFMLHelper.SFMLColor(color));
            }
        }

        return new Texture2D(image);
    }
}
