using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharpEngine;

public class SharpWindowFrameInfo
{
    /// <summary>
    /// Gets the frame latency.
    /// </summary>
    public double FrameLatency 
    {
        get => 1000.0d / FramesPerSecond;
    }

    /// <summary>
    /// Gets the frame per second.
    /// </summary>
    public double FramesPerSecond
    {
        get;
        private set;
    }

    /// <summary>
    /// Gets the frame count.
    /// </summary>
    public int FrameCount 
    {
        get;
        private set;
    }
    
    /// <summary>
    /// Initialize a new instance of <see cref="SharpWindowFrameInfo"/>
    /// </summary>
    public SharpWindowFrameInfo() 
    {
    }

    internal void UpdateFrames(double fps, int frameCount)
    {
        FramesPerSecond = fps;
        FrameCount = frameCount;
    }
}
