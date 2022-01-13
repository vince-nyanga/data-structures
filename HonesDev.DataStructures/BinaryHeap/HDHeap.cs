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

        public void DeleteRoot()
        {
            var i = _items.Count - 1;
            _items[0] = _items[i];
            _items.RemoveAt(i);

            BubbleDown();
        }


        private void BubbleDown()
        {
            var i = 0;
            while (true)
            {
                var leftChildIndex = GetLeftChildIndex(i);
                var rightChildIndex = GetRightChildIndex(i);
                var swapIndex = i;

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

                if (swapIndex != i)
                {
                    Swap(swapIndex, i);
                    i = swapIndex;
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

        private static int GetParentIndex(int currentIndex) => (currentIndex - 1) / 2;

        private static int GetLeftChildIndex(int currentIndex) => 2 * currentIndex + 1;

        private static int GetRightChildIndex(int currentIndex) => 2 * currentIndex + 2;

        private void Swap(int firstIndex, int secondIndex)
        {
            var temp = _items[firstIndex];
            _items[firstIndex] = _items[secondIndex];
            _items[secondIndex] = temp;
        }

    }
}
