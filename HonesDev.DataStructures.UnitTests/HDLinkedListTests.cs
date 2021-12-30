using HonesDev.DataStructures.DoublyLinkedList.BasicImpl;
using Xunit;

namespace HonesDev.DataStructures.UnitTests
{
    public class HDLinkedListTests
    {

        [Fact]
        public void AddFirst_IfEmpty_ShouldSetFirst()
        {
            HDLinkedList<int> sut = new();

            sut.AddFirst(1);

            Assert.Equal(1, sut.First.Value);
        }

        [Fact]
        public void AddFirst_IfEmpty_ShouldSetLast()
        {
            HDLinkedList<int> sut = new();

            sut.AddFirst(1);

            Assert.Equal(1, sut.Last.Value);
        }

        [Fact]
        public void AddFirst_IfNotEmpty_ShouldUpdateFirst()
        {
            HDLinkedList<int> sut = new();
            sut.AddFirst(2);

            sut.AddFirst(1);

            Assert.Equal(1, sut.First.Value);
        }

        [Fact]
        public void AddFirst_IfNotEmpty_ShouldNotUpdateLast()
        {
            HDLinkedList<int> sut = new();
            sut.AddFirst(2);

            sut.AddFirst(1);

            Assert.Equal(2, sut.Last.Value);
        }

        [Fact]
        public void AddLast_IfEmpty_ShouldSetFirst()
        {
            HDLinkedList<int> sut = new();

            sut.AddLast(1);

            Assert.Equal(1, sut.First.Value);
        }

        [Fact]
        public void AddLast_IfEmpty_ShouldSetLast()
        {
            HDLinkedList<int> sut = new();

            sut.AddLast(1);

            Assert.Equal(1, sut.Last.Value);
        }

        [Fact]
        public void AddLast_IfNotEmpty_ShouldUpdateLast()
        {
            HDLinkedList<int> sut = new();
            sut.AddFirst(2);

            sut.AddLast(1);

            Assert.Equal(1, sut.Last.Value);
        }

        [Fact]
        public void AddLast_IfNotEmpty_ShouldNotUpdateFirst()
        {
            HDLinkedList<int> sut = new();
            sut.AddFirst(2);

            sut.AddLast(1);

            Assert.Equal(2, sut.First.Value);
        }


    }
}
