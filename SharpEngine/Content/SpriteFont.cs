
using SFML.Graphics;
using SharpEngine.Helpers;

namespace SharpEngine.Content;

using Font = SFML.Graphics.Font;

public class SpriteFont
{
    /// <summary>
    /// Gets the path.
    /// </summary>
    public string Path {get;}

    /// <summary>
    /// Gets the size.
    /// </summary>
    public int Size {get;}

    /// <summary>
    /// Initialize a new instance of <see cref="SpriteFont/>
    /// </summary>
    /// <param name="path"></param>
    /// <param name="size"></param>
    /// <exception cref="NullReferenceException"></exception>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    /// <exception cref="FileNotFoundException"></exception>
    protected SpriteFont(string path, int size)
    {
        if(!File.Exists(path)) throw new FileNotFoundException(path);
        if(string.IsNullOrWhiteSpace(path)) throw new NullReferenceException("path can not be null");
        if(size < int.MinValue || size > int.MaxValue) throw new ArgumentOutOfRangeException(nameof(size));

        this.Path = path;
        this.Size = size;
    }

    /// <summary>
    /// Creates a sprite font.
    /// </summary>
    /// <param name="path"></param>
    /// <param name="size"></param>
    /// <returns></returns>
    public static SpriteFont Create(string path, int size) => new SpriteFont(path, size);

    /// <summary>
    /// Measures a peice of text, using this <see cref="SpriteFont"/>
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public Size Measure(string text) 
    {
        NullHelper.IsNullThrow(text, nameof(text));

        Font font = new Font(Path);
        Text text1 = new (text, font, (uint)this.Size);

        return new ((int)text1.GetLocalBounds().Width, (int)text1.GetGlobalBounds().Height);
    }

    /// <summary>
    /// Gets the line spacing.
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public float LineSpacing(string text)
    {
        Font font = new Font(Path);
        Text text1 = new (text, font, (uint)this.Size);

        return text1.LineSpacing;
    }
}
