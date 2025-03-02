
using SFML.Graphics;
using SFML.System;
using SharpEngine.Content;
using SharpEngine.Graphics;
using SharpEngine.Helpers;

namespace SharpEngine.Extensions;

public static class SpriteBatchExtensions
{
    /// <summary>
    /// Draws a texture with a shadow background.
    /// </summary>
    /// <param name="me"></param>
    /// <param name="texture"></param>
    /// <param name="position"></param>
    /// <param name="radius"></param>
    /// <param name="color"></param>
    public static void DrawShadowTexture(this SpriteBatch me, Texture texture, Vector2 position, float radius, Color color) 
    {
        var shadowColor = new Color(0, 0, 0, (int)radius * 255);
        var newPosition = new Vector2(position.X + 5, position.Y + 5);

        me.Draw(texture, newPosition, shadowColor);
        me.Draw(texture, position, color);
    }

    /// <summary>
    /// Draws a shadow texture.
    /// </summary>
    /// <param name="me"></param>
    /// <param name="texture"></param>
    /// <param name="position"></param>
    /// <param name="radiusX"></param>
    /// <param name="radiusY"></param>
    /// <param name="shadowRadius"></param>
    /// <param name="color"></param>
    public static void DrawShadowTexture(this SpriteBatch me, Texture texture, Vector2 position, float radiusX, float radiusY, float shadowRadius, Color color)
    {
        var shadowColor = new Color(0, 0, 0, (int)shadowRadius * 255);
        var newPosition = new Vector2(position.X, position.Y) + new Vector2(radiusX, radiusY);

        me.Draw(texture, newPosition, shadowColor);
        me.Draw(texture, position, color);
    }

    /// <summary>
    /// Draws a shadow string.
    /// </summary>
    /// <param name="me"></param>
    /// <param name="font"></param>
    /// <param name="text"></param>
    /// <param name="position"></param>
    /// <param name="radius"></param>
    /// <param name="color"></param>
    public static void DrawShadowString(this SpriteBatch me, SpriteFont font, string text, Vector2 position, float radius, Color color)
    {
        var shadowColor = new Color(0, 0, 0,(int)radius * 255);
        var newPosition = new Vector2(position.X + 5, position.Y + 5);

        me.DrawString(font, text, newPosition, shadowColor);
        me.DrawString(font, text, position, color);
    }

    /// <summary>
    /// Creates a rectangle texture.
    /// </summary>
    /// <param name="me"></param>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static Texture2D CreateRectangle(this SpriteBatch me, int width, int height, Color color) 
    {
        if(width < int.MinValue || width > int.MaxValue) throw new ArgumentOutOfRangeException(nameof(width));
        if(height < int.MinValue || height > int.MaxValue) throw new ArgumentOutOfRangeException(nameof(height));

        SFML.Graphics.Image image = new ((uint)width, (uint)height);

        for(int x = 0; x < width; x++)
        {
            for(int y = 0; y < height; y++)
            {
                image.SetPixel((uint)x, (uint)y, SFMLHelper.SFMLColor(color));
            }
        }

        return new Texture2D(image);
    }
    /// <summary>
    /// Creates a rectangle with rounded colors.
    /// </summary>
    /// <param name="me"></param>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <param name="radius"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static Texture2D CreateRoundedRectangle(this SpriteBatch me, int width, int height, int radius, Color color)
    {
        if(width < int.MinValue || width > int.MaxValue) throw new ArgumentOutOfRangeException(nameof(width));
        if(height < int.MinValue || height > int.MaxValue) throw new ArgumentOutOfRangeException(nameof(height));

        SFML.Graphics.Image image = new SFML.Graphics.Image((uint)width, (uint)height);

        for(int x = 0; x < width; x++)
        {
            for(int y = 0; y < height; y++)
            {
                if(IsOutsideRoundedCorner((uint)x, (uint)y, (uint)width, (uint)height, (uint)radius)) image.SetPixel((uint)x, (uint)y, SFMLHelper.SFMLColor(Color.Transparent));
                else image.SetPixel((uint)x, (uint)y, SFMLHelper.SFMLColor(color));
            }
        }

        return new Texture2D(image);
    }

