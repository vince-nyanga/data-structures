using System;
using System.Collections.Generic;
using HonesDev.DataStructures.BinaryHeap;
using Xunit;

namespace HonesDev.DataStructures.UnitTests
{
    public class MinHeapTests
    {
        private readonly IntComparer _comparer = new ();

        [Fact]
        public void Insert_IfEmpty_ShouldSetRoot()
        {
            HDMinHeap<int> sut = new(_comparer);

            sut.Insert(10);

            Assert.Equal(10, sut.Root);
        }

        [Fact]
        public void Insert_IfValueLessThanRoot_ShouldSwap()
        {
            HDMinHeap<int> sut = new(_comparer);
            sut.Insert(10);
          
            sut.Insert(2);

            Assert.Equal(2, sut.Root);
        }

        [Fact]
        public void Insert_ShouldCreateMinHeap()
        {
            HDMinHeap<int> sut = new(_comparer);
            sut.Insert(10);
            sut.Insert(2);
            sut.Insert(3);
            sut.Insert(1);
            sut.Insert(7);
            var expectedResult = "1 2 3 10 7";

            Assert.Equal(expectedResult, sut.ToString());
        }

        [Fact]
        public void Pop_ShouldRemoveRoot()
        {
            HDMinHeap<int> sut = new(_comparer);
            sut.Insert(10);
            sut.Insert(2);
            sut.Insert(3);
            sut.Insert(1);
            sut.Insert(7);
            sut.Insert(8);
            var expectedResult = "2 7 3 10 8";

            var item = sut.Pop();

            Assert.Equal(expectedResult, sut.ToString());
            Assert.Equal(1, item);
        }

        [Fact]
        public void RemoveAt_IfIndexMoreThanCount_ShouldThrowException()
        {
            HDMinHeap<int> sut = new(_comparer);

            Assert.Throws<IndexOutOfRangeException>(() => sut.RemoveAt(0));
        }

        [Fact]
        public void RemoveAt_ShouldRemoveValue()
        {
            HDMinHeap<int> sut = new(_comparer);
            sut.Insert(10);
            sut.Insert(2);
            sut.Insert(3);
            sut.Insert(1);
            sut.Insert(7);
            var expectedResult = "1 2 7 10";

            sut.RemoveAt(2);

            Assert.Equal(expectedResult, sut.ToString());
        }
    }

    internal class IntComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return x - y;
        }
    }
}
