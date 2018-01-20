using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_methods
{
    class LinqSelectMany
    {
        class PetOwner
        {
            public string Name { get; set; }
            public List<string> Pets { get; set; }
        }

        public static void SelectManyEx()
        {
            PetOwner[] petOwners =
            {
                new PetOwner
                {
                    Name ="Higa",
                    Pets = new List<string>{ "Scruffy", "Sam" } 
                },
                new PetOwner
                {
                    Name ="Ashkenazi",
                    Pets = new List<string>{ "Walker", "Sugar" }
                    
                },
                new PetOwner
                {
                    Name ="Price",
                    Pets = new List<string>{ "Scratches", "Diesel" } 
                },
                new PetOwner
                {
                    Name ="Hines",
                    Pets = new List<string>{ "Dusty" } 
                } 
            };

            var query =
                petOwners
                    .SelectMany(petOwner => petOwner.Pets, (petOwner, petName) => new { petOwner, petName })
                    .Where(ownerAndPet => ownerAndPet.petName.StartsWith("S"))
                    .OrderByDescending(ownerAndPet => ownerAndPet.petOwner.Name)
                    .Select(ownerAndPet =>
                        new
                        {
                            Owner = ownerAndPet.petOwner.Name,
                            Pet = ownerAndPet.petName
                        }
                    );

            foreach (var obj in query)
            {
                Console.WriteLine(obj);
            }
        }
    }
}
