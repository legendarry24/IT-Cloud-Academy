using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_methods
{
    class Program
    {
        public class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
        }

        class Pet
        {
            public string Name { get; set; }
            public string OwnerName { get; set; }
        }

        class PetOwner
        {
            public string OwnerName { get; set; }
            public string PetName { get; set; }
        }

        public static void JoinEx()
        {
            Person magnus = new Person { FirstName = "Magnus" };
            Person terry = new Person { FirstName = "Terry" };
            Person charlotte = new Person { FirstName = "Charlotte" };
            Person jack = new Person { FirstName = "Jack" };

            Pet barley = new Pet { Name = "Barley", OwnerName = "Terry" };
            Pet boots = new Pet { Name = "Boots", OwnerName = "Terry" };
            Pet whiskers = new Pet { Name = "Whiskers", OwnerName = "Charlotte" };
            Pet daisy = new Pet { Name = "Daisy", OwnerName = "Magnus" };

            List<Person> people = new List<Person> { magnus, terry, charlotte, jack };
            List<Pet> pets = new List<Pet> { barley, boots, whiskers, daisy };

            var petOwners = people.Join(
                pets,
                person => person.FirstName, // outer key (primary key)
                pet => pet.OwnerName,       // inner key (foreign key)
                (person, pet) => new PetOwner
                {
                    OwnerName = person.FirstName,
                    PetName = pet.Name
                })
                .ToList();

            //another implementation
            //var petOwners =
            //    from person in people
            //    join pet in pets on person.FirstName equals pet.OwnerName
            //    select new PetOwner {OwnerName = person.FirstName, PetName = pet.Name};

            foreach (var obj in petOwners)
            {
                Console.WriteLine($"{obj.OwnerName} - {obj.PetName}");
            }
        }      

        public static void OrderBy()
        {
            Person magnus = new Person { FirstName = "Magnus", LastName = "Hedlund", Age = 1506 };
            Person adam = new Person { FirstName = "Adam", LastName = "Terens", Age = 12018 };
            Person charlotte = new Person { FirstName = "Charlotte", LastName = "Weiss", Age = 20 };
            Person merlin = new Person { FirstName = "Merlin", LastName = "Abart", Age = 25 };
            Person harry = new Person { FirstName = "Harry", LastName = "Potter", Age = 29 };
            Person lily = new Person { FirstName = "Lily", LastName = "Potter", Age = 32 };
             
            List<Person> persons = new List<Person>
            {
                magnus,
                adam,
                charlotte,
                merlin,
                harry,
                lily
            };

            var sortedPersons = persons
                .Where(person => person.Age >= 20 && person.Age < 35)
                .OrderBy(person => person.LastName)
                .ThenByDescending(person => person.FirstName)
                .Select(person => person);

            Console.WriteLine("Sorted persons:");
            foreach (var person in sortedPersons)
            {
                Console.WriteLine($"{person.FirstName} {person.LastName}");
            }
        }

        public static IEnumerable<Person> GetPersons()
        {
            Person magnus = new Person { FirstName = "Magnus", LastName = "Hedlund", Age = 1506 };
            Person adam = new Person { FirstName = "Adam", LastName = "Terens", Age = 12018 };
            Person charlotte = new Person { FirstName = "Charlotte", LastName = "Weiss", Age = 20 };
            Person merlin = new Person { FirstName = "Merlin", LastName = "Abart", Age = 25 };
            Person harry = new Person { FirstName = "Harry", LastName = "Potter", Age = 29 };
            Person lily = new Person { FirstName = "Lily", LastName = "Potter", Age = 32 };

            return new List<Person>
            {
                magnus,
                adam,
                charlotte,
                merlin,
                harry,
                lily
            };
        }

        // a function that gets a string of words and returns a string where order of words is reversed
        public static string WordReverse(string input, char separator)
        {
            var reversedWords = input.Split(separator).Reverse();

            return string.Join(separator, reversedWords);
        }

        static void Main(string[] args)
        {
            LinqSelectMany.SelectManyEx();
            JoinEx();
            OrderBy();

            var averageAge = GetPersons().Average(x => x.Age);
            Console.WriteLine($"Average age: {averageAge}");

            string name = "Petro";
            Console.WriteLine(name.IsLengthEven());

            string input = "cat dog fish bird lion";
            Console.WriteLine(WordReverse(input, ' '));

            Console.ReadKey();
        }
    }
}