    /// <summary>
    /// Draws a line.
    /// </summary>
    /// <param name="me"></param>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <param name="color"></param>
    public static void DrawLine(this SpriteBatch me, Vector2 start, Vector2 end, Color color) 
    {
        NullHelper.IsNullThrow(start, nameof(start));
        NullHelper.IsNullThrow(end, nameof(end));
        NullHelper.IsNullThrow(color, nameof(color));

        float dx = end.X - start.X;
        float dy = end.Y - start.Y;
        float length = (float)Math.Sqrt(dx * dx + dy * dy);
        float angle = (float)Math.Atan2(dy, dx);

        me.Draw(
           generateTexture((int)(start.X + end.X), (int)(start.Y + end.Y), color),
           new Vector2(start.X, start.Y + end.Y),
           Color.White,
           angle * (180f / (float)Math.PI),
           length / (int)(start.X + end.X)
        );
    }

    /// <summary>
    /// Draws a rectangle border.
    /// </summary>
    /// <param name="spriteBatch"></param>
    /// <param name="rectangle"></param>
    /// <param name="color"></param>
    public static void DrawRectangeOutline(this SpriteBatch spriteBatch, Rectangle rectangle, Color color) 
    {
        NullHelper.IsNullThrow(rectangle, nameof(rectangle));
        NullHelper.IsNullThrow(color, nameof(color));

        int x1 = rectangle.X;
        int y1 = rectangle.Y;
        int x2 =  rectangle.X + rectangle.Width;
        int y2 = rectangle.Y + rectangle.Height;

        Image image = new ((uint)rectangle.Width, (uint)rectangle.Height);

        for (int x = x1; x <= x2; x++)
        {
            image.SetPixel((uint)x, (uint)y1, SFMLHelper.SFMLColor(color)); 
            image.SetPixel((uint)x, (uint)y2, SFMLHelper.SFMLColor(color)); 
        }

        for (int y = y1; y <= y2; y++)
        {
            image.SetPixel((uint)x1, (uint)y, SFMLHelper.SFMLColor(color));
            image.SetPixel((uint)x2, (uint)y, SFMLHelper.SFMLColor(color));
        }

        spriteBatch.Draw(new Texture2D(image), new Vector2(rectangle.X, rectangle.Y), color);
    }

    #region private helpers
    private static bool IsOutsideRoundedCorner(uint x, uint y, uint width, uint height, uint radius)
    {
        // Check if the pixel is in one of the four corners
        bool inTopLeftCorner = (x <= radius && y <= radius) && (Math.Pow(x, 2) + Math.Pow(y, 2) > Math.Pow(radius, 2));
        bool inTopRightCorner = (x >= width - radius && y <= radius) && (Math.Pow(x - width, 2) + Math.Pow(y, 2) > Math.Pow(radius, 2));
        bool inBottomLeftCorner = (x <= radius && y >= height - radius) && (Math.Pow(x, 2) + Math.Pow(y - height, 2) > Math.Pow(radius, 2));
        bool inBottomRightCorner = (x >= width - radius && y >= height - radius) && (Math.Pow(x - width, 2) + Math.Pow(y - height, 2) > Math.Pow(radius, 2));

        // Return true if the pixel is outside the rounded area, otherwise false
        return inTopLeftCorner || inTopRightCorner || inBottomLeftCorner || inBottomRightCorner;
    }

    private static Texture2D generateTexture(int width, int height, Color color) 
    {
        Image image = new Image((uint)width, (uint)height);

        for(int x = 0; x < width; x++)
        {
            for(int y = 0; y < height; y++)
            {
                image.SetPixel((uint)x, (uint)y, SFMLHelper.SFMLColor(color));
            }
        }

        return new Texture2D(image);
    }
    #endregion
}
