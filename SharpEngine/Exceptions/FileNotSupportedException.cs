

namespace SharpEngine.Exceptions;

public class FileNotSupportedException : Exception
{
    /// <summary>
    /// Initialize a new instance of <see cref="FileNotSupportedException"/>
    /// </summary>
    /// <param name="fileName"></param>
    public FileNotSupportedException(string fileName) : base(fileName) {}
}
