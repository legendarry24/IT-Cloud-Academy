using System;
using System.Collections;
using System.Collections.Generic;

namespace CollectionInterfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Point(1);
            var p2 = new Point(2);
            var p3 = new Point(3);

            SortedList list = new SortedList
            {
                {p2, "2"},
                {p, "1"},
                {p3, "3"}
                //will cause ArgumentException
                //{new object(), 1 }
            };
            foreach (DictionaryEntry item in list)
            {
                Console.WriteLine(item.Value);
            }

            Dictionary<Point, int> dictionary = new Dictionary<Point, int>
            {
                {new Point(1), 1},
                {new Point(2), 2}
                //will cause ArgumentException
                //{new Point(1), 3}
            };

            List<Point> lst = new List<Point>();
            MyComparer<Point> comparerObj = new MyComparer<Point>();
            lst.Sort(comparerObj);

            MyList myList = new MyList(new string[] { "2", "3", "4", "5", "-1", "1", "4" });
            foreach (var item in myList)
            {
                Console.WriteLine(item);
            }

            AnotherList aList = new AnotherList(new string[] { "1", "3", "4", "5", "-1", "1", "4" });
            foreach (var item in aList)
            {
                Console.WriteLine(item);
            }
            // second and other loops won't work
            foreach (var item in aList)
            {
                Console.WriteLine(item);
            }

            //SecondList sList = new SecondList(new string[] { "1", "3", "4", "5", "-1", "1", "4" });
            //foreach (var item in sList)
            //{

            //}

            Console.ReadKey();
        }
    }
}
