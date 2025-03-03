using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SFML.Graphics;
using SharpEngine.Content;
using SharpEngine.Graphics;
using SharpEngine.Helpers;

namespace SharpEngine.Animation.Sprites;

public class SpriteSheet
{
    List<SpriteSheetEntry> entries;
    int maxFrames = 0;
    float animationSpeed = 1f;
    int currentAnimationTime = 0;
    int currentFrame = 0;

    /// <summary>
    /// Gets the name of this sprite sheet.
    /// </summary>
    public string Name {get;}

    /// <summary>
    /// Gets the texture of all the sprites.
    /// </summary>
    public Texture2D Texture {get;}

    /// <summary>
    /// Where do you wont to display this spreadsheet.
    /// </summary>
    public Vector2 Position {get;}


    /// <summary>
    /// Initialize a new instance of <see cref="SpriteSheet"/>
    /// </summary>
    /// <param name="name"></param>
    public SpriteSheet(string name, Texture2D texture, int maxFrames, float animationSpeed, Vector2 position) 
    {
        NullHelper.IsNullThrow(name, nameof(name));
        NullHelper.IsNullThrow(texture, nameof(texture));
        NullHelper.IsNullThrow(maxFrames, nameof(maxFrames));
        NullHelper.IsNullThrow(animationSpeed, nameof(animationSpeed));
        NullHelper.IsNullThrow(position, nameof(position));

        this.Texture = texture;
        this.Name = name;
        this.maxFrames = maxFrames;
        this.animationSpeed = animationSpeed;
        this.Position = position;
        this.entries = new ();
    }

    /// <summary>
    /// Adds a entry.
    /// </summary>
    /// <param name="entry"></param>
    public void Add(SpriteSheetEntry entry) 
    {
        NullHelper.IsNullThrow(entry, nameof(entry));

        if(entries.Count > maxFrames)
        {
            return;
        }

        this.entries.Add(entry);
    }

    /// <summary>
    /// Removes an entry.
    /// </summary>
    /// <param name="entry"></param>
    public void Remove(SpriteSheetEntry entry) 
    {
        NullHelper.IsNullThrow(entry, nameof(entry));

        this.entries.Add(entry);
    }

    /// <summary>
    /// Draws this spritesheet.
    /// </summary>
    /// <param name="time"></param>
    public void Draw(Time time) 
    {
        currentAnimationTime += (int)time.Enlapsed.TotalSeconds;
        Sprite sprite = new Sprite(this.Texture);
        
        if(currentAnimationTime > animationSpeed) 
        {
            if(currentFrame > entries.Count)
            {
                currentFrame = 0;
            }
            currentFrame++;
        }

        var frame = entries[currentFrame];

        if(NullHelper.IsNull(frame)) return;

        Rectangle rect = new Rectangle(
            frame.Position.X,
            frame.Position.Y,
            frame.Width,
            frame.Height
        );

        sprite.TextureRect = SFMLHelper.SFMLRect(rect);

        SFMLHelper.DrawSprite(sprite, Position, Color.White);
    }
}
