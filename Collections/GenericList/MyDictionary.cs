using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericList
{
    class MyDictionary<TKey, TValue> : IEnumerable<MyKeyValuePair<TKey, TValue>>
    {
        private MyKeyValuePair<TKey, TValue>[] _dictionary;

        public MyDictionary(MyKeyValuePair<TKey, TValue>[] dictionary)
        {
            _dictionary = dictionary;
        }

        public IEnumerator GetEnumerator()
        {
            return new Enumerator(_dictionary);
        }

        IEnumerator<MyKeyValuePair<TKey, TValue>> IEnumerable<MyKeyValuePair<TKey, TValue>>.GetEnumerator()
        {
            return new Enumerator(_dictionary);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Enumerator(_dictionary);
        }

        private struct Enumerator : IEnumerator<MyKeyValuePair<TKey, TValue>>
        {
            private MyKeyValuePair<TKey, TValue>[] _dictionary;
            private int _index;

            public Enumerator(MyKeyValuePair<TKey, TValue>[] dictionary)
            {
                _dictionary = dictionary;
                _index = -1;
            }

            public MyKeyValuePair<TKey, TValue> Current => _dictionary[_index];

            object IEnumerator.Current => _dictionary[_index];

            public void Dispose()
            {

            }

            public bool MoveNext()
            {
                return ++_index < _dictionary.Length;
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }
        }
    }
}
