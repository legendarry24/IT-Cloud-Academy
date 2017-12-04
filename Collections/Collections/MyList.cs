using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    class MyList<T> where T : struct 
    {
        private T[] _array;
        private int _index;

        public MyList()
        {
            _array = new T[1];
        }

        public MyList(int n)
        {
            _array = new T[n];
        }

        public T FindByIndex(int ix)
        {
            return _array[ix];
        }

        public int Count => _index;

        public void Add(T item)
        {
            _array[_index] = item;
            T[] temp = new T[_array.Length + 1];
            for (int i = 0; i < _array.Length; i++)
            {
                temp[i] = _array[i];
            }
            _array = temp;
            _index++;
        }

        public void Remove(int item)
        {
            T[] temp = new T[_array.Length - 1];
            int ix = Array.IndexOf(_array, item);
            for (int i = 0; i < _array.Length; i++)
            {
                if (i < ix)
                {
                    temp[i] = _array[i];
                } else if (i > ix)
                {
                    temp[i - 1] = _array[i];
                }
            }
            _array = temp;
            _index--;
        }

        public void RemoveAt(int ix)
        {
            T[] temp = new T[_array.Length - 1];
            for (int i = 0; i < _array.Length; i++)
            {
                if (i < ix)
                {
                    temp[i] = _array[i];
                } else if (i > ix)
                {
                    temp[i - 1] = _array[i];
                }
            }
            _array = temp;
            _index--;
        }

        public void Clear()
        {
            T[] temp = new T[1];
            _array = temp;
            _index = 0;
        }
    }
}
