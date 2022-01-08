using System;
using System.Text;
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

        [Fact]
        public void Search_IfEmpty_ShouldReturnNull()
        {
            HDBinarySearchTree<int> sut = new();

            var node = sut.Search(1);

            Assert.Null(node);
        }

        [Fact]
        public void Search_IfExists_ShouldReturnNode()
        {
            HDBinarySearchTree<int> sut = new();
            sut.Insert(4);
            sut.Insert(2);
            sut.Insert(8);
            sut.Insert(6);
            sut.Insert(3);

            var node = sut.Search(6);

            Assert.NotNull(node);
        }

        [Fact]
        public void Search_IfNotExists_ShouldReturnNull()
        {
            HDBinarySearchTree<int> sut = new();
            sut.Insert(4);
            sut.Insert(2);
            sut.Insert(8);
            sut.Insert(6);
            sut.Insert(3);

            var node = sut.Search(10);

            Assert.Null(node);
        }

        [Fact]
        public void InOrderTraversal_ShouldListsItemsInOrder()
        {
            HDBinarySearchTree<int> sut = new();
            sut.Insert(4);
            sut.Insert(2);
            sut.Insert(8);
            sut.Insert(6);
            sut.Insert(3);
            var expectedResult = "2 3 4 6 8";
            StringBuilder stringBuilder = new();

            sut.InOrderTraversal(sut.Root, stringBuilder);

            Assert.Equal(expectedResult, stringBuilder.ToString().Trim());
        }

        [Fact]
        public void PreOrderTraversal_ShouldListsItemsPreOrder()
        {
            HDBinarySearchTree<int> sut = new();
            sut.Insert(4);
            sut.Insert(2);
            sut.Insert(8);
            sut.Insert(6);
            sut.Insert(3);
            var expectedResult = "4 2 3 8 6";
            StringBuilder stringBuilder = new();

            sut.PreOrderTraversal(sut.Root, stringBuilder);

            Assert.Equal(expectedResult, stringBuilder.ToString().Trim());
        }

        [Fact]
        public void PostOrderTraversal_ShouldListsItemsPostOrder()
        {
            HDBinarySearchTree<int> sut = new();
            sut.Insert(4);
            sut.Insert(2);
            sut.Insert(8);
            sut.Insert(6);
            sut.Insert(3);
            var expectedResult = "3 2 6 8 4";
            StringBuilder stringBuilder = new();

            sut.PostOrderTraversal(sut.Root, stringBuilder);

            Assert.Equal(expectedResult, stringBuilder.ToString().Trim());
        }

    }
}
