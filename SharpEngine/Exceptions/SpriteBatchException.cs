using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharpEngine.Exceptions;

public class SpriteBatchException : Exception
{
    /// <summary>
    /// Initialize a new instance of <see cref="SpriteBatchException"/>
    /// </summary>
    /// <param name="message"></param>
    public SpriteBatchException(string message) : base(message) {}
}
