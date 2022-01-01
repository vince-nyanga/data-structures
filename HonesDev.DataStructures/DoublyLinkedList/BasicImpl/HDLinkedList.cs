using System;

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

        public Node<T> FindFirst(T value)
        {
            var node = _head;
            while (node != null)
            {
                if (node.Value.Equals(value))
                {
                    break;
                }

                node = node.Next;
            }

            return node;
        }

        public Node<T> FindLast(T value)
        {
            var node = _head;
            Node<T> result = null;
            while (node != null)
            {
                if (node.Value.Equals(value))
                {
                    result = node;
                }

                node = node.Next;
            }

            return result;
        }

        public void ListItems()
        {
            var node = _head;
            while(node != null)
            {
                Console.WriteLine(node.Value);
                node = node.Next;
            }
        }

        public void ListItemsReverse()
        {
            var node = _tail;
            while (node != null)
            {
                Console.WriteLine(node.Value);
                node = node.Previous;
            }
        }

        public void AddBefore(Node<T> currentNode, T value)
        {
            if (currentNode is null)
            {
                throw new ArgumentNullException(nameof(currentNode));
            }
            _count++;
            Node<T> newNode = new() { Value = value };
            var temp = currentNode;
            newNode.Next = currentNode;
            newNode.Previous = temp.Previous;
            currentNode.Previous = newNode;

            if (newNode.Previous is null)
            {
                _head = newNode;
            }
        }

        public void AddAfter(Node<T> currentNode, T value)
        {
            if (currentNode is null)
            {
                throw new ArgumentNullException(nameof(currentNode));
            }
            _count++;
            Node<T> newNode = new() { Value = value };
            var temp = currentNode;
            newNode.Previous = currentNode;
            newNode.Next = temp.Next;
            currentNode.Next = newNode;

            if (newNode.Next is null)
            {
                _tail = newNode;
            }
        }
    }

    public record Node<T>
    {
        public T Value { get; init; }
        public Node<T> Previous { get; set; }
        public Node<T> Next { get; set; }
    }
}
    