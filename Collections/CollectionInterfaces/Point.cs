using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionInterfaces
{
    class Point : IComparable
    {
        int _x;
        int _y;

        public Point(int x)
        {
            _x = x;
        }

        public int CompareTo(object obj)
        {
            Point p = obj as Point;
            if (p != null)
            {
                if (p._x == _x)
                    return 0;
                else if (p._x > _x)
                    return -1;
                else
                    return 1;
            } 
            else
            {
                throw new ArgumentException("obj is not a Point");
            }
        }

        public override int GetHashCode()
        {
            return _x.GetHashCode();  
        }

        //public override bool Equals(object obj)
        //{
        //    Point p = obj as Point;

        //}
    }
}
