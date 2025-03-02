using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharpEngine.Input.States.Keyboard;

public class KeyboardState
{
    int keyCount = (int)Keys.KeyCount;
    bool[] pressedKeys;

    /// <summary>
    /// Initialize a new instance of <see cref="KeyboardState"/>
    /// </summary>
    public KeyboardState() 
    {
        pressedKeys = new bool[keyCount];
    }

    /// <summary>
    /// Update this state.
    /// </summary>
    public void UpdateState() 
    {
        for(int i = 0; i < pressedKeys.Length;i++) 
        {
            pressedKeys[i] = SFML.Window.Keyboard.IsKeyPressed((SFML.Window.Keyboard.Key)i);
        }
    }
    
    /// <summary>
    /// Gets a bool value indecating whether the specified <see cref="Key"/> is pressed.
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public bool IsKeyDown(Keys key) =>pressedKeys[(int)key];

    /// <summary>
    /// Gets a bool value indecating whether the specified <see cref="Key"/> is up.
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public bool IsKeyUp(Keys key) => !pressedKeys[(int)key];
}
