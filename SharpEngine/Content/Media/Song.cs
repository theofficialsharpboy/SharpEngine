using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SharpEngine.Helpers;

namespace SharpEngine.Content.Media;

public class Song
{
    /// <summary>
    /// Gets the path.
    /// </summary>
    public string Path {get;}
    
    /// <summary>
    /// Gets or sets whether to loop this song.
    /// </summary>
    public bool Loop 
    {
        get;
        set;
    }

    /// <summary>
    /// Initialize a new isntance of <see cref="Song"/>
    /// </summary>
    /// <param name="path"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public Song(string path)
    {
        MediaHelper.ThrowIfUnSupportedFile(path);
        
        Path = path;
    }
}
