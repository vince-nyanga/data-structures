using System;
using System.Collections.Generic;

namespace HonesDev.DataStructures.BinaryHeap
{
    public class HDHeap<T>
    {
        private readonly List<T> _items;
        private readonly Func<T, T, bool> _comparer;

        public HDHeap(Func<T, T, bool> comparer)
        {
            _comparer = comparer;
            _items = new List<T>();
        }

        public T Root => _items[0];

        public void Insert(T item)
        {
            _items.Add(item);
            BubbleUp();
        }

        private void BubbleUp()
        {
            var index = _items.Count - 1;
            while (index > 0)
            {
                var parentIndex = GetParentIndex(index);
                if (_comparer.Invoke(_items[index], _items[parentIndex]))
                {
                    Swap(index, parentIndex);
                    index = parentIndex;
                }
                else
                {
                    break;
                }
            }
        }

        public T Peek()
        {
            if (_items.Count == 0)
            {
                throw new IndexOutOfRangeException();
            }

            return _items[0];
           
        }

        public T Pop()
        {
            if (_items.Count == 0)
            {
                throw new IndexOutOfRangeException();
            }

            var item = _items[0];
            DeleteRoot();
            return item;
        }

        private void DeleteRoot()
        {
            var i = _items.Count - 1;
            _items[0] = _items[i];
            _items.RemoveAt(i);

            BubbleDown();
        }


        private void BubbleDown()
        {
            var index = 0;
            while (HasLeftChild(index))
            {
                var leftChildIndex = GetLeftChildIndex(index);
                var rightChildIndex = GetRightChildIndex(index);
                var swapIndex = index;

                if (leftChildIndex < _items.Count)
                {
                    if (!_comparer.Invoke(_items[swapIndex], _items[leftChildIndex]))
                    {
                        swapIndex = leftChildIndex;
                    }
                }

                if (rightChildIndex < _items.Count)
                {
                    if (!_comparer.Invoke(_items[swapIndex], _items[rightChildIndex]))
                    {
                        swapIndex = rightChildIndex;
                    }
                }

                if (swapIndex != index)
                {
                    Swap(swapIndex, index);
                    index = swapIndex;
                }
                else
                {
                    break;
                }
            }
           
        }

        public override string ToString()
        {
            return string.Join(" ", _items);
        }

        private static int GetParentIndex(int index) => (index - 1) / 2;

        private static int GetLeftChildIndex(int index) => 2 * index + 1;

        private static int GetRightChildIndex(int index) => 2 * index + 2;

        private bool HasLeftChild(int index) => GetLeftChildIndex(index) < _items.Count;

        private void Swap(int firstIndex, int secondIndex)
        {
            var temp = _items[firstIndex];
            _items[firstIndex] = _items[secondIndex];
            _items[secondIndex] = temp;
        }

    }
}
