using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SharpEngine.Exceptions;

namespace SharpEngine.Helpers;

internal class MediaHelper
{
    public static void ThrowIfUnSupportedFile(string fileName)
    {
        NullHelper.IsNullThrow(fileName, nameof(fileName));
        if(!File.Exists(fileName)) throw new FileNotFoundException(fileName);

        string[] supportedTypes = new string[]
        {
            ".wav", ".ogg", ".flac"
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
