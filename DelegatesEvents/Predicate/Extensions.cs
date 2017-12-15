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
            int count = 0;
            foreach (var item in list)
            {
                if (predicate(item))
                {
                    return count;
                }
                else
                {
                    count++;
                }
            }
            throw new FormatException();
        }

        public static int FirstOrDefault(this List<int> list, Predicate<int> predicate)
        {
            int count = 0;
            foreach (var item in list)
            {
                if (predicate(item))
                {
                    return count;
                }
                else
                {
                    count++;
                }
            }
            return -1;
        }

        public static int Last(this List<int> list, Predicate<int> predicate)
        {
            int count = list.Count - 1;
            for (int i = count; i >= 0; i--)
            {
                if (predicate(list[i]))
                {
                    return count;
                }
                else
                {
                    count--;
                }
            }
            throw new FormatException();
        }

        public static int LastOrDefault(this List<int> list, Predicate<int> predicate)
        {
            int count = list.Count - 1;
            for (int i = count; i >= 0; i--)
            {
                if (predicate(list[i]))
                {
                    return count;
                }
                else
                {
                    count--;
                }
            }
            return -1;
        }
    }
}
