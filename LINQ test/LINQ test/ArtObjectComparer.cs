using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_test
{
    class ArtObjectsComparer : IEqualityComparer<ArtObject>
    {
        public bool Equals(ArtObject x, ArtObject y)
        {
            return x.Author.Equals(y.Author) &&
                   x.Name.Equals(y.Name) &&
                   x.Year.Equals(y.Year); 
        }

        public int GetHashCode(ArtObject obj)
        {
            return obj.Author.GetHashCode() ^
                   obj.Year.GetHashCode() ^
                   obj.Author.GetHashCode();
        }
    }
}
