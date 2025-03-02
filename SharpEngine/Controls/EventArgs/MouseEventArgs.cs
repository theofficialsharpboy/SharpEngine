using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharpEngine.Controls.EventArgs;

public class MouseEventArgs
{
    /// <summary>
    /// Gets the position.
    /// </summary>
    public Point Position
    {
        get;
    }

    /// <summary>
    /// Initialize a new instance of <see cref="MouseEventArgs"/>
    /// </summary>
    /// <param name="pos-ition"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public MouseEventArgs(Point position) 
    {
        if(position == null) throw new ArgumentNullException(nameof(position));

        this.Position = position;
    }
}
