using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SFML.Window;

namespace SharpEngine.Input.States.GamePad;

public class GamePadState
{
    bool[] buttons;

    /// <summary>
    /// Initialize a new instance of <see cref="GamePadState"/>
    /// </summary>
    public GamePadState() 
    {
        buttons = new bool[14];
    }

    /// <summary>
    /// Update the state.
    /// </summary>
    /// <param name="index"></param>
    public void UpdateState(InputIndex index)
    {
        for(int i = 0; i < buttons.Length;i++)
        {
            buttons[i] = Joystick.IsButtonPressed((uint)index, (uint)i);
        }
    }

    /// <summary>
    /// Gets a bool value indecating whether the specified <see cref="Button"/> is down.
     /// </summary>
    /// <param name="button"></param>
    /// <returns></returns>
    public bool IsButtonDown(Button button) 
    {
        return buttons[(int)button];
    }

    /// <summary>
    /// Gets a bool value indecating whether the specified <see cref="Button"/> is up.
    /// </summary>
    /// <param name="button"></param>
    /// <returns></returns>
    public bool IsButtonUp(Button button)
    {
        return !buttons[(int)button];
    }
}
