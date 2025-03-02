using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharpEngine.Graphics;

public class GraphicsContext
{
    int frameLimit;
    Resulotion resulotion;
    bool vsync;
    bool fullscreen;

    /// <summary>
    /// Gets the <see cref="Antialising"/>
    /// </summary>
    public Antialising Antialising 
    {
        get;
    }

    /// <summary>
    /// Gets the resulotion.
    /// </summary>
    public Resulotion Resulotion => resulotion;

    /// <summary>
    /// Gets the frame limit.
    /// </summary>
    public int FrameLimit 
    {
        get => frameLimit;
    }
    /// <summary>
    /// Gets a bool value whether vsyncronization is enabled.
    /// </summary>
    public bool Vsync => vsync;

    /// <summary>
    /// Gets a bool value indecating whether the window is fullscreen.
    /// </summary>
    public bool IsFullScreen => fullscreen;

    /// <summary>
    /// Gets or sets a bool indecating whether this <see cref="GraphicsContext"/> is resizable.
    /// </summary>
    public bool Resizable 
    {
        get;
        set;
    }

    /// <summary>
    /// Initalize a new instance of <see cref="GraphicsContext"/>
    /// </summary>
    /// <param name="depth"></param>
    /// <param name="stencil"></param>
    /// <param name="context"></param>
    /// <param name="resulotion"></param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    /// <exception cref="ArgumentNullException"></exception>
    public GraphicsContext(int? frameLimit, bool? vsync, bool? isFullscreen, Resulotion resulotion)
    {
        if(resulotion == null) throw new ArgumentNullException(nameof(resulotion));
        
        if(frameLimit.HasValue)
        {
            if(frameLimit < int.MinValue) throw new ArgumentOutOfRangeException(nameof(frameLimit));
            if(frameLimit > int.MaxValue) throw new ArgumentOutOfRangeException(nameof(frameLimit));
            if(frameLimit == 0) this.frameLimit = 60;
            else this.frameLimit = frameLimit.Value;
        } else throw new ArgumentNullException(nameof(frameLimit));

        if(vsync.HasValue) 
        {
            this.vsync = vsync.Value;
        } else throw new ArgumentNullException(nameof(vsync));

        if(isFullscreen.HasValue)
        {
            this.fullscreen = isFullscreen.Value;
        } else throw new ArgumentNullException(nameof(isFullscreen));
        
        this.resulotion = resulotion;
        this.Antialising = new ();
    }
}
