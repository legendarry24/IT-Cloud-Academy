using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyList_and_MyStack
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Work with the stack");
            MyStack stack = new MyStack();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            Console.WriteLine(stack.Peek());
            stack.Pop();
            Console.WriteLine(stack.Peek());
            stack.Show();

            Console.WriteLine("\nWork with the list");
            MyList list = new MyList();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            Console.WriteLine(list.FindByIndex(1));
            list.RemoveAt(1);
            Console.WriteLine(list.FindByIndex(1));
            list.Add(5);
            list.Add(10);
            list.Remove(5);
            for (int i = 0; i < list.GetCount(); i++)
            {
                Console.WriteLine(list.FindByIndex(i));
            }
            Console.WriteLine(list.GetCount());
            list.Clear();
            Console.WriteLine(list.GetCount());
            Console.ReadKey();
        }
    }
}
