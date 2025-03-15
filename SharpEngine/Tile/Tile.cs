using SFML.Graphics;
using SharpEngine.Content;
using SharpEngine.Extensions;
using SharpEngine.Graphics;
using SharpEngine.Helpers;

namespace SharpEngine.Tile;

public class Tile
{
    private Rectangle _rectangle;
    private Vector2 _position;
    private bool _isCollidable;
    private Sprite _sprite;
    private Color _color = Color.White;
    private TileTag _tag;

    /// <summary>
    /// Gets or sets the tag of this tile.
    /// </summary>
    /// <remarks>Tag is used for parsers.</remarks>
    public TileTag Tag
    {
        get => _tag;
        set => _tag = value;
    }

    /// <summary>
    /// Gets the bounds.
    /// </summary>
    public Rectangle Bounds
    {
        get { return _rectangle; }
    }

    /// <summary>
    /// Gets or sets the position.
    /// </summary>
    public Vector2 Position
    {
        get => _position;
        set => _position = value;
    }

    /// <summary>
    /// Gets or sets whether this <see cref="Tile"/> is collidable.
    /// </summary>
    public bool IsCollidable
    {
        get => _isCollidable;
        set => _isCollidable = value;
    }

    /// <summary>
    /// Gets or sets the color of this tile.
    /// </summary>
    public Color TileColor
    {
        get => _color;
        set => _color = value;
    }

    /// <summary>
    /// Initialize a new instance of <see cref="Tile"/>
    /// </summary>
    /// <param name="tile"></param>
    /// <param name="position"></param>
    /// <param name="bounds"></param>
    /// <param name="isCollidable"></param>
    public Tile(Texture2D tile, Vector2 position, Rectangle bounds, bool isCollidable)
    {
        NullHelper.IsNullThrow(tile, nameof(tile));
        NullHelper.IsNullThrow(position, nameof(position));
        NullHelper.IsNullThrow(bounds, nameof(bounds));

        _position = position;
        _isCollidable = isCollidable;
        _rectangle = bounds;

        _sprite = new Sprite(tile);
        _sprite.Position = SFMLHelper.SFMLVector2(position);
        _sprite.TextureRect = SFMLHelper.SFMLRect(bounds);
    }

    /// <summary>
    /// Draws this tile.
    /// </summary>
    /// <param name="color"></param>
    public void Draw(SpriteBatch spriteBatch)
    {
        NullHelper.IsNullThrow(spriteBatch, nameof(spriteBatch));

        spriteBatch.DrawSprite(_sprite, _position, _rectangle, _color);
    }
}
