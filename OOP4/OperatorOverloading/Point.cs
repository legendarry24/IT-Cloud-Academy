using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorOverloading
{
    class Point
    {
        public double X { get; set; }

        public double Y { get; set; }

        public bool IsDrawed { get; set; }

        public static Point operator +(Point p1, Point p2)
        {
            return new Point
            {
                X = p1.X + p2.X,
                Y = p1.Y + p2.Y
            };
        }

        public static Point operator -(Point p1, Point p2)
        {
            return new Point
            {
                X = p1.X - p2.X,
                Y = p1.Y - p2.Y
            };
        }

        public static Point operator ++(Point p)
        {
            p.X++;
            p.Y++;
            return p;    
        }

        public static bool operator >(Point p1, Point p2)
        {
            return p1.X > p2.X && p1.Y > p2.Y;
        }

        public static bool operator <(Point p1, Point p2)
        {
            return p1.X < p2.X && p1.Y < p2.Y;
        }

        public static bool operator true(Point p)
        {
            return p.IsDrawed;
        }

        public static bool operator false(Point p)
        {
            return !p.IsDrawed;
        }

        public static implicit operator double(Point p)
        {
            return Math.Sqrt(Math.Pow(p.Y, 2) - Math.Pow(p.X, 2));
        }

        public static explicit operator float (Point p)
        {
            return (float)Math.Sqrt(Math.Pow(p.Y, 2) - Math.Pow(p.X, 2));
        }

        public override string ToString()
        {
            return $"({X};{Y})";
        }
    }
}
