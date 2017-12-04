using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    class TestGeneric<T, U, G> where T : ArgumentException where U : T where G : new()
    {

    }
}
