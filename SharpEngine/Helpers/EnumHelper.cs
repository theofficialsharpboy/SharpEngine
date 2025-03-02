using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharpEngine.Helpers;

internal class EnumHelper
{
    public static string[] GetNames<T>() => Enum.GetNames(typeof(T));
    public static T Parse<T>(string name) => (T)Enum.Parse(typeof(T), name);
}
