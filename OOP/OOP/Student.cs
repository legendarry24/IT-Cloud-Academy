using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    class Student: Human
    {
        public string University;

        public Student()
            : base(DateTime.Now)
        {
            Console.WriteLine("Student()");
        }
        public Student(string name)
            : base(DateTime.Now)
        {
            Console.WriteLine("Student(string name)");
        }

    }
}
