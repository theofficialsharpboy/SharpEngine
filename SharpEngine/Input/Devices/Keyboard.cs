
using SharpEngine.Helpers;
using SharpEngine.Input.States.Keyboard;

namespace SharpEngine.Input.Devices;

public class Keyboard : InputDevice
{
    KeyboardState[] current, previous;

    public Keyboard(string name, InputIndex index) : base(name, index)
    {
        if(index == InputIndex.Three || index == InputIndex.Four) throw new ArgumentOutOfRangeException("Keyboards can only go upto 2 players.");
        current = new KeyboardState[2];
        previous = new KeyboardState[2];
    }

    public override void Update()
    {
        for(int i = 0; i < 2; i++)
        {
            previous[i] = current[i];
            current[i] = new KeyboardState();
            current[i].UpdateState();
        }
    }

    /// <summary>
    /// Gets a bool value indecating whether a specified <see cref="Keys"/> is being pressed.
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public bool IsKeyDown(Keys key) => current[(int)Index].IsKeyDown(key);

    /// <summary>
    /// Gets a bool value indecating whether a specified <see cref="Keys"/> is being pressed.
    /// </summary>
    public bool IsKeyDown(string key) => IsKeyDown(EnumHelper.Parse<Keys>(key));

    /// <summary>
    /// Gets a bool value indecating whether a specified <see cref="Keys"/> is being pressed.
    /// </summary>
    /// <remarks> Key is only pressed once. </remarks>
    public bool IsNewKeyDown(Keys key) => IsKeyDown(key) && previous[(int)Index].IsKeyUp(key);

    /// <summary>
    /// Gets a bool value indecating whether a specified <see cref="Keys"/> is being pressed.
    /// </summary>
    /// <remarks> Key is only pressed once. </remarks>
    public bool IsNewKeyDown(string keyName) => IsNewKeyDown(EnumHelper.Parse<Keys>(keyName));

    /// <summary>
    /// Gets a bool value indecating whether a specified <see cref="Keys"/> is not being pressed.
    /// </summary>
    public bool IsKeyUp(Keys keys) => current[(int)Index].IsKeyUp(keys);

    /// <summary>
    /// Gets a bool value indecating whether a specified <see cref="Keys"/> is not being pressed.
    /// </summary>
    public bool IsKeyUp(string keyName) => IsKeyUp(EnumHelper.Parse<Keys>(keyName));
}
