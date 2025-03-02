using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SFML.Window;

namespace SharpEngine.Input.States.Touch;

public class TouchState
{

    public TouchState() 
    {
    }

    /// <summary>
    /// Gets a bool value indecating whether the specified <see cref="TouchFinger"/> is on the screen.
    /// </summary>
    /// <param name="finger"></param>
    /// <returns></returns>
    public bool IsDown(TouchFinger finger)
    {
        uint fingerId = finger switch 
        {
            TouchFinger.One => 1,
            TouchFinger.Two => 2,
            _ => throw new ArgumentOutOfRangeException(nameof(finger))
        };

        return SFML.Window.Touch.IsDown(fingerId);
    }
}
