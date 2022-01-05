using System;
using System.Collections.Generic;
using System.Text;

namespace HonesDev.DataStructures.DoublyLinkedList.BasicImpl
{
    public class HDLinkedList<T> where T: IComparable
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
            var node = _tail;
            while (node != null)
            {
                if (node.Value.Equals(value))
                {
                    break;
                }

                node = node.Previous;
            }

            return node;
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
            if (newNode.Previous != null)
            {
                newNode.Previous.Next = newNode;
            }

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
            Node<T> temp = currentNode;
            newNode.Previous = currentNode;
            newNode.Next = temp.Next;
            currentNode.Next = newNode;
            if (newNode.Next != null)
            {
                newNode.Next.Previous = newNode;
            }

            if (newNode.Next is null)
            {
                _tail = newNode;
            }
        }

        public void InsertSorted(T value)
        {
            if (_head is null)
            {
                AddFirst(value);
            }else if (_head.Value.CompareTo(value) >= 0)
            {
                AddFirst(value);
            }
            else
            {
                var node = _head;
                while(node.Next != null && node.Next.Value.CompareTo(value) < 0)
                {
                    node = node.Next;
                }
                AddAfter(node, value);
            }

        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new();
            var node = _head;
            while(node != null)
            {
                stringBuilder.Append($"{node.Value} ");
                node = node.Next;
            }
            return stringBuilder.ToString().Trim();
        }

        public void Reverse()
        {
           if (_count > 1)
            {
                Node<T> temp = null;
                Node<T> current = _head;
                _tail = _head;

                while(current != null)
                {
                    temp = current.Previous;
                    current.Previous = current.Next;
                    current.Next = temp;
                    current = current.Previous;
                }

                _head = temp.Previous;
            }
        }

        public void RemoveDuplicates()
        {
            Dictionary<T, bool> visitedList = new();
            var current = _head;
            while(current != null)
            {
                if (visitedList.ContainsKey(current.Value))
                {
                    if (current.Previous != null)
                    {
                        _count--;
                        current.Previous.Next = current.Next;
                        if (current.Next is null)
                        {
                            _tail = current.Previous;
                        }
                    }
                    if (current.Next != null)
                    {
                        current.Next.Previous = current.Previous;
                    }
                }
                else
                {
                    visitedList.Add(current.Value, true);
                }

                current = current.Next;
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
    