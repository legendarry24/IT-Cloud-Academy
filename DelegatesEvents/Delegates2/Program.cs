using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates2
{
    static class Program
    {
        public delegate bool FilterFunction(int a);

        static void Main(string[] args)
        {
            List<int> list = new List<int> { 1, 2, 3, 4, 5, 6 };
            List<int> result = list.FilterEven();
            result.Print();
            result = list.Intersect(new List<int> { 1, 5, 7, 4});
            Console.WriteLine(new string('-', 30));
            result.Print();

            FilterFunction filter = IsEven;
            result = list.Where(filter);
            Console.WriteLine(new string('-', 30));
            result.Print();

            filter = CanBeDividedByThree;
            result = list.Where(filter);
            Console.WriteLine(new string('-', 30));
            result.Print();

            //anonimus method
            filter = delegate (int item)
            {
                return item % 4 == 0;
            };

            //lambda
            filter = (item) => { return item % 2 == 0; };

            filter = item => item % 2 == 0;

            //.Net standart delegate
            Func<int, bool> f = IsEven;

            //lambda as method parameter
            result = list.Where(x => x % 4 == 0);
            Console.WriteLine(new string('-', 30));
            result.Print();

            Console.ReadKey();
        }

        static bool IsEven(int item)
        {
            return item % 2 == 0;
        }

        static bool CanBeDividedByThree(int item)
        {
            return item % 3 == 0;
        }

        public static List<int> Where(this IEnumerable<int> list, FilterFunction filter)
        {
            List<int> result = new List<int>();
            foreach (var item in list)
            {
                if (filter(item))
                {
                    result.Add(item);
                }
            }
            return result;
        }
    }
}
