using System;
using System.Collections.Generic;

namespace Delegates2
{
    static class IEnumerableExtension
    {
        public static void Print(this List<int> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }

        public static List<int> FilterEven(this IEnumerable<int> list)
        {
            List<int> result = new List<int>();
            foreach (var item in list)
            {
                if (item % 2 == 0)
                {
                    result.Add(item);
                }
            }
            return result;
        }

        public static List<int> Intersect(this List<int> listA, List<int> listB)
        {
            var result = new List<int>();

            foreach (var item in listA)
            {
                if (listB.Contains(item))
                {
                    result.Add(item);
                }
            }
            return result;            
        }

        
    }
}
