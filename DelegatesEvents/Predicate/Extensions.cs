using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Predicate
{
    static class Extensions
    {
        public static bool All(this List<int> list, Predicate<int> predicate)
        {
            foreach (var item in list)
            {
                if (!predicate(item))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool Any(this List<int> list, Predicate<int> predicate)
        {
            foreach (var item in list)
            {
                if (predicate(item))
                {
                    return true;
                }
            }
            return false;
        }

        public static int Count(this List<int> list, Predicate<int> predicate)
        {
            int count = 0;
            foreach (var item in list)
            {
                if (predicate(item))
                {
                    count++;
                }
            }
            return count;
        }

        public static int First(this List<int> list, Predicate<int> predicate)
        {
            
            foreach (var item in list)
            {
                if (predicate(item))
                {
                    count++;
                }
            }
            return count;
        }
    }
}
