using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharpEngine.Input.States.Touch;

public enum TouchFinger
{
    /// <summary>
    /// One finger is touching the screen.
    /// </summary>
    One    = 0x1,

    /// <summary>
    /// Two fingers are touching the screen.
    /// </summary>
    Two    = 0x2,
}
