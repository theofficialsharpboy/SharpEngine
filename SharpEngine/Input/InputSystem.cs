

using SharpEngine.Helpers;
using SharpEngine.Input.Actions;

namespace SharpEngine.Input;

public class InputSystem
{
    List<InputDevice> _devices;

    /// <summary>
    /// Gets a device from its name.
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public InputDevice this[string name]
    {
        get 
        {
            object dev = new ();
            foreach(var device in _devices)
            {
                if(device.Name == name)
                {
                    dev = device;
                }
            }
            return (InputDevice)dev;
        }
    }

    /// <summary>
    /// Initialize a new instance of <see cref="InputSystem"/>
    /// </summary>
    public InputSystem() 
    {
        _devices = new();
    }

    /// <summary>
    /// Adds a device.
    /// </summary>
    /// <param name="device"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public void Add(InputDevice device) 
    {
        if(device == null) throw new ArgumentNullException(nameof(device));

        _devices.Add(device);
    }


    /// <summary>
    /// Removes a device.
    /// </summary>
    /// <param name="device"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public void Remove(InputDevice device) 
    {
        if(device == null) throw new ArgumentNullException(nameof(device));
        _devices.Remove(device);
    }


    /// <summary>
    /// Gets a device buy its name.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="name"></param>
    /// <returns></returns>
    public T GetDevice<T>(string name) where T: InputDevice
    {
        object dev = new object();
        foreach(var device in _devices)
        {
            if(device.Name == name && device is T)
            {
                dev = (T)device;
            }
        }
        return (T)dev;
    }

    /// <summary>
    /// Finds any type of <see cref="InputDevice"/> that matchs the <typeparamref name="T"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public T FindFromType<T>() where T: InputDevice
    {
        object dev = new object();
        foreach (var device in _devices)
        {
            if (device is T)
            {
                dev = (T)device;
            }
        }
        return (T)dev;
    }

    /// <summary>
    /// Updates all current input devices.
    /// </summary>
    public void Update()
    {
        foreach(var device in _devices)
        {
            device.Update();
        }
    }
}
