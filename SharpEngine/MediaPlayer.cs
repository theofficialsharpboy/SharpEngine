using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SFML.Audio;
using SharpEngine.Content.Media;
using SharpEngine.Helpers;

namespace SharpEngine;

public class MediaPlayer
{
    /// <summary>
    /// Gets the volume.
    /// </summary>
    public float Volume {get;set;}

    /// <summary>
    /// Gets the pitch.
    /// </summary>
    public float Pitch {get;set;}


    /// <summary>
    /// Initialize a new instance of <see cref="MediaPlayer"/>
    /// </summary>
    public MediaPlayer() 
    {
        Volume = 1f;
        Pitch = 0.5f;
    }

    /// <summary>
    /// Plays a song.
    /// </summary>
    /// <param name="song"></param>
    public void PlaySong(Song song)
    {
        NullHelper.IsNullThrow(song, nameof(song));

        Music sound = new (File.ReadAllBytes(song.Path));
        sound.Loop = song.Loop;
        sound.Volume = this.Volume;
        sound.Pitch = this.Pitch;
        sound.Play();
    }

    /// <summary>
    /// Plays a sound effect.
    /// </summary>
    /// <param name="effect"></param>
    public void Play(SoundEffect effect)
    {
        NullHelper.IsNullThrow(effect, nameof(effect));

        var buffer = SFMLHelper.ConvertSoundEffectToBuffer(effect);
        Sound sound = new (buffer);
        sound.Loop = false;
        sound.Volume = Volume;
        sound.Pitch = Pitch;

        sound.Play();
    }
}
