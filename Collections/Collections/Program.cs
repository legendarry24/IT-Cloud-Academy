using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            //Dictionary<int, string> dictionary = new Dictionary<int, string>();
            //dictionary.Add(1, "A");
            //dictionary.Add(2, "B");
            //dictionary.Remove(1);
            //foreach (var item in dictionary)
            //{
            //    Console.WriteLine(item);
            //}

            MyList<int> list = new MyList<int>();
            list.Add(12);
            list.Add(13);

            //MyList<string> strList = new MyList<string>();
            TestGeneric<ArgumentException, ArgumentNullException, int> t = new TestGeneric<ArgumentException, ArgumentNullException, int>();

            Console.ReadKey();
        }
    }
}
