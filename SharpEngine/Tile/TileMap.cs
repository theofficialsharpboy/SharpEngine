using SharpEngine.Content;
using SharpEngine.Graphics;
using SharpEngine.Helpers;

namespace SharpEngine.Tile;

/// <summary>
/// Represents a abstract class, that gives you the functionality of a tilemap, but the generation of the map is up to you.
/// </summary>
public abstract class TileMap
{
    private Tile[,] tiles;
    private int width, height, tileWidth, tileHeight;
    private Texture2D texture;

    /// <summary>
    /// Gets the texture.
    /// </summary>
    protected Texture2D TileSetTexture => texture;

    /// <summary>
    /// Gets the tiles.
    /// </summary>
    protected Tile[,] Tiles => tiles;

    /// <summary>
    /// Gets the width of this map.
    /// </summary>
    public int Width => width;

    /// <summary>
    /// Gets the height of this map.
    /// </summary>
    public int Height => height;

    /// <summary>
    /// Gets the tile width of the tiles.
    /// </summary>
    public int TileWidth => tileWidth;

    /// <summary>
    /// Gets the tile height of the tiles.
    /// </summary>
    public int TileHeight => tileHeight;


    /// <summary>
    /// Initialize a new instance of <see cref="TileMap"/>
    /// </summary>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <param name="tileWidth"></param>
    /// <param name="tileHeight"></param>
    /// <param name="texture"></param>
    public TileMap(int width, int height, int tileWidth, int tileHeight, Texture2D texture)
    {
        NullHelper.IsNullThrow(texture, nameof(texture));
        NullHelper.IsNullThrow(width, nameof(width));
        NullHelper.IsNullThrow(height, nameof(height));
        NullHelper.IsNullThrow(tileWidth, nameof(tileWidth));
        NullHelper.IsNullThrow(tileHeight, nameof(tileHeight));

        this.width = width;
        this.height = height;
        this.tileWidth = tileWidth;
        this.tileHeight = tileHeight;
        this.texture = texture;
        tiles = new Tile[width, height];

        GenerateTileMap();
    }

    /// <summary>
    /// Generate the tiles map for this <see cref="TileMap"/>
    /// </summary>
    protected abstract void GenerateTileMap();

    /// <summary>
    /// Gets a bool value indicating whether a specified collidable <see cref="Tile"/> collides with this <see cref="ICollidable"/>
    /// </summary>
    /// <param name="collidable">The <see cref="ICollidable"/></param>
    /// <returns></returns>
    public bool CollidesWith(ICollidable collidable)
    {
        NullHelper.IsNullThrow(collidable, nameof(collidable));
        foreach (var tile in tiles)
        {
            if (tile.IsCollidable && collidable.Bounds.InteractWith(tile.Bounds))
            {
                return true;
            }
        }
        return false;
    } 

    /// <summary>
    /// Draws all the tiles.
    /// </summary>
    /// <param name="color"></param>
    public void Draw(SpriteBatch spriteBatch)
    {
        NullHelper.IsNullThrow(spriteBatch, nameof(spriteBatch));

        spriteBatch.Begin();
        foreach(var tile in tiles)
        {
            tile.Draw(spriteBatch);
        }
        spriteBatch.End();
    }
}
