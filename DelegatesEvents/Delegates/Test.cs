using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    class Test
    {
        public static double AddNumbers(double a, double b)
        {
            Console.WriteLine(nameof(AddNumbers));
            return a + b;
        }
    }
}
