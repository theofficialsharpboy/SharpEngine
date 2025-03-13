using SharpEngine.Input.States.GamePad;
using SharpEngine.Input.States.Keyboard;
using SharpEngine.Input.States.Mouse;
using SharpEngine.Input.States.Touch;


namespace SharpEngine.Input.Actions;

/// <summary>
/// Represents an input action.
/// </summary>
public abstract class InputAction
{
    /// <summary>
    /// Gets or sets a bool value indecating whether this <see cref="InputAction"/> only accounts for the first press.
    /// </summary>
    /// <remarks>True; if only register 1 press; Otherwise false.</remarks>
    public bool IsNewPress
    {
        get;
        set;
    }

    /// <summary>
    /// Gets a bool value indecating whether this <see cref="InputAction"/> has occured.
    /// </summary>
    /// <param name="inputSystem"></param>
    /// <returns></returns>
    public abstract bool Occured(InputSystem inputSystem);
}
