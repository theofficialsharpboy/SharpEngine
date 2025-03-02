using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharpEngine.Controls.Exceptions;

public class ControlException : Exception
{
    /// <summary>
    /// Initialize a new instance of <see cref="ControlException"/>
    /// </summary>
    /// <param name="message"></param>
    public ControlException(string message) : base(message){}
}
