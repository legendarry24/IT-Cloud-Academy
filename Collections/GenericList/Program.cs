using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericList
{
    class Program
    {
        static void Main(string[] args)
        {
            MyGenericList<int> list = new MyGenericList<int>(new int[] { 1, 2, 3, 4, 5 });
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            
            MyDictionary<int, string> dictionary = new MyDictionary<int, string>(new MyKeyValuePair<int, string>[] { new MyKeyValuePair<int, string>(1, "q") , new MyKeyValuePair<int, string>(2, "w") });
            foreach (MyKeyValuePair<int, string> item in dictionary)
            {
                Console.WriteLine(item.Key + item.Value);
            }

            Console.ReadKey();
        }
    }
}
