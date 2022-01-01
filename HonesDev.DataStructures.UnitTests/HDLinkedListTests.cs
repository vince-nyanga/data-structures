using System;
using HonesDev.DataStructures.DoublyLinkedList.BasicImpl;
using Xunit;

namespace HonesDev.DataStructures.UnitTests
{
    public class HDLinkedListTests
    {
        [Fact]
        public void AddFirst_ShouldUpdateCount()
        {
            HDLinkedList<int> sut = new();

            sut.AddFirst(1);

            Assert.Equal(1, sut.Count);
        }

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
        public void AddLast_ShouldUpdateCount()
        {
            HDLinkedList<int> sut = new();

            sut.AddLast(1);

            Assert.Equal(1, sut.Count);
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

        [Fact]
        public void FindFirst_IfEmpty_ShouldReturnNull()
        {
            HDLinkedList<int> sut = new();

            var result = sut.FindFirst(1);

            Assert.Null(result);
        }

        [Fact]
        public void FindFirst_IfHeadContainsValue_ShouldReturnFirstNode()
        {

            HDLinkedList<int> sut = new();
            sut.AddFirst(1);
            sut.AddLast(2);
            sut.AddLast(1);

            var result = sut.FindFirst(1);

            Assert.Equal(sut.First, result);
        }

        [Fact]
        public void FindFirst_IfTailContainsValue_ShouldReturnLastNode()
        {

            HDLinkedList<int> sut = new();
            sut.AddFirst(2);
            sut.AddLast(2);
            sut.AddLast(1);

            var result = sut.FindFirst(1);

            Assert.Equal(sut.Last, result);
        }

        [Fact]
        public void FindFirst_ShouldReturnNode()
        {
            HDLinkedList<int> sut = new();
            sut.AddFirst(3);
            sut.AddLast(2);
            sut.AddLast(1);
            sut.AddLast(5);

            var result = sut.FindFirst(1);

            Assert.NotNull(result);
        }

        [Fact]
        public void FindFirst_InNoMatch_ShouldReturnNull()
        {
            HDLinkedList<int> sut = new();
            sut.AddFirst(3);
            sut.AddLast(2);
            sut.AddLast(8);
            sut.AddLast(5);

            var result = sut.FindFirst(1);

            Assert.Null(result);
        }

        [Fact]
        public void FindLast_IfEmpty_ShouldReturnNull()
        {
            HDLinkedList<int> sut = new();

            var result = sut.FindLast(1);

            Assert.Null(result);
        }

        [Fact]
        public void FindLast_IfHeadContainsValue_ShouldReturnFirstNode()
        {

            HDLinkedList<int> sut = new();
            sut.AddFirst(1);

            var result = sut.FindLast(1);

            Assert.Equal(sut.First, result);
        }

        [Fact]
        public void FindLast_IfTailContainsValue_ShouldReturnLastNode()
        {

            HDLinkedList<int> sut = new();
            sut.AddFirst(1);
            sut.AddLast(2);
            sut.AddLast(1);

            var result = sut.FindLast(1);

            Assert.Equal(sut.Last, result);
        }

        [Fact]
        public void FindLast_ShouldReturnNode()
        {
            HDLinkedList<int> sut = new();
            sut.AddFirst(3);
            sut.AddLast(2);
            sut.AddLast(1);
            sut.AddLast(5);

            var result = sut.FindLast(1);

            Assert.NotNull(result);
        }

        [Fact]
        public void FindLast_InNoMatch_ShouldReturnNull()
        {
            HDLinkedList<int> sut = new();
            sut.AddFirst(3);
            sut.AddLast(2);
            sut.AddLast(8);
            sut.AddLast(5);

            var result = sut.FindLast(1);

            Assert.Null(result);
        }

        [Fact]
        public void AddBefore_ShouldUpdateCount()
        {
            HDLinkedList<int> sut = new();
            sut.AddFirst(1);
            var currentNode = sut.FindFirst(1);

            sut.AddBefore(currentNode, 2);

            Assert.Equal(2, sut.Count);
        }

        [Fact]
        public void AddBefore_IfNodeIsHead_ShouldChangeFirstNode()
        {
            HDLinkedList<int> sut = new();
            sut.AddFirst(1);
            var currentNode = sut.FindFirst(1);

            sut.AddBefore(currentNode, 2);

            Assert.Equal(2, sut.First.Value);
        }

        [Fact]
        public void AddBefore_ShouldChangeCurrentNodePreviousReference()
        {
            HDLinkedList<int> sut = new();
            sut.AddFirst(1);
            var currentNode = sut.FindFirst(1);

            sut.AddBefore(currentNode, 2);

            Assert.Equal(2, currentNode.Previous.Value);
        }

        [Fact]
        public void AddBefore_ShouldSetNewNodeNextReferenceToCurrentNode()
        {
            HDLinkedList<int> sut = new();
            sut.AddFirst(1);
            var currentNode = sut.FindFirst(1);

            sut.AddBefore(currentNode, 2);

            Assert.Equal(1, sut.First.Next.Value);
        }

        [Fact]
        public void AddBefore_IfCurrentNodeIsNull_ShouldThrow()
        {
            HDLinkedList<int> sut = new();

            void action() => sut.AddBefore(null, 1);

            Assert.Throws<ArgumentNullException>(action);
        }

        [Fact]
        public void AddAfter_ShouldUpdateCount()
        {
            HDLinkedList<int> sut = new();
            sut.AddFirst(1);
            var currentNode = sut.FindFirst(1);

            sut.AddAfter(currentNode, 2);

            Assert.Equal(2, sut.Count);
        }

        [Fact]
        public void AddAfter_IfNodeIsTail_ShouldChangeLastNode()
        {
            HDLinkedList<int> sut = new();
            sut.AddFirst(1);
            var currentNode = sut.FindFirst(1);

            sut.AddAfter(currentNode, 2);

            Assert.Equal(2, sut.Last.Value);
        }

        [Fact]
        public void AddAfter_ShouldChangeCurrentNodeNextReference()
        {
            HDLinkedList<int> sut = new();
            sut.AddFirst(1);
            var currentNode = sut.FindFirst(1);

            sut.AddAfter(currentNode, 2);

            Assert.Equal(2, currentNode.Next.Value);
        }

        [Fact]
        public void AddBefore_ShouldSetNewNodePreviousReferenceToCurrentNode()
        {
            HDLinkedList<int> sut = new();
            sut.AddFirst(1);
            var currentNode = sut.FindFirst(1);

            sut.AddAfter(currentNode, 2);

            Assert.Equal(1, sut.Last.Previous.Value);
        }

        [Fact]
        public void AddAfter_IfCurrentNodeIsNull_ShouldThrow()
        {
            HDLinkedList<int> sut = new();

            void action() => sut.AddAfter(null, 1);

            Assert.Throws<ArgumentNullException>(action);
        }
    }
}
