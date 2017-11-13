using System;
using ClassLibrary1;

namespace OOP2
{
    class Test
    {
        static Test()
        {
            Console.WriteLine("I'm a static");
        }

        public Test()
        {
            Console.WriteLine("I'm default");
        }

        public Test(int a)
            :this()
        {
            Console.WriteLine("I'm not a static with parameter");           
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            #region Static
            //MyStaticClass.Increment();
            //MyStaticClass.Increment();
            //Console.WriteLine(MyStaticClass.GetCount());
            //Test test = new Test();
            //Console.WriteLine(new string('-', 20));
            //Test test1 = new Test(5);
            #endregion

            #region Encaptulation
            //MemoryCounter memory = new MemoryCounter();
            //memory.Increment();
            //memory.IncrementMemoryCount(2);
            //Console.WriteLine(memory.GetCount());
            //PublicTestClass pubclass = new PublicTestClass();
            //// InternalClass internClass = new InternalClass cannot create cuz internal type
            #endregion

            #region Polimorphism

            Counter counter = new Counter();
            MemoryCounter memory = new MemoryCounter();
            Counter ctr = new MemoryCounter();
            counter.TestMethod();
            counter.Increment(); // use logic of base class
            memory.TestMethod();
            memory.Increment();
            ctr.TestMethod();
            ctr.Increment();

            #endregion
            Console.ReadKey();
        }
    }
}
