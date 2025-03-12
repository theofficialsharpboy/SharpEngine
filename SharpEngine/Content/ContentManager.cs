
using SFML.Graphics;
using SharpEngine.Helpers;
using SharpEngine.Exceptions;
using SharpEngine.Content.Media;

namespace SharpEngine.Content;

public class ContentManager
{
    SharpWindow _window;

    /// <summary>
    /// Gets the window this <see cref="ContentManager"/> belongs to.
    /// </summary>
    public SharpWindow Window => _window;

    /// <summary>
    /// Initialize a new instance of <see cref="ContentManager"/>
    /// </summary>
    /// <param name="window"></param>
    /// <exception cref="NullReferenceException"></exception>
    public ContentManager(SharpWindow window)
    {
        if(window == null) throw new NullReferenceException(nameof(window));

        this._window = window;
    }

    /// <summary>
    /// Loads a font.
    /// </summary>
    /// <param name="path"></param>
    /// <param name="size"></param>
    /// <returns></returns>
    public SpriteFont LoadFont(string path, int size) 
    {
       SupportHelper.ThrowIfUnsupportedFontType(path);
       NullHelper.IsNullThrow(size, nameof(size));
         
        return SpriteFont.Create(path, size);
    }

    /// <summary>
    /// Loads a texture.
    /// </summary>
    /// <param name="path"></param>
    /// <param name="size"></param>
    /// <returns></returns>
    public Texture LoadTexture(string path, Rectangle size) 
    {
        SupportHelper.ThrowIfUnsupportedImageType(path);
        NullHelper.IsNullThrow(size, nameof(size));

        return new Texture(path, SFMLHelper.SFMLRect(size), false);
    }

    /// <summary>
    /// Loads a texture atlas.
    /// </summary>
    /// <param name="path"></param>
    /// <param name="atlasCount"></param>
    /// <param name="blockWidth"></param>
    /// <param name="blockHeight"></param>
    /// <returns></returns>
    public Atlas LoadAtlasTexture(string path, int atlasCount, int blockWidth, int blockHeight)
    {
        SupportHelper.ThrowIfUnsupportedImageType(path);
        NullHelper.IsNullThrow(atlasCount, nameof(atlasCount));
        NullHelper.IsNullThrow(blockWidth, nameof(blockWidth));
        NullHelper.IsNullThrow(blockHeight, nameof(blockHeight));

        return new Atlas(path, atlasCount, blockWidth, blockHeight);
    }

    /// <summary>
    /// Loads a texture.
    /// </summary>
    /// <param name="path"></param>
    /// <param name="size"></param>
    /// <returns></returns>
    public Texture2D LoadTexture2D(string path, Rectangle size) 
    {
        SupportHelper.ThrowIfUnsupportedImageType(path);
        NullHelper.IsNullThrow(size, nameof(size));

        return new Texture2D(path, size);
    }

    /// <summary>
    /// Loads a shader.
    /// </summary>
    /// <param name="shader"></param>
    /// <param name="geometry"></param>
    /// <param name="frag"></param>
    /// <returns></returns>
    public Effect LoadShader(string shader, string geometry, string frag)
    {
        SupportHelper.ThrowIfUnsupportedShaderType(shader);
        SupportHelper.ThrowIfUnsupportedShaderType(geometry);
        SupportHelper.ThrowIfUnsupportedShaderType(frag);
        
        return new Effect(shader, geometry, frag);
    }

    /// <summary>
    /// Loads a sound effect.
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public SoundEffect LoadSoundEffect(string path) => new SoundEffect(path);

    /// <summary>
    /// Loads a song.
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public Song LoadSong(string path) => new Song(path);

    /// <summary>
    /// Loads a sprite.
    /// </summary>
    /// <param name="path"></param>
    /// <param name="size"></param>
    /// <returns></returns>
    public Sprite LoadSprite(string path, Rectangle size) 
    {
        SupportHelper.ThrowIfUnsupportedImageType(path);
        NullHelper.IsNullThrow(size, nameof(size));

        var tex = LoadTexture(path, size);

        return new Sprite(tex, SFMLHelper.SFMLRect(size));
    }
}
