using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    class Human
    {
        public DateTime DateOfBirth;
        public string Name;

        public Human(DateTime dateOfBirth)
        {
            DateOfBirth = dateOfBirth;
            Console.WriteLine("Human(DataTime)");
        }

        public Human(DateTime dateOfBirth, string name)
        {
            DateOfBirth = dateOfBirth;
            Name = name;
            Console.WriteLine(Human(DataTime, string))
        }

        public void Walk()
        {
            Console.WriteLine("Okay, i go");
        }

    }
}
