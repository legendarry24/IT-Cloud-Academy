namespace OOP2
{
    class MemoryCounter: Counter
    {
        public void IncrementMemoryCount(int a)
        {
            Count = GetCount() + a;
        }

        public override void Increment() 
        {
            System.Console.WriteLine("MemoryCounter.Increment");
        }

        public new void TestMethod() // hide implementation (you should add the new key word)
        {
            System.Console.WriteLine("MemoryCounter.TestMethod");
        }
    }
}
