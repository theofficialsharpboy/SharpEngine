
using SharpEngine.Helpers;
using SharpEngine.Input.States.Touch;

namespace SharpEngine.Input.Devices;

public class Touch : InputDevice
{
    TouchState touchState;

    public Touch(string name) : base(name, InputIndex.One)
    {
        touchState = new ();
    }

    public override void Update() {}

    /// <summary>
    /// Is a finger on the screen.
    /// </summary>
    /// <param name="finger"></param>
    /// <returns></returns>
    public bool IsDown(TouchFinger finger) => touchState.IsDown(finger);

    /// <summary>
    /// Is a finger on the screen.
    /// </summary>
    /// <param name="fingerName"></param>
    /// <returns></returns>
    public bool IsDown(string fingerName) => IsDown(EnumHelper.Parse<TouchFinger>(fingerName));
}
