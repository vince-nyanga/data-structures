using System;
using HonesDev.DataStructures.BinaryHeap;
using Xunit;

namespace HonesDev.DataStructures.UnitTests
{
    public class MinHeapTests
    {
        private readonly Func<int, int, bool> _minHeapComparer = (a, b) => a < b;

        [Fact]
        public void Insert_IfEmpty_ShouldSetRoot()
        {
            HDHeap<int> sut = new(_minHeapComparer);

            sut.Insert(10);

            Assert.Equal(10, sut.Root);
        }

        [Fact]
        public void Insert_IfValueLessThanRoot_ShouldSwap()
        {
            HDHeap<int> sut = new(_minHeapComparer);
            sut.Insert(10);
          
            sut.Insert(2);

            Assert.Equal(2, sut.Root);
        }

        [Fact]
        public void Insert_ShouldCreateMinHeap()
        {
            HDHeap<int> sut = new(_minHeapComparer);
            sut.Insert(10);
            sut.Insert(2);
            sut.Insert(3);
            sut.Insert(1);
            sut.Insert(7);
            var expectedResult = "1 2 3 10 7";

            Assert.Equal(expectedResult, sut.ToString());
        }
    }
}
