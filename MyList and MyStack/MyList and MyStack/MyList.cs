using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyList_and_MyStack
{
    class MyList
    {
        private int[] array;
        private int index;
        public MyList()
        {
            array = new int[1];
        }
        public MyList(int n)
        {
            array = new int[n];
        }
        public int FindByIndex(int ix)
        {
            return array[ix];
        }
        public int GetCount()
        {
            return index;
        }
        public void Add(int item)
        {
            array[index] = item;
            int[] temp = new int[array.Length + 1];
            for (int i = 0; i < array.Length; i++)
            {
                temp[i] = array[i];
            }
            array = temp;
            index++;
        }
        public void Remove(int item)
        {
            int[] temp = new int[array.Length - 1];
            int ix = Array.IndexOf(array, item);
            for (int i = 0; i < array.Length; i++)
            {
                if (i < ix)
                {
                    temp[i] = array[i];
                }
                else if (i > ix)
                {
                    temp[i - 1] = array[i];
                }
            }
            array = temp;
            index--;
        }
        public void RemoveAt(int ix)
        {
            int[] temp = new int[array.Length - 1];
            for (int i = 0; i < array.Length; i++)
            {
                if (i < ix)
                {
                    temp[i] = array[i];
                }
                else if (i > ix)
                {
                    temp[i - 1] = array[i];
                }
            }
            array = temp;
            index--;
        }
        public void Clear()
        {
            int[] temp = new int[1];
            array = temp;
            index = 0;
        }
    }
}
