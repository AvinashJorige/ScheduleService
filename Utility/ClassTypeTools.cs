using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public static class ClassTypeTools
    {
        public static T ParseOrDefault<T>(this string value)
        {
            return ReferenceEquals(value, null)
                 ? default(T) : (T)Convert.ChangeType(value, typeof(T));
        }
    }
}
