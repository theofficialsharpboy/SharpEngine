using SharpEngine.Content;
using SFML.Graphics;
using SFML.System;
using SharpEngine.Helpers;


namespace SharpEngine.Extensions;

public static class Texture2DExtensions
{
    /// <summary>
    /// Create a new instance of <see cref="Texture2D"/> from a <see cref="Image"/>
    /// </summary>
    /// <param name="image"></param>
    /// <returns></returns>
    public static Texture2D ToTexture2D(this Image image)
    {
        return new Texture2D(image);
    }
    /// <summary>
    /// Create a new instance of <see cref="Texture2D"/> from a <see cref="Image"/>
    /// </summary>
    /// <param name="image"></param>
    /// <param name="area"></param>
    /// <returns></returns>
    public static Texture2D ToTexture2D(this Image image, IntRect area)
    {
        return new Texture2D(image);
    }

    /// <summary>
    /// Blurs the current texture.
    /// </summary>
    /// <param name="texture"></param>
    /// <param name="radius"></param>
    public static void Blur(this Texture2D texture, int radius)
    {
        Image image = texture.CopyToImage();
        Vector2u size = image.Size;
        Image blurredImage = new Image(size.X, size.Y);

        for (uint y = 0; y < size.Y; y++)
        {
            for (uint x = 0; x < size.X; x++)
            {
                Color averageColor = GetAverageColor(image, x, y, radius);
                blurredImage.SetPixel(x, y, SFMLHelper.SFMLColor(averageColor));
            }
        }

        texture.Update(blurredImage);
    }

    private static Color GetAverageColor(Image image, uint x, uint y, int radius)
    {
        int r = 0, g = 0, b = 0, a = 0;
        int count = 0;

        for (int offsetY = -radius; offsetY <= radius; offsetY++)
        {
            for (int offsetX = -radius; offsetX <= radius; offsetX++)
            {
                int sampleX = (int)x + offsetX;
                int sampleY = (int)y + offsetY;

                if (sampleX >= 0 && sampleX < (int)image.Size.X && sampleY >= 0 && sampleY < (int)image.Size.Y)
                {
                    SFML.Graphics.Color color = image.GetPixel((uint)sampleX, (uint)sampleY);
                    r += color.R;
                    g += color.G;
                    b += color.B;
                    a += color.A;
                    count++;
                }
            }
        }

        return new Color((byte)(r / count), (byte)(g / count), (byte)(b / count), (byte)(a / count));
    }

    /// <summary>
    /// Applies a glow effect to the current texture.
    /// </summary>
    /// <param name="texture"></param>
    /// <param name="glowRadius"></param>
    /// <param name="glowColor"></param>
    public static void Glow(this Texture2D texture, int glowRadius, SharpEngine.Color glowColor)
    {
        Image image = texture.CopyToImage();
        Vector2u size = image.Size;
        Image glowImage = new Image(size.X, size.Y);

        for (uint y = 0; y < size.Y; y++)
        {
            for (uint x = 0; x < size.X; x++)
            {
                SFML.Graphics.Color originalColor = image.GetPixel(x, y);
                if (originalColor.A > 0)
                {
                    ApplyGlow(glowImage, x, y, glowRadius, glowColor);
                }
            }
        }

        texture.Update(glowImage);
    }

    private static void ApplyGlow(Image image, uint x, uint y, int radius, Color glowColor)
    {
        for (int offsetY = -radius; offsetY <= radius; offsetY++)
        {
            for (int offsetX = -radius; offsetX <= radius; offsetX++)
            {
                int sampleX = (int)x + offsetX;
                int sampleY = (int)y + offsetY;

                if (sampleX >= 0 && sampleX < (int)image.Size.X && sampleY >= 0 && sampleY < (int)image.Size.Y)
                {
                    SFML.Graphics.Color currentColor = image.GetPixel((uint)sampleX, (uint)sampleY);
                    Color blendedColor = BlendColors(currentColor, SFMLHelper.SFMLColor(glowColor));
                    image.SetPixel((uint)sampleX, (uint)sampleY, SFMLHelper.SFMLColor(blendedColor));
                }
            }
        }
    }
    private static Color BlendColors(SFML.Graphics.Color baseColor, SFML.Graphics.Color blendColor)
    {
        int r = (baseColor.R + blendColor.R) / 2;
        int g = (baseColor.G + blendColor.G) / 2;
        int b = (baseColor.B + blendColor.B) / 2;
        int a = (baseColor.A + blendColor.A) / 2;

        return new Color(r, g, b, a);
    }
}
