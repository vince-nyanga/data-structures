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
            var i = _items.Count - 1;
            while (i > 0)
            {
                var parentIndex = GetParentIndex(i);
                if (_comparer.Invoke(_items[i], _items[parentIndex]))
                {
                    Swap(i, parentIndex);
                    i = parentIndex;
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

        private int GetParentIndex(int currentIndex) => (currentIndex - 1) >> 1;

        private int GetLeftChildIndex(int currentIndex) => (currentIndex + 1) << 1;

        private int RightChildIndex(int currentIndex) => (currentIndex + 2) << 1;

        private void Swap(int firstIndex, int secondIndex)
        {
            var temp = _items[firstIndex];
            _items[firstIndex] = _items[secondIndex];
            _items[secondIndex] = temp;
        }

    }
}
