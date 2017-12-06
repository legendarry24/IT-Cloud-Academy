using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionInterfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Point(1);
            var p2 = new Point(2);
            var p3 = new Point(3);

            SortedList list = new SortedList();
            list.Add(p2, "2");
            list.Add(p, "1");
            list.Add(p3, "3");
            //Console.WriteLine(list.Count); 

            List<Point> lst = new List<Point>();
            MyComparer<Point> comparerObj = new MyComparer<Point>();
            lst.Sort(comparerObj);

            MyList myList = new MyList(new string[] { "1", "3", "4", "5", "-1", "1", "4" });
            foreach (var item in myList)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
    }
}
