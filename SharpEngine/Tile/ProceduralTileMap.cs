using SharpEngine.Content;

namespace SharpEngine.Tile;

/// <summary>
/// Represents a very basic procedural tilemap.
/// </summary>
public class ProceduralTileMap : TileMap
{
    public ProceduralTileMap(int width, int height, int tileWidth, int tileHeight, Texture2D texture) : base(width, height, tileWidth, tileHeight, texture)
    {
    }

    protected override void GenerateTileMap()
    {
        for(int x = 0; x < Width; x++)
        {
            for(int y = 0; y < Height; y++)
            {
                Rectangle rectangle = new Rectangle(0, 0, TileWidth, TileHeight);
                Tiles[x, y] = new Tile(this.TileSetTexture, new Vector2(x * TileWidth, y * TileHeight), rectangle, false);
            }
        }
    }
}
