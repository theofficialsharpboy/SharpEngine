using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharpEngine.Helpers;

internal class NullHelper
{
    public static bool IsNull(object obj) 
    {
        if(obj is int)
        {
            var item = (int)obj;

            if(item < int.MinValue || item > int.MaxValue) return true;
        }
        else if(obj is string) 
        {
            var item = (string)obj;

            return string.IsNullOrWhiteSpace(item) || string.IsNullOrEmpty(item);
        }
        else 
        {
            return obj == null;
        }

        return false;
    }
    public static void IsNullThrow(object obj, string paramName) 
    {
        if(IsNull(obj)) throw new ArgumentNullException(paramName);
    }
}
