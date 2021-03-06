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

        [Fact]
        public void InsertSorted_ShouldIncrementCount()
        {
            HDLinkedList<int> sut = new();

            sut.InsertSorted(1);

            Assert.Equal(1, sut.Count);
        }

        [Fact]
        public void InsertSorted_ValueLessThanHead_ShouldSetHead()
        {
            HDLinkedList<int> sut = new();
            sut.AddFirst(2);

            sut.InsertSorted(1);

            Assert.Equal(1, sut.First.Value);
            Assert.Equal(2, sut.First.Next.Value);
        }

        [Fact]
        public void InsertSorted_IfValueInMiddle_ShouldKeepListSorted()
        {
            HDLinkedList<int> sut = new();
            sut.AddFirst(1);
            sut.AddLast(3);
            var expectedResult = "1 2 3";

            sut.InsertSorted(2);
            var result = sut.ToString();

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void InsertSorted_IfValueGreaterThanAll_ShouldKeepListSorted()
        {
            HDLinkedList<int> sut = new();
            sut.AddFirst(1);
            sut.AddLast(2);
            var expectedResult = "1 2 3";

            sut.InsertSorted(3);
            var result = sut.ToString();

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Reverse_IfSingleNode_ShouldDoNothing()
        {
            HDLinkedList<int> sut = new();
            sut.AddFirst(1);

            sut.Reverse();

            Assert.Equal(1, sut.First.Value);
        }

        [Fact]
        public void Reserve_ShouldUpdateHead()
        {
            HDLinkedList<int> sut = new();
            sut.AddFirst(1);
            sut.AddLast(2);
            sut.AddLast(3);

            sut.Reverse();

            Assert.Equal(3, sut.First.Value);
        }

        [Fact]
        public void Reserve_ShouldUpdateTail()
        {
            HDLinkedList<int> sut = new();
            sut.AddFirst(1);
            sut.AddLast(2);
            sut.AddLast(3);

            sut.Reverse();

            Assert.Equal(1, sut.Last.Value);
        }

        [Fact]
        public void Reserve_ShouldReverseList()
        {
            HDLinkedList<int> sut = new();
            sut.AddFirst(1);
            sut.AddLast(2);
            sut.AddLast(3);
            var expectedResult = "3 2 1";

            sut.Reverse();
            var result = sut.ToString();

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void RemoveDuplicates_ShouldRemoveDuplicateItems()
        {
            HDLinkedList<int> sut = new();
            sut.AddFirst(1);
            sut.AddLast(2);
            sut.AddLast(3);
            sut.AddLast(1);
            sut.AddLast(4);
            sut.AddLast(3);
            var expectedResult = "1 2 3 4";

            sut.RemoveDuplicates();
            var result = sut.ToString();

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void RemoveDuplicates_ShouldHaveCorrectHead()
        {
            HDLinkedList<int> sut = new();
            sut.AddFirst(1);
            sut.AddLast(2);
            sut.AddLast(3);
            sut.AddLast(1);
            sut.AddLast(4);
            sut.AddLast(3);

            sut.RemoveDuplicates();

            Assert.Equal(1, sut.First.Value);
        }

        [Fact]
        public void RemoveDuplicates_ShouldHaveCorrectTail()
        {
            HDLinkedList<int> sut = new();
            sut.AddFirst(1);
            sut.AddLast(2);
            sut.AddLast(3);
            sut.AddLast(1);
            sut.AddLast(4);
            sut.AddLast(3);

            sut.RemoveDuplicates();

            Assert.Equal(4, sut.Last.Value);
        }

        [Fact]
        public void RemoveDuplicates_ShouldUpdateCount()
        {
            HDLinkedList<int> sut = new();
            sut.AddFirst(1);
            sut.AddLast(2);
            sut.AddLast(3);
            sut.AddLast(1);
            sut.AddLast(4);
            sut.AddLast(3);

            sut.RemoveDuplicates();

            Assert.Equal(4, sut.Count);
        }
    }
}
