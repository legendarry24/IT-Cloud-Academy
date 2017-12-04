using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates3
{
    static class TestClass
    {
        public static void RewriteDelegate(ref MyDelegate func)
        {
            func += MyMethod;
        }

        public static void MyMethod()
        {
            Console.WriteLine("Printed");
        }
    }
}
