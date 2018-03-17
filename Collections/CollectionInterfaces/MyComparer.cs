using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionInterfaces
{
    class MyComparer<T> : IComparer<Point>
    {
        public int Compare(Point x, Point y)
        {
            return x.X.CompareTo(y.X);
        }
    }
}
