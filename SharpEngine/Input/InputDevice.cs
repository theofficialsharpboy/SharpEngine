
namespace SharpEngine.Input;

public abstract class InputDevice
{
    /// <summary>
    /// Gets the name.
    /// </summary>
    public string Name {get;}

    /// <summary>
    /// Gets the index.
    /// </summary>
    public InputIndex Index {get;}
    
    /// <summary>
    /// Initialize a new instance of <see cref="InputDevice"/>
    /// </summary>
    /// <param name="name"></param>
    /// <param name="index"></param>
    /// <exception cref="NullReferenceException"></exception>
    /// <exception cref="ArgumentNullException"></exception>
    public InputDevice(string name, InputIndex? index) 
    {
        if(string.IsNullOrWhiteSpace(name)) throw new NullReferenceException("name");
        if(!index.HasValue) throw new ArgumentNullException(nameof(index));

        this.Name  = name;
        this.Index = index.Value;
    }

    /// <summary>
    /// Update this input.
    /// </summary>
    public abstract void Update();
}
