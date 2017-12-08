using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericList
{
    class MyGenericList<T>: IEnumerable<T>
    {
        private T[] _array;

        public MyGenericList(T[] array)
        {
            _array = array;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new MyGenericListEnumerator(_array);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new MyGenericListEnumerator(_array);
        }

        private class MyGenericListEnumerator : IEnumerator<T>
        {
            private T[] _array;
            private int _index = -1;

            public T Current => _array[_index];

            object IEnumerator.Current => _array[_index];

            public MyGenericListEnumerator(T[] array)
            {
                _array = array;
            }

            public void Dispose()
            {
                
            }

            public bool MoveNext()
            {
                return ++_index < _array.Length;
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }
        }
    }
}
