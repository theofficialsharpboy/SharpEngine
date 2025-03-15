using SharpEngine.Helpers;


namespace SharpEngine.Stream.Settings;

public class SettingsSection
{
    /// <summary>
    /// Gets the name.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Gets the value.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Initialize a new instance of <see cref="SettingsSection"/>.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="value"></param>
    public SettingsSection(string name, string value)
    {
        NullHelper.IsNullThrow(name, nameof(name));
        NullHelper.IsNullThrow(value, nameof(value));

        Name = name;
        Value = value;
    }

    /// <summary>
    /// Gets the values as a string.
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return $"{Name}={Value}";
    }

    /// <summary>
    /// Converts the value to a bool.
    /// </summary>
    /// <returns></returns>
    public bool ToBool()
    {
        return bool.Parse(Value);
    }

    /// <summary>
    /// Converts the value to a int.
    /// </summary>
    /// <returns></returns>
    public int ToInt()
    {
        return int.Parse(Value);
    }

    /// <summary>
    /// Converts the value to a double.
    /// </summary>
    /// <returns></returns>
    public double ToDouble()
    {
        return double.Parse(Value);
    }

    /// <summary>
    /// Converts the value to a long.
    /// </summary>
    /// <returns></returns>
    public long ToLong()
    {
        return long.Parse(Value);
    }

    /// <summary>
    /// Converts the value to a single.
    /// </summary>
    /// <returns></returns>
    public Single ToSingle()
    {
        return Single.Parse(Value);
    }

    /// <summary>
    /// Converts the value to a float.
    /// </summary>
    /// <returns></returns>
    public float ToFloat()
    {
        return float.Parse(Value);
    }
}
