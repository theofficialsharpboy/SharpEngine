using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SharpEngine.Input.States.Keyboard;

namespace SharpEngine.Controls.EventArgs;

public class KeyEventArgs
{
    /// <summary>
    /// Gets the key.
    /// </summary>
    public Keys Key
    {
        get;
    }

    /// <summary>
    /// Gets the keyCode.
    /// </summary>
    public int KeyCode => (int)Key;

    /// <summary>
    /// Initialize a new instance of <see cref="KeyEventArgs"/>
    /// </summary>
    /// <param name="key"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public KeyEventArgs(Keys? key)
    {
        if(!key.HasValue) throw new ArgumentNullException(nameof(key));

        this.Key = key.Value;
    }
}
