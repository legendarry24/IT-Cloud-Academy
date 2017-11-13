using ClassLibrary1;

namespace OOP2
{
    public class Counter: PublicTestClass
    {
        protected int Count;

        public virtual void Increment()
        {
            a = Count--; // a from PublicTestClass
            Count++;
        }

        public void TestMethod()
        {
            System.Console.WriteLine("Counter.TestMethod");
        }

        public int GetCount()
        {
            return Count;
        }

        public void Reset()
        {
            Count = 0;
        }
    }
}
