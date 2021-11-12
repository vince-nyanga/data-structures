namespace DataStructures.LinkedList.Models
{
    public class LinkedList<T>
    {
        private int _count;
        private Node<T> _head;
        private Node<T> _tail;
        public Node<T> First { get => _head; }
        public Node<T> Last { get => _tail; }
        public int Count { get => _count; }

        public void AddFirst(T data)
        {
            _count++;
            var newNode = new Node<T>(data);
            if (_head is null)
            {
                _head = newNode;
                _tail = newNode;
                return;
            }
            newNode.Next = _head;
            _head.Previous = newNode;
            _head = newNode;
        }

        public void AddLast(T data)
        {
            _count++;
            var newNode = new Node<T>(data);
            if (_head is null)
            {
                _head = newNode;
                _tail = newNode;
                return;
            }
            _tail.Next = newNode;
            newNode.Previous = _tail;
            _tail = newNode;
        }
    }
}