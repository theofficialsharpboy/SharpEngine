
using SharpEngine.Exceptions;

namespace SharpEngine.Helpers;

internal class SupportHelper
{
    public static void ThrowIfUnsupportedImageType(string fileName)
    {
        NullHelper.IsNullThrow(fileName, nameof(fileName));
        if(!File.Exists(fileName)) throw new FileNotFoundException(fileName);

        string[] supportedTypes = new string[]
        {
            ".bmp", ".png", ".jpg", ".jpeg", ".tga",
            ".gif", ".hdr"
        };

        foreach(var supported in supportedTypes)
        {
            var extention = Path.GetExtension(fileName);

            if(extention.Contains(supported) || extention == supported)
            {
                return;
            }
        }

        throw new FileNotSupportedException(fileName);
    }

    public static void ThrowIfUnsupportedFontType(string fileName)
    {
        NullHelper.IsNullThrow(fileName, nameof(fileName));
        if(!File.Exists(fileName)) throw new FileNotFoundException(fileName);

        string[] supportedTypes = new string[]
        {
            ".ttf", ".otf"
        };

        foreach(var supported in supportedTypes)
        {
            var extention = Path.GetExtension(fileName);

            if(extention.Contains(supported) || extention == supported)
            {
                return;
            }
        }

        throw new FileNotSupportedException(fileName);
    }

    public static void ThrowIfUnsupportedShaderType(string fileName) 
    {
        NullHelper.IsNullThrow(fileName, nameof(fileName));
        if(!File.Exists(fileName)) throw new FileNotFoundException(fileName);

        string[] supportedTypes = new string[]
        {
            ".glsl"
        };

        foreach(var supported in supportedTypes)
        {
            var extention = Path.GetExtension(fileName);

            if(extention.Contains(supported) || extention == supported)
            {
                return;
            }
        }

        throw new FileNotSupportedException(fileName);
    }
}
