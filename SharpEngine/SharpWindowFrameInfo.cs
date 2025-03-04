using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharpEngine;

public class SharpWindowFrameInfo
{
    private double _totalframes;
    private double _periodCount;
    List<double> _fpsHistory = new();
    double _onePercentLowFps = 0;

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
    /// Gets the average.
    /// </summary>
    public double AverageFramesPerSecond
    {
        get => _totalframes / _periodCount;
    }

    /// <summary>
    /// Gets the 1% lows.
    /// </summary>
    public double OnePercentLowFramesPerSecond
    {
        get => _onePercentLowFps;
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

        _totalframes += fps;
        _periodCount++;

        _fpsHistory.Add(fps);

        if(_fpsHistory.Count >= 100)
        {
            List<double> sortedFPS = _fpsHistory.ToList();
            int lowIndex = (int)(_fpsHistory.Count * 0.01f);

            _onePercentLowFps = sortedFPS[lowIndex];
        }
    }
}
