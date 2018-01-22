using System.Collections.Generic;

namespace LINQ_test
{
    class Film : ArtObject
    {
        public int Length { get; set; }
        public IEnumerable<Actor> Actors { get; set; }
    }
}
