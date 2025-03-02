

namespace SharpEngine.Exceptions;

public class ContentException : Exception
{
    /// <summary>
    /// Initialize a new instance of <see cref="ContentException"/>
    /// </summary>
    /// <param name="message"></param>
    public ContentException(string message) : base(message) {}
}
