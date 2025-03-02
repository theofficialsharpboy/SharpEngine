using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharpEngine.Helpers;

internal static class ColorHelper
{
    public static (int red, int blue, int green, int alpha) FromHex(string hexNumber) 
    {
        if(!hexNumber.StartsWith("#")) throw new ArgumentOutOfRangeException($"{nameof(hexNumber)} must be a hex number and must start with #");
        hexNumber = hexNumber.TrimStart('#');
        if(hexNumber.Length == 6) hexNumber += "FF";

        int red = Convert.ToInt32(hexNumber.Substring(0, 2), 16);
        int green = Convert.ToInt32(hexNumber.Substring(2, 2), 16);
        int blue = Convert.ToInt32(hexNumber.Substring(4, 2), 16);
        int alpha = Convert.ToInt32(hexNumber.Substring(6, 2), 16);

        return (red, green, blue, alpha);
    }

    public static (int red, int green, int blue, int alpha) FromHLS(float h, float l, float s)
    {
        // Normalize HLS values
        h = h % 360; // Ensure hue is within the range [0, 360)
        s = Math.Clamp(s, 0f, 1f); // Clamp saturation to [0, 1]
        l = Math.Clamp(l, 0f, 1f); // Clamp lightness to [0, 1]

        // Chroma is the difference between the max and min RGB values
        float c = (1 - Math.Abs(2 * l - 1)) * s;
        // X is an intermediate value based on hue
        float x = c * (1 - Math.Abs((h / 60f) % 2 - 1));
        // m is a value to adjust the final RGB values based on lightness
        float m = l - c / 2;

        float r = 0, g = 0, b = 0;

        // Determine RGB based on hue value
        if (h >= 0 && h < 60)
        {
            r = c; g = x; b = 0;
        }
        else if (h >= 60 && h < 120)
        {
            r = x; g = c; b = 0;
        }
        else if (h >= 120 && h < 180)
        {
            r = 0; g = c; b = x;
        }
        else if (h >= 180 && h < 240)
        {
            r = 0; g = x; b = c;
        }
        else if (h >= 240 && h < 300)
        {
            r = x; g = 0; b = c;
        }
        else if (h >= 300 && h < 360)
        {
            r = c; g = 0; b = x;
        }

        // Adjust RGB values by adding m
        r += m;
        g += m;
        b += m;

        // Convert to 0-255 range
        int red = (int)Math.Round(r * 255);
        int green = (int)Math.Round(g * 255);
        int blue = (int)Math.Round(b * 255);

        // Alpha is 255 (fully opaque) in this case
        int alpha = 255;

        return (red, green, blue, alpha);
    }

    public static (int red, int green, int blue, int alpha) FromHLSA(float h, float l, float s, int a)
    {
        // Normalize HLS values
        h = h % 360; // Ensure hue is within the range [0, 360)
        s = Math.Clamp(s, 0f, 1f); // Clamp saturation to [0, 1]
        l = Math.Clamp(l, 0f, 1f); // Clamp lightness to [0, 1]

        // Chroma is the difference between the max and min RGB values
        float c = (1 - Math.Abs(2 * l - 1)) * s;
        // X is an intermediate value based on hue
        float x = c * (1 - Math.Abs((h / 60f) % 2 - 1));
        // m is a value to adjust the final RGB values based on lightness
        float m = l - c / 2;

        float r = 0, g = 0, b = 0;

        // Determine RGB based on hue value
        if (h >= 0 && h < 60)
        {
            r = c; g = x; b = 0;
        }
        else if (h >= 60 && h < 120)
        {
            r = x; g = c; b = 0;
        }
        else if (h >= 120 && h < 180)
        {
            r = 0; g = c; b = x;
        }
        else if (h >= 180 && h < 240)
        {
            r = 0; g = x; b = c;
        }
        else if (h >= 240 && h < 300)
        {
            r = x; g = 0; b = c;
        }
        else if (h >= 300 && h < 360)
        {
            r = c; g = 0; b = x;
        }

        // Adjust RGB values by adding m
        r += m;
        g += m;
        b += m;

        // Convert to 0-255 range
        int red = (int)Math.Round(r * 255);
        int green = (int)Math.Round(g * 255);
        int blue = (int)Math.Round(b * 255);

        // Alpha is 255 (fully opaque) in this case
        int alpha = Math.Clamp(a, 0, 255);

        return (red, green, blue, alpha);
    }
}
