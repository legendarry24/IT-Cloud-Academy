using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionInterfaces
{
    public class MyList : IEnumerable, IEnumerator
    {
        private string[] _array;

        public MyList(string[] array)
        {
            _array = array;
        }

        public IEnumerator GetEnumerator()
        {
            return new MyEnumerator(this);
        }

        //public IEnumerator GetEnumerator()
        //{
        //    return _array.GetEnumerator();
        //}

        private struct MyEnumerator : IEnumerator
        {
            private MyList _list;
            private int _index;
            public MyEnumerator(MyList list)
            {
                _list = list;
                _index = 0;
            }

            public object Current => _list._array[_index];


            public bool MoveNext()
            {
                _index++;
                return _index < _list._array.Length;
            }

            public void Reset() { _index = 0; }
        }
    }
}
