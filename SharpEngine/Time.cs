
namespace SharpEngine;

public class Time
{
    float deltaTime, timeScale;
    TimeSpan enlapsed, total;

    /// <summary>
    /// Gets the delta time.
    /// </summary>
    public float Delta
    {
        get => deltaTime * timeScale;
        internal set => deltaTime = value;
    }

    /// <summary>
    /// Gets the time scale.
    /// </summary>
    public float Scale 
    {
        get => timeScale;
        internal set => timeScale = value;
    }

    /// <summary>
    /// Gets the enlapsed time.
    /// </summary>
    public TimeSpan Enlapsed
    {
        get => enlapsed;
        internal set => enlapsed = value;
    }

    /// <summary>
    /// Gets the total amount of time.
    /// </summary>
    public TimeSpan Total 
    {
        get => total;
        internal set => total = value;
    }

    /// <summary>
    /// Initialize a new instance of <see cref="Time"/>
    /// </summary>
    public Time() 
    {
    }
}
