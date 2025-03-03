
using SFML.Graphics;
using SharpEngine.Content;
using SharpEngine.Helpers;

namespace SharpEngine;

public class RenderTarget
{
    internal RenderTexture renderTexture;
    int width, height;

    public RenderTarget(int width, int height)
    {
        NullHelper.IsNullThrow(width, nameof(width));
        NullHelper.IsNullThrow(height, nameof(height));
        
        renderTexture = new ((uint)width, (uint)height);
        this.width = width;
        this.height = height;
    }


    /// <summary>
    /// Draws a texture onto this <see cref="RenderTarget"/>
    /// </summary>
    /// <param name="texture"></param>
    /// <param name="position"></param>
    /// <param name="color"></param>
    public void Draw(Texture2D texture, Vector2 position, Color color) 
    {
        Sprite sprite = new (texture);
        sprite.Position = SFMLHelper.SFMLVector2(position);
        sprite.Color = SFMLHelper.SFMLColor(color);

        renderTexture.Draw(sprite);
    }

    /// <summary>
    /// Draws text onto this <see cref="RenderTarget"/>
    /// </summary>
    /// <param name="text"></param>
    /// <param name="font"></param>
    /// <param name="position"></param>
    /// <param name="color"></param>
    public void Draw(string text, SpriteFont font, Vector2 position, Color color)
    {
        Text t = new (text, SFMLHelper.SFMLFont(font));
        t.FillColor = SFMLHelper.SFMLColor(color);
        t.Position = SFMLHelper.SFMLVector2(position);

        renderTexture.Draw(t);
    }

    /// <summary>
    /// Display this render target.
    /// </summary>
    internal void Display() => renderTexture.Display();
}
