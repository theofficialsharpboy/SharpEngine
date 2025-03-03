using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SFML.Graphics;
using SharpEngine.Graphics;
using SharpEngine.Helpers;

namespace SharpEngine.Animation;

public class Animator
{
    private Sprite sprite;
    private Animation animation;

    /// <summary>
    /// Gets the sprite.
    /// </summary>
    public Sprite Sprite => sprite;

    /// <summary>
    /// Gets the animation.
    /// </summary>
    public Animation Animation => animation;

    /// <summary>
    /// Initialize a new instance of <see cref="Animator"/>
    /// </summary>
    /// <param name="sprite"></param>
    /// <param name="animation"></param>
    public Animator(Sprite sprite, Animation animation)
    {
        NullHelper.IsNullThrow(sprite, nameof(sprite));
        NullHelper.IsNullThrow(animation, nameof(animation));

        this.sprite = sprite;
        this.animation = animation;
    }

    /// <summary>
    /// Updates this animator.
    /// </summary>
    /// <param name="time"></param>
    public virtual void Update(Time time)
    {
        sprite.TextureRect = SFMLHelper.SFMLRect(animation.GetCurrentFrame(time.Delta));
    }


    /// <summary>
    /// Draws the animator.
    /// </summary>
    /// <param name="position"></param>
    /// <param name="color"></param>
    /// <param name="spriteBatch"></param>
    public virtual void Draw(Vector2 position, Color color, SpriteBatch spriteBatch)
    {
        NullHelper.IsNullThrow(position, nameof(position));
        NullHelper.IsNullThrow(color, nameof(color));
        NullHelper.IsNullThrow(spriteBatch, nameof(spriteBatch));

        SFMLHelper.DrawSprite(sprite, position, color);
    }
}
