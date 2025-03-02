
using SFML.Graphics;
using SharpEngine.Content;
using SharpEngine.Exceptions;
using SharpEngine.Helpers;

namespace SharpEngine.Graphics;

#nullable disable

public class SpriteBatch
{
    bool begin = false;
    GraphicsDevice graphicsDevice;
    Effect effect;
    BlendMode? blendMode;

    /// <summary>
    /// Initalize a new instance of <see cref="SpriteBatch"/>
    /// </summary>
    /// <param name="window"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public SpriteBatch(GraphicsDevice graphicsDevice) 
    {
        NullHelper.IsNullThrow(graphicsDevice, nameof(graphicsDevice));
        
        this.graphicsDevice = graphicsDevice;
        effect = null;
        blendMode = null;
    }

    /// <summary>
    /// Begin the drawing to the screen.
    /// </summary>
    /// <exception cref="SpriteBatchException"></exception>
    public void Begin(Effect effect, BlendMode? mode)
    {
        if(begin)
        {
            throw new SpriteBatchException("Begin can not be called again, untill End() has been called.");
        }
        blendMode = mode;
        this.effect = effect;
        begin = true;
    }

    /// <summary>
    /// Begin the drawing to the screen.
    /// </summary>
    public void Begin(Effect effect) 
    {
        Begin(effect, null);
    }
    
    /// <summary>
    /// Begin the drawing to the screen.
    /// </summary>
    public void Begin()
    {
        Begin(null, null);
    }

    /// <summary>
    /// End the drawing session.
    /// </summary>
    /// <exception cref="SpriteBatchException"></exception>
    public void End() 
    {
        if(!begin) 
        {
            throw new SpriteBatchException("End can not be called, untill begin has been called");
        }

        begin = false;
    }

    /// <summary>
    /// Draws text on to the screen.
    /// </summary>
    /// <param name="font"></param>
    /// <param name="text"></param>
    /// <param name="position"></param>
    /// <param name="color"></param>
    /// <param name="rotation"></param>
    /// <param name="scale"></param>
    /// <exception cref="NullReferenceException"></exception>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    /// <exception cref="SpriteBatchException"></exception>
    public void DrawString(SpriteFont font, string text, Vector2 position, Color color, float rotation, float scale) 
    {
        NullHelper.IsNullThrow(font, nameof(font));
        NullHelper.IsNullThrow(text, nameof(text));
        NullHelper.IsNullThrow(color, nameof(color));
        NullHelper.IsNullThrow(rotation, nameof(rotation));
        NullHelper.IsNullThrow(scale, nameof(scale));

        if(!begin) throw new SpriteBatchException("Begin must be called before drawing an object");

        Text textObject = new Text(text, SFMLHelper.SFMLFont(font))
        {
            FillColor = SFMLHelper.SFMLColor(color),
            Position = SFMLHelper.SFMLVector2(position),
            Rotation = rotation,
            Scale = SFMLHelper.SFMLVector2(new (scale, scale)),
            CharacterSize = (uint)font.Size,
        };

        if(blendMode.HasValue && effect != null) graphicsDevice.Draw(textObject, blendMode.Value,effect);
        else if(!blendMode.HasValue && effect != null) graphicsDevice.Draw(textObject,effect);
        else if(!blendMode.HasValue && effect == null) graphicsDevice.Draw(textObject);
        else graphicsDevice.Draw(textObject);
    }

    /// <summary>
    /// Draws text to the screen.
    /// </summary>
    /// <param name="font"></param>
    /// <param name="text"></param>
    /// <param name="position"></param>
    /// <param name="color"></param>
    /// <param name="rotation"></param>
    public void DrawString(SpriteFont font, string text, Vector2 position, Color color, float rotation) => DrawString(font, text, position, color, rotation, 1f);

    /// <summary>
    /// Draws text to the screen.
    /// </summary>
    /// <param name="font"></param>
    /// <param name="text"></param>
    /// <param name="position"></param>
    /// <param name="color"></param>
    public void DrawString(SpriteFont font, string text, Vector2 position, Color color) => DrawString(font, text, position, color, 0f, 1f);

