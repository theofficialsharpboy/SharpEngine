
using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SharpEngine.Content;
using SharpEngine.Content.Media;

namespace SharpEngine.Helpers;

internal static class SFMLHelper
{
    public static IntRect SFMLRect(Rectangle rect) => new (rect.Left, rect.Top, rect.Width, rect.Height);
    public static Vector2f SFMLVector2(Vector2 vect) => new (vect.X, vect.Y);
    public static SFML.Graphics.Color SFMLColor(Color color) => new SFML.Graphics.Color((byte)color.R, (byte)color.G, (byte)color.B, (byte)color.A);
    public static SFML.Graphics.Font SFMLFont(SpriteFont font) => new (font.Path);
    public static Vector2f SFMLClampToWindowSize(Texture texture, Vector2 position, RenderWindow window) 
    {
        return new Vector2f(
              Math.Clamp(position.X, 0, window.Size.X - texture.Size.X),
              Math.Clamp(position.Y, 0, window.Size.Y - texture.Size.Y)
        );
    }

    public static View SFMLView(Rectangle rectangle) => new (new FloatRect(
        rectangle.Left,
        rectangle.Top,
        rectangle.Width,
        rectangle.Height
    ));

    public static Shader SFMLShader(Effect effect) => new Shader(
        effect.VertexPath,
        effect.GeometryPath,
        effect.FragPath
    );

    public static SoundBuffer ConvertSoundEffectToBuffer(SoundEffect effect)
    {
        var bytes = File.ReadAllBytes(effect.Path);
        return new SoundBuffer(bytes);
    }

    
    public static SoundBuffer ConvertSongToBuffer(Song song)
    {
        var bytes = File.ReadAllBytes(song.Path);
        return new SoundBuffer(bytes);
    }

    public static void DrawSprite(Sprite sprite, Vector2 position, Color color) 
    {
        sprite.Position = SFMLVector2(position);
        sprite.Color = SFMLColor(color);
        SharpWindow.Instance.renderWindow.Draw(sprite);
    }
}
