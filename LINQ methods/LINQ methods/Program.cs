using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_methods
{
    class Program
    {
        class Person
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
            Person magnus = new Person { FirstName = "Hedlund, Magnus" };
            Person terry = new Person { FirstName = "Adams, Terry" };
            Person charlotte = new Person { FirstName = "Weiss, Charlotte" };

            Pet barley = new Pet { Name = "Barley", OwnerName = "Adams, Terry" };
            Pet boots = new Pet { Name = "Boots", OwnerName = "Adams, Terry" };
            Pet whiskers = new Pet { Name = "Whiskers", OwnerName = "Weiss, Charlotte" };
            Pet daisy = new Pet { Name = "Daisy", OwnerName = "Hedlund, Magnus" };

            List<Person> people = new List<Person> { magnus, terry, charlotte };
            List<Pet> pets = new List<Pet> { barley, boots, whiskers, daisy };

            var petOwners = people.Join(
                pets,
                person => person.FirstName,
                pet => pet.OwnerName,
                (person, pet) => new PetOwner
                {
                    OwnerName = person.FirstName,
                    PetName = pet.Name
                })
                .ToList();

            /*
             This code produces the following output:

             Hedlund, Magnus - Daisy
             Adams, Terry - Barley
             Adams, Terry - Boots
             Weiss, Charlotte - Whiskers
            */

            foreach (var obj in petOwners)
            {
                Console.WriteLine(
                    "{0} - {1}",
                    obj.OwnerName,
                    obj.PetName);
            }

        }
        //ToDo
        public static IEnumerable<Person> GetPersons()
        {

        }
            
        public static void OrderBy()
        {
            Person magnus = new Person { FirstName = "Hedlund", LastName = "Magnus", Age = 1506 };
            Person terry = new Person { FirstName = "Adams", LastName = "Terry", Age = 12018 };
            Person charlotte = new Person { FirstName = "Weiss", LastName = "Charlotte", Age = 20 };
            Person merlin = new Person { FirstName = "Merlin", LastName = "Abart", Age = 25 };
            Person harry = new Person { FirstName = "Harry", LastName = "Potter", Age = 29 };

            List<Person> persons = new List<Person>
            {
                magnus,
                terry,
                charlotte,
                merlin,
                harry
            };
            //ToDo
            var sortedPersons = persons
                .Where(person => person.Age >= 20 && person.Age < 30)
                .
        }

        static void Main(string[] args)
        {
            JoinEx();
            OrderBy();

            string name = "Petro";
            Console.WriteLine(name.IsLengthEven());

            Console.ReadKey();
        }
    }
}
