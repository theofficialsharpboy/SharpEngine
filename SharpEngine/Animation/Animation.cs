using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SharpEngine.Helpers;

namespace SharpEngine.Animation;

public class Animation
{
    AnimationFrame[] frames;
    float frameDuration;
    float enlapsedTime;
    int currentFrame;

    /// <summary>
    /// Gets the duration.
    /// </summary>
    public float Duration => frameDuration;

    /// <summary>
    /// Gets the frames.
    /// </summary>
    public AnimationFrame[] Frames => frames;

    /// <summary>
    /// Initialize a new instance of <see cref="Animation"/>
    /// </summary>
    public Animation(int frameWidth, int frameHeight, int frameCount, float frameDuration)
    {
        NullHelper.IsNullThrow(frameWidth, nameof(frameWidth));
        NullHelper.IsNullThrow(frameHeight, nameof(frameHeight));
        NullHelper.IsNullThrow(frameCount, nameof(frameCount));
        NullHelper.IsNullThrow(frameDuration, nameof(frameDuration));

        frames = new AnimationFrame[frameCount];
        for(int i = 0; i < frameCount;i++)
        {
            frames[i] = new AnimationFrame(i * frameWidth, i * frameHeight, frameWidth, frameHeight);
        }
        this.frameDuration = frameDuration;
        this.enlapsedTime = 0f;
        this.currentFrame = 0;
    }

    /// <summary>
    /// Initialize a new instance of <see cref="Animation"/>
    /// </summary>
    public Animation(Size frameSize, int frameCount, int frameDuration)
    {
        NullHelper.IsNullThrow(frameSize, nameof(frameSize));
        NullHelper.IsNullThrow(frameCount, nameof(frameCount));
        NullHelper.IsNullThrow(frameDuration, nameof(frameDuration));
        
        frames = new AnimationFrame[frameCount];
        for(int i = 0; i < frameCount;i++)
        {
            frames[i] = new AnimationFrame(i * frameSize.Width, i * frameSize.Height, frameSize.Width, frameSize.Height);
        }
        this.frameDuration = frameDuration;
        this.enlapsedTime = 0f;
        this.currentFrame = 0;
    }

    /// <summary>
    /// Gets the current frame.
    /// </summary>
    /// <param name="deltaTime"></param>
    /// <returns>The rectangle of the frame.</returns>
    public Rectangle GetCurrentFrame(float deltaTime)
    {
        enlapsedTime += deltaTime;
        if(enlapsedTime > frameDuration)
        {
            enlapsedTime -= frameDuration;
            if(currentFrame > frames.Length)
            {
                currentFrame = 0;
            }
            currentFrame = (currentFrame + 1) % frames.Length;
        }
        return new Rectangle(
            frames[currentFrame].Position.X,
            frames[currentFrame].Position.Y,
            frames[currentFrame].Size.Width,
            frames[currentFrame].Size.Height
        );
    }
}
