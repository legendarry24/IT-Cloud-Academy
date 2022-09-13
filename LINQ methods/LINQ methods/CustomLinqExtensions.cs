using System;
using System.Collections.Generic;

namespace LINQ_methods
{
    static class CustomLinqExtensions
    {
        public static IEnumerable<T> Where<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
        {
            foreach (T item in collection)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }

        public static T SingleOrDefault<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
        {
            T foundItem = default(T);
            int count = 0;

            foreach (T item in collection)
            {
                if (predicate(item))
                {
                    count++;
                    foundItem = item;
                }
            }
            
            if (count > 1)
            {
                throw new Exception();
            }

            return foundItem;
        }
    }
}