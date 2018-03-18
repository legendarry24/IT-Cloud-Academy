using System.Collections;

namespace CollectionInterfaces
{
    public class MyList : IEnumerable
    {
        private string[] _array;

        public MyList(string[] array)
        {
            _array = array;
        }

        public IEnumerator GetEnumerator()
        {
            return new MyEnumerator(_array);
        }

        //easy way to implement
        //public IEnumerator GetEnumerator()
        //{
        //    return _array.GetEnumerator();
        //}

        private struct MyEnumerator : IEnumerator
        {
            private string[] _array;
            private int _index;

            public MyEnumerator(string[] array)
            {
                _array = array;
                _index = -1;
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
}
