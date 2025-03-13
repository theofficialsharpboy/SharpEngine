using SharpEngine.Helpers;
using SharpEngine.Input.Devices;
using SharpEngine.Input.States.GamePad;

namespace SharpEngine.Input.Actions;

public class GamePadAction : InputAction
{
    Button[] buttons;

    /// <summary>
    /// Gets the buttons that are part of this action.
    /// </summary>
    public Button[] Buttions => buttons;

    /// <summary>
    /// Initialize a new instance of <see cref="GamePadAction"/>
    /// </summary>
    /// <param name="buttons"></param>
    public GamePadAction(Button[] buttons)
    {
        NullHelper.IsNullThrow(buttons, nameof(buttons));

        this.buttons = buttons;
    }

    public override bool Occured(InputSystem inputSystem)
    {
        foreach(var button in buttons)
        {
            var gamepad = inputSystem.FindFromType<GamePad>();
            if(IsNewPress)
            {
                if(gamepad.IsNewButtonDown(button))
                {
                    return true;
                }
            }
            else
            {
                if(gamepad.IsButtonDown(button))
                {
                    return true;
                }
            }
        }
        return false;
    }
}
