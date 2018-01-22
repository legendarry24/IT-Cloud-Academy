using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

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
                        new Actor { Name = "Jack Nickolson", Birthdate = new DateTime(1937, 4, 22) },
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
                        new Actor { Name = "Robin Williams", Birthdate = new DateTime(1951, 8, 11) }
                    }
                },
                new Book
                {
                    Author = "Stephen King",
                    Name = "The Shining",
                    Pages = 447
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


            //1. Output all elements excepting ArtObjects

            var elements = data.Except(data.OfType<ArtObject>()).ToList();

            foreach (var item in elements)
            {
                Console.WriteLine(item);
            }

            //2. Output all actors names

            var actors = data.OfType<Film>()
                .SelectMany(x => x.Actors)
                .Distinct(new ActorsComparer())
                .ToList();

            foreach (var actor in actors)
            {
                Console.WriteLine(actor.Name);
            }

            //3. Output number of actors born in august

            //var august = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(8);

            var bornInAugust = actors
                .Where(actor => actor.Birthdate.Month == 8)
                .ToList();

            foreach (var actor in bornInAugust)
            {
                Console.WriteLine(actor.Name);
            }

            //4. Output two oldest actors names

            var oldestActors = actors
                .OrderBy(actor => actor.Birthdate)
                .Take(2)
                .ToList();

            foreach (var actor in oldestActors)
            {
                Console.WriteLine(actor.Name);
            }

            //5. Output number of books per authors

            var numberOfBooks = books
                .GroupBy(book => book.Author)
                .Select(group => new
                {
                    AuthorName = group.Key,
                    Count = group.Count()
                })
                .ToList();
                

            foreach (var book in numberOfBooks)
            {
                Console.WriteLine($"Author: {book.AuthorName}, number of books: {book.Count}");
            }

            //6. Output number of books per authors and films per director

            var numberOfFilms = films
                .GroupBy(film => film.Author)
                .Select(group => new
                {
                    Director = group.Key,
                    Count = group.Count()
                })
                .ToList();

            foreach (var film in numberOfFilms)
            {
                Console.WriteLine($"Director: {film.Director}, number of films: {film.Count}");
            }

            //7. Output how many different letters used in all actors names

            var actorsNames = actors
                .GroupBy(actor => actor.Name.Substring(0, actor.Name.IndexOf(' ')))
                .Select(group => new
                {
                    Name = group.Key,
                    LettersInName = group.Key.ToCharArray().Select(char.ToLower).Distinct().Count()
                })
                .ToList();

            foreach (var actor in actorsNames)
            {
                Console.WriteLine($"Actor name: {actor.Name}, " +
                                  $"number of different letters used in name: {actor.LettersInName}");
            }

            //8. Output names of all books ordered by names of their authors and number of pages

            var orderedBooks = books
                .OrderBy(book => book.Author)
                .ThenByDescending(book => book.Pages)
                .Select(book => book.Name)
                .ToList();

            foreach (string book in orderedBooks)
            {
                Console.WriteLine(book);
            }

            //9. Output actor name and all films with this actor

            var filmActor = films
                .SelectMany(film => film.Actors, (film, actor) => new
                {
                    FilmName = film.Name,
                    ActorName = actor.Name
                })
                .ToList();

            foreach (var item in filmActor)
            {
                Console.WriteLine($"Actor: {item.ActorName}, Film: {item.FilmName}");
            }

            //10. Output sum of total number of pages in all books and all int values inside all sequences in data

            int sumOfPages = books
                .Select(book => book.Pages)
                .Sum();

            Console.WriteLine($"Sum of total number of pages: {sumOfPages}");

            var intValues = data.OfType<List<int>>()
                .SelectMany(list => list, (list, value) => new {value})
                .ToList();                

            foreach (var item in intValues)
            {
                Console.WriteLine(item.value);
            }

            //11. Get the dictionary with the key - book author, value - list of author's books

            var authorsDictionary = books
                .GroupBy(book => book.Author)
                .Select(group => new
                {
                    AuthorName = group.Key,
                    AuthorsBooks = group.Select(b => b.Name).ToList()
                })
                .ToDictionary(authorBook => authorBook.AuthorName, 
                              authorBook => authorBook.AuthorsBooks);

            foreach (var authorBook in authorsDictionary)
            {
                Console.Write($"{authorBook.Key}: ");

                foreach (string book in authorBook.Value)
                {
                    Console.Write($"{book}; ");
                }
                Console.WriteLine();
            }

            //12. Output all films of "Matt Damon" excluding films with actors 
            //whose name are presented in data as strings

            var query = filmActor
                .Where(film => film.ActorName == "Matt Damon")
                .ToList();

            foreach (var film in query)
            {
                Console.WriteLine(film.FilmName);
            }

            Console.ReadKey();
        }
    }
}
