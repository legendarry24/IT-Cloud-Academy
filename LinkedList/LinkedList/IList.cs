namespace LinkedList
{
    public interface IList
    {
         void Add(int value);
         void Print();
         ListNode this[int index] { get; }
         int Count { get; }
    }
}