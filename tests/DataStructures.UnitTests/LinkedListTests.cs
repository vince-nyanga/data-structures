using DataStructures.LinkedList.Models;
using Xunit;

namespace DataStructures.UnitTests
{
    public class LinkedListTests
    {
        [Fact]
        public void AddFirst_IfNoNodes_ShouldAddNode()
        {
            var sut = new LinkedList<int>();

            sut.AddFirst(1);

            Assert.Equal(1, sut.First.Value);
            Assert.Equal(1, sut.Last.Value);
        }

        [Fact]
        public void AddFirst_IfContainsOtherNodes_ShouldAddNode()
        {
            var sut = new LinkedList<int>();
            sut.AddFirst(1);

            sut.AddFirst(2);

            Assert.Equal(2, sut.First.Value);
            Assert.Equal(1, sut.First.Next.Value);
        }

        [Fact]
        public void AddFirst_ShouldUpdateCount()
        {
            var sut = new LinkedList<int>();

            sut.AddFirst(1);

            Assert.Equal(1, sut.Count);
        }

        [Fact]
        public void AddLast_IfNoNodes_ShouldAddNode()
        {
            var sut = new LinkedList<int>();

            sut.AddLast(1);

            Assert.Equal(1, sut.First.Value);
            Assert.Equal(1, sut.Last.Value);
        }

        [Fact]
        public void AddLast_IfContainsOtherNodes_ShouldAddNode()
        {
            var sut = new LinkedList<int>();
            sut.AddLast(1);

            sut.AddLast(2);

            Assert.Equal(2, sut.Last.Value);
            Assert.Equal(1, sut.Last.Previous.Value);
        }

        [Fact]
        public void AddLast_ShouldUpdateCount()
        {
            var sut = new LinkedList<int>();

            sut.AddLast(1);

            Assert.Equal(1, sut.Count);
        }
    }
}
