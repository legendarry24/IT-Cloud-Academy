using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericList
{
    struct MyKeyValuePair<TKey, TValue>
    {
        public TKey Key { get; }

        public TValue Value { get; }

        public MyKeyValuePair(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }

    }
}
