using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SharpEngine.Helpers;

namespace SharpEngine.Content.Media;

public class SoundEffect
{
    /// <summary>
    /// Gets the path.
    /// </summary>
    public string Path {get;}

    /// <summary>
    /// Initialize a new instance of <see cref="Path"/>
    /// </summary>
    /// <param name="path"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public SoundEffect(string path)
    {
        MediaHelper.ThrowIfUnSupportedFile(path);
        
        Path = path;
    }
}
