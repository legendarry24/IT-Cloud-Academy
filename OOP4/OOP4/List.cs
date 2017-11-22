using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP4
{
    class List
    {
        private ListNode _head;    // first element    
        private ListNode _last;    // last element

        public List(int value)
        {
            _head = new ListNode
            {
                Value = value
            };
            _last = _head;
        }

        public void Add(int value)
        {
            var node = new ListNode
            {
                Value = value
            };

            _last.Next = node;
            _last = node;
        }

        public void Print()
        {
            while (_head.Next != _last.Next)
            {
                Console.WriteLine(_head.Value);
                _head = _head.Next;
            }
            Console.WriteLine(_last.Value);
        }

    }
}
