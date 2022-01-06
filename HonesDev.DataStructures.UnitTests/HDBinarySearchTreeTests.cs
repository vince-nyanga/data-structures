using System;
using HonesDev.DataStructures.BinaryTree;
using Xunit;

namespace HonesDev.DataStructures.UnitTests
{
    public class HDBinarySearchTreeTests
    {
        [Fact]
        public void Insert_WhenEmpty_ShouldSetRoot()
        {
            HDBinarySearchTree<int> sut = new();

            sut.Insert(4);

            Assert.Equal(4, sut.Root.Value);
        }

        [Fact]
        public void Insert_IfValueGreaterThanRoot_ShouldAddRight()
        {
            HDBinarySearchTree<int> sut = new();
            sut.Insert(4);

            sut.Insert(6);

            Assert.Equal(6, sut.Root.Right.Value);
        }

        [Fact]
        public void Insert_IfValueLessThanRoot_ShouldAddLeft()
        {
            HDBinarySearchTree<int> sut = new();
            sut.Insert(4);

            sut.Insert(2);

            Assert.Equal(2, sut.Root.Left.Value);
        }

    }
}
