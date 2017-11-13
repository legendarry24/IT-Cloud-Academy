using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2
{
    static class MyStaticClass
    {
        private static int count;

        public static void Increment()
        {
            count++;
        }

        public static int GetCount()
        {
            return count;
        }
    }
}
