using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionInterfaces
{
    class MyComparer<T> : IComparer<T>
    {
        public int Compare(T x, T y)
        {
            Point a = x as Point;
            Point b = y as Point;
            return 0;
        }
    }
}
