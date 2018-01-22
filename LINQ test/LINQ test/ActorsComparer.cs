using System;
using System.Collections.Generic;

namespace LINQ_test
{
    public class ActorsComparer : IEqualityComparer<Actor>
    {
        public bool Equals(Actor x, Actor y)
        {
            return x.Name.Equals(y.Name);
        }

        public int GetHashCode(Actor obj)
        {
            return obj.Name.GetHashCode();
        }
    }
}