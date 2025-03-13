using SharpEngine.Helpers;
using SharpEngine.Input.Devices;
using SharpEngine.Input.States.Touch;

namespace SharpEngine.Input.Actions;

public class TouchAction : InputAction
{
    TouchFinger[] fingers;

    /// <summary>
    /// Gets the fingers that are involved in the touch action.
    /// </summary>
    public TouchFinger[] Fingers => fingers;

    /// <summary>
    /// Initialize a new instance of <see cref="TouchAction"/>
    /// </summary>
    /// <param name="fingers"></param>
    public TouchAction(TouchFinger[] fingers)
    {
        NullHelper.IsNullThrow(fingers, nameof(fingers));

        this.fingers = fingers;
    }

    public override bool Occured(InputSystem inputSystem)
    {
        foreach(var finger in fingers)
        {
            if(IsNewPress || !IsNewPress)
            {
                var touch = inputSystem.FindFromType<Touch>();

                if(touch.IsDown(finger))
                {
                    return true;
                }
            }
        }
        return false;
    }
}
