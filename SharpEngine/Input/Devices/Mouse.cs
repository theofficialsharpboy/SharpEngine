using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SharpEngine.Helpers;
using SharpEngine.Input.States.Mouse;

namespace SharpEngine.Input.Devices;
#nullable disable
public class Mouse : InputDevice
{
    MouseState current, previous;

    /// <summary>
    /// Gets the position of this <see cref="Mouse"/>
    /// </summary>
    public Vector2 Position 
    {
        get => current.GetPosition();
    }

    public Mouse(string name) : base(name, InputIndex.One)
    {
    }

    public override void Update()
    {
        previous = current;
        current = new ();
        current.UpdateStates();
    }

    /// <summary>
    /// Gets a bool value indecating weather a <see cref="MouseButton"/> is down.
    /// </summary>
    /// <param name="button"></param>
    /// <returns></returns>
    public bool IsButtonDown(MouseButton button) => current.IsMouseButtonDown(button);
    
    /// <summary>
    /// Gets a bool value indecating weather a <see cref="MouseButton"/> is down.
    /// </summary>
    public bool IsButtonDown(string buttonName) => current.IsMouseButtonDown(EnumHelper.Parse<MouseButton>(buttonName));

    
    /// <summary>
    /// Gets a bool value indecating weather a <see cref="MouseButton"/> is down.
    /// </summary>
    /// <remarks>Only registered once. </remarks>
    public bool IsNewButtonDown(MouseButton button) => current.IsMouseButtonDown(button) && !previous.IsMouseButtonDown(button);

  
    /// <summary>
    /// Gets a bool value indecating weather a <see cref="MouseButton"/> is down.
    /// </summary>
    /// <remarks>Only registered once. </remarks>
    public bool IsNewButtonDown(string buttonName) => IsNewButtonDown(EnumHelper.Parse<MouseButton>(buttonName));
}
