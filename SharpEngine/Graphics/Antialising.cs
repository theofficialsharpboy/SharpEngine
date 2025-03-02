using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharpEngine.Graphics;

public class Antialising
{
    /// <summary>
    /// Gets or sets a bool value indecating whether antialising is enabled.
    /// </summary>
    public bool Enabled 
    {
        get;
        set;
    } = false;

    /// <summary>
    /// Gets or sets the mode of anti alising.
    /// </summary>
    public AntialisingMode Mode 
    {
        get;
        set;
    } = AntialisingMode.None;

    /// <summary>
    /// Initialize a new instance of <see cref="Antialising"/>
    /// </summary>
    public Antialising() {}
}
