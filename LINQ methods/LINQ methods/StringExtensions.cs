using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_methods
{
    static class StringExtensions
    {
        public static bool IsLengthEven(this string str)
        {
            return str.Length % 2 == 0;
        }
    }
}
