using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_test
{
    class Program
    {       
        static void Main(string[] args)
        {
            var data = new List<object>
            {
                "Hello",
                new Book
                {
                    Author = "Terry Pratchett",
                    Name = "Guards! Guards!",
                    Pages = 810
                },
                new List<int> { 4, 6, 8, 2 },
                new string[] { "Hello inside array" },
                new Film
                {
                    Author = "Martin Scorsese",
                    Name = "The Departed",
                    Actors = new List<Actor>
                    {
                        new Actor{ Name = "Jack Nickolson", Birthdate = new DateTime(1937, 4, 22) },
                        new Actor { Name = "Leonardo DiCaprio", Birthdate = new DateTime(1974, 11, 11) },
                        new Actor { Name = "Matt Damon", Birthdate = new DateTime(1970, 8, 10) }
                    }
                },
                new Film
                {
                    Author = "Gus Van Sant",
                    Name = "Good Will Hunting",
                    Actors = new List<Actor>
                    {
                        new Actor { Name = "Matt Damon", Birthdate = new DateTime(1970, 8, 10) },
                        new Actor { Name = "Robin Williams", Birthdate = new DateTime(1951, 8, 11) },
                    }
                },
                new Book
                {
                    Author = "Stephen King",
                    Name = "Finders Keepers",
                    Pages = 200
                },
                "Leonardo DiCaprio"
            };
            var books = data.OfType<Book>().ToList();
            var films = data.OfType<Film>().ToList();
            var artObjects = data.OfType<ArtObject>().ToList();
            //var artObjects = books.Distinct(new ArtObjectsComparer()).ToList();

            var actors = data.OfType<Film>()
                .SelectMany(x => x.Actors)
                .ToList();

            foreach (var item in actors)
            {
                //Console.WriteLine(item.Name);
            }

            var query = data.Except(data.OfType<ArtObject>()).ToList();

            foreach (var item in query)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }
    }
}