    /// <summary>
    /// Draws a texture.
    /// </summary>
    /// <param name="texture"></param>
    /// <param name="position"></param>
    /// <param name="color"></param>
    /// <param name="rotation"></param>
    /// <param name="scale"></param>
    /// <exception cref="NullReferenceException"></exception>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    /// <exception cref="SpriteBatchException"></exception>
    public void Draw(Texture texture, Vector2 position, Color color, float rotation, float scale) 
    {
        NullHelper.IsNullThrow(texture, nameof(texture));
        NullHelper.IsNullThrow(position, nameof(position));
        NullHelper.IsNullThrow(color, nameof(color));
        NullHelper.IsNullThrow(rotation, nameof(rotation));
        NullHelper.IsNullThrow(scale, nameof(scale));
        
        if(!begin) throw new SpriteBatchException("Begin must be called before drawing.");

        Sprite sprite = new (texture);
        sprite.Position = SFMLHelper.SFMLClampToWindowSize(texture, position, SharpWindow.Instance.renderWindow);
        sprite.Color = SFMLHelper.SFMLColor(color);
        sprite.Scale = SFMLHelper.SFMLVector2(new (scale, scale));
        sprite.TextureRect =SFMLHelper.SFMLRect(new (0, 0, (int)texture.Size.X, (int)texture.Size.Y));
        sprite.Rotation = rotation;

        if(blendMode.HasValue && effect != null) graphicsDevice.Draw(sprite, blendMode.Value,effect);
        else if(!blendMode.HasValue && effect != null) graphicsDevice.Draw(sprite,effect);
        else if(!blendMode.HasValue && effect == null) graphicsDevice.Draw(sprite);
        else graphicsDevice.Draw(sprite);
    }
    
    /// <summary>
    /// Draws a texture.
    /// </summary>
    public void Draw(Texture texture, Vector2 position, Color color, float rotation) => Draw(texture, position, color, rotation, 1f);

    /// <summary>
    /// Draws a texture.
    /// </summary>
    public void Draw(Texture texture, Vector2 position, Color color) => Draw(texture, position, color, 0f, 1f);

    /// <summary>
    /// Draws a gradient onto the screen.
    /// </summary>
    /// <param name="gradient"></param>
    /// <param name="size"></param>
    /// <param name="position"></param>
    /// <param name="rotation"></param>
    /// <param name="scale"></param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public void DrawGradient(Gradient gradient, Size size, Point position, float rotation, float scale) 
    {
        NullHelper.IsNullThrow(gradient, nameof(gradient));
        NullHelper.IsNullThrow(size, nameof(size));
        NullHelper.IsNullThrow(position, nameof(position));
        NullHelper.IsNullThrow(rotation, nameof(rotation));
        NullHelper.IsNullThrow(scale, nameof(scale));

        if(!begin) throw new SpriteBatchException("Begin must be called before drawing an object");

        Image image = gradient.Direction switch
        {
            GradientDirection.Vertical => GradientHelper.CreateVerticalGradient(size.Width, size.Height, gradient.Colors.ToArray()),
            GradientDirection.Horizonal => GradientHelper.CreateHorizontalGradient(size.Width, size.Height, gradient.Colors.ToArray()),
            _ => throw new ArgumentOutOfRangeException(nameof(gradient.Direction))
        };

        var texture = new Texture2D(image);
        
        Sprite sprite = new (texture);
        sprite.Position = SFMLHelper.SFMLVector2(new (position.X, position.Y));
        sprite.TextureRect = SFMLHelper.SFMLRect(new (0, 0, size.Width, size.Height));
        sprite.Rotation = rotation;
        sprite.Scale = new SFML.System.Vector2f(scale, scale);
        sprite.Color = SFMLHelper.SFMLColor(Color.White);

        if(blendMode.HasValue && effect != null) graphicsDevice.Draw(sprite, blendMode.Value,effect);
        else if(!blendMode.HasValue && effect != null) graphicsDevice.Draw(sprite,effect);
        else if(!blendMode.HasValue && effect == null) graphicsDevice.Draw(sprite);
        else graphicsDevice.Draw(sprite);
    }

    /// <summary>
    /// Draws a gradient onto the screen.
    /// </summary>
    public void DrawGradient(Gradient gradient, Size size, Point position, float rotation) => DrawGradient(gradient, size, position, rotation, 1f);

    
    /// <summary>
    /// Draws a gradient onto the screen.
    /// </summary>
    public void DrawGradient(Gradient gradient, Size size, Point position) => DrawGradient(gradient, size, position, 0f, 1f);
    
    
    /// <summary>
    /// Draws a gradient onto the screen.
    /// </summary>
    public void DrawGradient(Gradient gradient, Rectangle rectangle) => DrawGradient(gradient, rectangle.Size, rectangle.Position, 0f, 1f);
}
