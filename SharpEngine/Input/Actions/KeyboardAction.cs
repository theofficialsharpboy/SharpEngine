using SharpEngine.Helpers;
using SharpEngine.Input.Devices;
using SharpEngine.Input.States.Keyboard;

namespace SharpEngine.Input.Actions;

public class KeyboardAction : InputAction
{
    Keys[] keys;

    /// <summary>
    /// Gets the keys present.
    /// </summary>
    public Keys[] Keys => keys;

    /// <summary>
    /// Initialize a new instance of <see cref="KeyboardAction"/>
    /// </summary>
    /// <param name="keys"></param>
    public KeyboardAction(Keys[] keys)
    {
        NullHelper.IsNullThrow(keys, nameof(keys));

        this.keys = keys;
    }

    public override bool Occured(InputSystem inputSystem)
    {
        NullHelper.IsNullThrow(inputSystem, nameof(inputSystem));

        foreach (Keys key in keys)
        {
            if (IsNewPress)
            {
                if (inputSystem.FindFromType<Keyboard>().IsNewKeyDown(key))
                {
                    return true;
                }
            }
            else
            {
                if (inputSystem.FindFromType<Keyboard>().IsKeyDown(key))
                {
                    return true;
                }
            }
        }

        return false;
    }
}
