using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyList_and_MyStack
{
    class MyStack
    {
        private int index;
        private int[] array = new int[10];
        public void Push(int item)
        {
            array[index++] = item;
        }
        public int Pop()
        {
            return array[--index];
        }
        public int Peek()
        {
            return array[index - 1];
        }
        public void Show()
        {
            for (int i = index - 1; i >= 0; i--)
            {
                Console.WriteLine(array[i]);
            }
        }
    }
}
