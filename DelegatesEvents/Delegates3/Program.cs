using System;
using System.Collections.Generic;

namespace Delegates3
{
    public delegate void MyDelegate();

    class Program
    {
        public event Action MyEvent;

        static void HasThree(List<int> lists, MyDelegate someWork)
        {
            foreach (var item in lists)
            {
                if (item == 3)
                {
                    someWork();
                }
            }
        } 

        void HasTwo(List<int> lists, Action someWork)
        {
            foreach (var item in lists)
            {
                if (item == 2)
                {
                    MyEvent += someWork;
                }
            }
        }

        static void Main(string[] args)
        {
            List<int> list = new List<int>() { 1, 2, 5, 6, 3, 2, 3 };
            MyDelegate myFunction = MyMethod;
            Action myFunc = MyEventMethod;
            HasThree(list, myFunction);
            TestClass.RewriteDelegate(ref myFunction);
            HasThree(list, myFunction);


            Console.ReadKey();
        }

        static void MyMethod()
        {
            Console.WriteLine("Sample text");
        }

        static void MyEventMethod()
        {
            Console.WriteLine("Test event");
        }
    }
}
