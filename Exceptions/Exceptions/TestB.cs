using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    class TestB
    {
        public void TestEx()
        {
            var test = new TestA();
            test.TestEx();
        }
    }
}
