using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionInterfaces
{
    //does not work correctly with multiple foreach loops
    class AnotherList : IEnumerable, IEnumerator
    {
        private string[] _array;
        private int _index = -1;

        public AnotherList(string[] array)
        {
            _array = array;
        }

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        public object Current => _array[_index];

        public bool MoveNext()
        {
            return ++_index < _array.Length;
        }

        public void Reset()
        {
            _index = -1;
        }
        
    }
}
