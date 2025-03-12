using SFML.Graphics;
using SharpEngine.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpEngine.Helpers;

internal static class AtlasHelper
{
    public static List<Sprite> GetAtlasTexture(Texture2D atlasTexture, int atlasCount,  int atlasWidth, int atlasHeight)
    {
        Point position = new Point(0, 0);
        var maxHeight = atlasTexture.Size.Y;
        var maxwidth = atlasTexture.Size.X;
        List<Sprite> sprites = new List<Sprite>();
        for (int i = 0; i < atlasCount; i++)
        {
            if(position.X >= maxwidth) position.Y += atlasHeight; // move the position to the next row.
            if(position.Y >= maxHeight) throw new ArgumentOutOfRangeException(nameof(atlasCount), "The atlas count is larger than the current atlas texture");

            position.X += atlasWidth;

            Sprite sprite = new Sprite(atlasTexture);
            sprite.TextureRect = SFMLHelper.SFMLRect(new Rectangle(position.X, position.Y, atlasWidth, atlasHeight));

            sprites.Add(sprite);
        }

        return sprites;
    }
}
