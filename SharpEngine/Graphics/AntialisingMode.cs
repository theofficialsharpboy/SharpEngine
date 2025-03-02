using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharpEngine.Graphics;

public enum AntialisingMode
{
    MSAA_2 = 2,
    MSAA_4 = 4,
    MSAA_6 = 6,
    MSAA_8 = 8,

    None   = 0xff,
}
