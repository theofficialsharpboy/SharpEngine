
using SharpEngine.Helpers;
using SharpEngine.Input.States.GamePad;

namespace SharpEngine.Input.Devices;

public class GamePad : InputDevice
{
    GamePadState[] current, previous;

    public GamePad(string name, InputIndex index) : base(name, index) 
    {
        current = new GamePadState[4];
        previous = new GamePadState[4];
    }

    public override void Update()
    {
        for(int i = 0; i < 4; i++)
        {
            previous[i] = current[i];
            current[i] = new GamePadState();
            current[i].UpdateState(Index);
        }
    }

    /// <summary>
    /// Gets a bool value indecating whether the specified <see cref="Button"/> is pressed.
    /// </summary>
    public bool IsButtonDown(Button button) => current[(int)Index].IsButtonDown(button);
    
    /// <summary>
    /// Gets a bool value indecating whether the specified <see cref="Button"/> is pressed.
    /// </summary>
    public bool IsButtonDown(string buttonName) => IsButtonDown(EnumHelper.Parse<Button>(buttonName));

    /// <summary>
    /// Gets a bool value indecating whether the specified <see cref="Button"/> is pressed.
    /// </summary>
    /// <remarks> Only registered once. </remarks>
    public bool IsNewButtonDown(Button button) => current[(int)Index].IsButtonDown(button) && previous[(int)Index].IsButtonUp(button);

    /// <summary>
    /// Gets a bool value indecating whether the specified <see cref="Button"/> is pressed.
    /// </summary>
    /// <remarks> Only registered once. </remarks>
    public bool IsNewButtonDown(string buttonName) => IsNewButtonDown(EnumHelper.Parse<Button>(buttonName));
   
    /// <summary>
    /// Gets a bool value indecating whether the specified <see cref="Button"/> is released.
    /// </summary>
    public bool IsButtonUp(Button button) => current[(int)Index].IsButtonUp(button);

    /// <summary>
    /// Gets a bool value indecating whether the specified <see cref="Button"/> is released.
    /// </summary>
    public bool IsButtonUp(string buttonName) => current[(int)Index].IsButtonUp(EnumHelper.Parse<Button>(buttonName));
}
