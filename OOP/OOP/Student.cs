using System;

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
            : base(DateTime.Now, name)
        {
            Console.WriteLine("Student(string name)");
        }

    }
}
