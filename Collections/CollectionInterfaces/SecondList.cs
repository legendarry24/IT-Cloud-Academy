using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionInterfaces
{
    class SecondList: IEnumerable
    {
        private string[] _array;
        private int[] _arr;

        public SecondList(string[] array)
        {
            _array = array;
        }

        public SecondList(int[] arr)
        {
            _arr = arr;
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < _array.Length; i++)
            {
                yield return _array[i];
            }
        }

        public IEnumerator GetEvenNumbers()
        {
            for (int i = 0; i < _arr.Length; i++)
            {
                if (_arr[i] % 2 == 0)
                {
                    yield return _arr[i];
                }
            }
        }
    }
}
