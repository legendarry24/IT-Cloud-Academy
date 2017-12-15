using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    class TestGeneric<T, U, G> where T : ArgumentException, new() where U : T where G : new()
    {
        public void Test<F> () where F : IEnumerable
        { }
    }
}
