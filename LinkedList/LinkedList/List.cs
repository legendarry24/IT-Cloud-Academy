using System;

namespace LinkedList
{
    public class List: IList
    {
        private ListNode _head;    // first element    
        private ListNode _last;    // last element

        public int Count { get; private set; }

        public List(int value)
        {
            _head = new ListNode
            {
                Value = value
            };
            _last = _head;
            _last.Index = Count++;
        }

        public ListNode this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                {
                    Console.WriteLine("Wrong index");
                    return null;
                }
                
                ListNode current = _head;

                while (current != null)
                {
                    if (current.Index == index)
                    {
                        return current;
                    }
                    current = current.Next;
                }
                Console.WriteLine("element not found");
                return null;
            }
        }

        public void Add(int value)
        {
            var node = new ListNode
            {
                Value = value
            };

            _last.Next = node;
            _last = node;
            _last.Index = Count++;
        }

        public void AddToBegin(int value)
        {
            var node = new ListNode
            {
                Value = value
            };
            ListNode second = _head;
            _head = node;
            _head.Next = second;
            Count++;

            ListNode current = second;

            // get appropriate indexes
            for (int i = 1; i < Count; i++)
            {
                current.Index = i;
                current = current.Next;
            }
        }

        public void Remove(int item)
        {
            ListNode current = _head;
            ListNode previous = null;

            while (current != null)
            {
                if (current.Value == item)
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;
                        break;
                    }
                    else    // delete first element
                    {
                        _head = _head.Next;
                        break;
                    }
                }
                previous = current;
                current = current.Next;
            }
            Count--;

            // get appropriate indexes
            for (int i = current.Index - 1; i < Count; i++)
            {
                current.Index = i;
                current = current.Next;
            }
        }
        // public void Print()
        // {
        //     ListNode current = _head;

        //     while (current != null)   //current.Next != _last.Next)
        //     {
        //         Console.WriteLine(current.Value);
        //         current = current.Next;
        //     }
        // }
        public void Print()
        {
            ListNode current = _head;

            for (int i = 0; i < Count; i++)
            {
                Console.WriteLine($"[{current.Index}] = {current.Value}");
                current = current.Next;
            }   
        }
    }
}