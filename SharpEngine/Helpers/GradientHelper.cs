using SFML.Graphics;

namespace SharpEngine.Helpers;

internal class GradientHelper
{
    public static Image CreateHorizontalGradient(int width, int height, Color[] colors)
    {
        // Create a new image
        Image image = new Image((uint)width, (uint)height);

        int numColors = colors.Length;
        if (numColors < 2)
            throw new ArgumentException("There must be at least two colors for a gradient.");

        // Calculate the width of each color segment
        float segmentWidth = (float)width / (numColors - 1);

        // Loop through all pixels in the width
        for (uint x = 0; x < width; x++)
        {
            // Find which segment this x-coordinate belongs to
            int segmentIndex = (int)(x / segmentWidth);
            segmentIndex = Math.Min(segmentIndex, numColors - 2); // Ensure we don't exceed the array bounds

            // Interpolate between colors[segmentIndex] and colors[segmentIndex + 1]
            float interpolation = (x - segmentIndex * segmentWidth) / segmentWidth;

            Color startColor = colors[segmentIndex];
            Color endColor = colors[segmentIndex + 1];

            byte r = (byte)(startColor.R + interpolation * (endColor.R - startColor.R));
            byte g = (byte)(startColor.G + interpolation * (endColor.G - startColor.G));
            byte b = (byte)(startColor.B + interpolation * (endColor.B - startColor.B));

            // Set the color for all pixels at the current x position for all y
            for (uint y = 0; y < height; y++)
            {
                image.SetPixel(x, y, SFMLHelper.SFMLColor(new Color(r, g, b)));
            }
        }

        return image;
    }

     public static Image CreateVerticalGradient(int width, int height, Color[] colors)
    {
        // Create a new image
        Image image = new Image((uint)width, (uint)height);

        int numColors = colors.Length;
        if (numColors < 2)
            throw new ArgumentException("There must be at least two colors for a gradient.");

        // Calculate the height of each color segment
        float segmentHeight = (float)height / (numColors - 1);

        // Loop through all pixels in the height
        for (uint y = 0; y < height; y++)
        {
            // Find which segment this y-coordinate belongs to
            int segmentIndex = (int)(y / segmentHeight);
            segmentIndex = Math.Min(segmentIndex, numColors - 2); // Ensure we don't exceed the array bounds

            // Interpolate between colors[segmentIndex] and colors[segmentIndex + 1]
            float interpolation = (y - segmentIndex * segmentHeight) / segmentHeight;

            Color startColor = colors[segmentIndex];
            Color endColor = colors[segmentIndex + 1];

            byte r = (byte)(startColor.R + interpolation * (endColor.R - startColor.R));
            byte g = (byte)(startColor.G + interpolation * (endColor.G - startColor.G));
            byte b = (byte)(startColor.B + interpolation * (endColor.B - startColor.B));

            // Set the color for all pixels at the current y position for all x
            for (uint x = 0; x < width; x++)
            {
                image.SetPixel(x, y, SFMLHelper.SFMLColor(new Color(r, g, b)));
            }
        }

        return image;
    }
}
