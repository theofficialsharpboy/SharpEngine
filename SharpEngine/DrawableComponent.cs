using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharpEngine;

public class DrawableComponent
{
    SharpWindow _windowEngine;

    /// <summary>
    /// Gets the window.
    /// </summary>
    public SharpWindow Window {
        get => _windowEngine;
    }

    /// <summary>
    /// Initialize a new instance of <see cref="DrawableComponent"/>
    /// </summary>
    /// <param name="window"></param>
    /// <exception cref="ArgumentNullException"></exception>
    protected DrawableComponent(SharpWindow window) 
    {
        if(window == null) throw new ArgumentNullException(nameof(window));

        this._windowEngine = window;
    }

    /// <summary>
    /// Raised when updating.
    /// </summary>
    /// <param name="time"></param>
    public virtual void Update(Time time){}

    /// <summary>
    /// Raised when drawing.
    /// </summary>
    /// <param name="time"></param>
    public virtual void Draw(Time time){}

    /// <summary>
    /// Raised when asking to load all content.
    /// </summary>
    public virtual void Activate(){}

    /// <summary>
    /// Raised when all resources, should be unloaded.
    /// and all objects should be disposed.
    /// </summary>
    public virtual void Deactivate() {}
}
