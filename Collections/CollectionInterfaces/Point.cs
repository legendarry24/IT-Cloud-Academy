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
            X = x;
        }

        public int X
        {
            get
            {
                return _x;
            }

            set
            {
                _x = value;
            }
        }

        /// <summary>
        /// implementation of the interface IComparable&lt;Point&gt;
        /// </summary>
        //public int CompareTo(Point other)
        //{
        //    return _x.CompareTo(other._x);
        //}

        /// <summary>
        /// implementation of the interface IComparable
        /// </summary>
        public int CompareTo(object obj)
        {
            Point p = obj as Point;
            if (p != null)
            {
                if (p.X == X)
                    return 0;
                if (p.X > X)
                    return -1;
                else
                    return 1;
            }            
            else
            {
                throw new ArgumentException("obj is not a Point");
            }
        }

        public override bool Equals(object obj)
        {
            Point p = obj as Point;
            return X.Equals(p.X);
        }

        public override int GetHashCode()
        {
            return X.GetHashCode();
        }
    }
}
