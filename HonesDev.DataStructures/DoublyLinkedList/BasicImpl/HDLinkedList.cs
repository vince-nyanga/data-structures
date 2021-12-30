namespace HonesDev.DataStructures.DoublyLinkedList.BasicImpl
{
    public class HDLinkedList<T>
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
            Node<T> newNode = new(){ Value = data };

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
            Node<T> newNode = new(){Value = data};

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

    public record Node<T>
    {
        public T Value { get; init; }
        public Node<T> Previous { get; set; }
        public Node<T> Next { get; set; }
    }
}
    