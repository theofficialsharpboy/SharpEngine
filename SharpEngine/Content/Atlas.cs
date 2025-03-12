using SFML.Graphics;
using SharpEngine.Helpers;

namespace SharpEngine.Content;

/// <summary>
/// Represents a atlas of sprites.
/// </summary>
public class Atlas
{
    int blockWidth, blockHeight, atlasCount, currentAtlasImage = 0;
    string atlasImagePath;
    List<Sprite> atlases;

    /// <summary>
    /// Initialize a new instance of <see cref="Atlas"/>
    /// </summary>
    /// <param name="atlasImagePath"></param>
    /// <param name="atlasCount"></param>
    /// <param name="blockWidth"></param>
    /// <param name="blockHeight"></param>
    public Atlas(string atlasImagePath, int atlasCount, int blockWidth, int blockHeight)
    {
        NullHelper.IsNullThrow(atlasImagePath, nameof(atlasImagePath));
        NullHelper.IsNullThrow(blockWidth, nameof(blockWidth));
        NullHelper.IsNullThrow(blockHeight, nameof(blockHeight));
        NullHelper.IsNullThrow(atlasCount, nameof(atlasCount));

        this.blockWidth = blockWidth;
        this.blockHeight = blockHeight;
        this.atlasCount = atlasCount;
        this.atlasImagePath = atlasImagePath;

        atlases = AtlasHelper.GetAtlasTexture(new Texture2D(atlasImagePath), atlasCount, blockWidth, blockHeight);
    }

    /// <summary>
    /// Gets a sprite from the atlas texture.
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public Sprite this[int index] => atlases[index];

    /// <summary>
    /// Gets the next sprite in the atlas.
    /// </summary>
    /// <returns></returns>
    public Sprite Next()
    {
        if(currentAtlasImage > atlasCount) 
            currentAtlasImage = 0;

        currentAtlasImage++;

        return atlases[currentAtlasImage];
    }

    /// <summary>
    /// Gets the previous sprite in the atlas.
    /// </summary>
    /// <returns></returns>
    public Sprite Previous()
    {
        if (currentAtlasImage < 0)
            currentAtlasImage = atlasCount;

        currentAtlasImage--;

        return atlases[currentAtlasImage];
    }
}
