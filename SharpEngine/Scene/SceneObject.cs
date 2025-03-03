
using System.ComponentModel;
using SharpEngine.Helpers;

namespace SharpEngine.Scene;

public abstract class SceneObject
{
    /// <summary>
    /// Gets or sets the tag of this <see cref="SceneObject"/>
    /// </summary>
    public string Tag 
    {
        get;
        set;
    } = "";

    /// <summary>
    /// Gets the name of this scene object.
    /// </summary>
    public string Name 
    {
        get;
    }

    /// <summary>
    /// Initalize a new instance of <see cref="SceneObject"/>
    /// </summary>
    /// <param name="name"></param>
    public SceneObject(string name) 
    {
        NullHelper.IsNullThrow(name, nameof(name));
        this.Name = name;
    }
}
