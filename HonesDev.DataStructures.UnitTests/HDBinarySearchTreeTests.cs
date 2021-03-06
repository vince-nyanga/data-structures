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
            sut.Insert(6);
            sut.Insert(1);
            sut.Insert(3);
            sut.Insert(5);
            sut.Insert(7);
            var expectedResult = "1 2 3 4 5 6 7";
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
            sut.Insert(6);
            sut.Insert(1);
            sut.Insert(3);
            sut.Insert(5);
            sut.Insert(7);
            var expectedResult = "4 2 1 3 6 5 7";
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
            sut.Insert(6);
            sut.Insert(1);
            sut.Insert(3);
            sut.Insert(5);
            sut.Insert(7);
            var expectedResult = "1 3 2 5 7 6 4";
            StringBuilder stringBuilder = new();

            sut.PostOrderTraversal(sut.Root, stringBuilder);

            Assert.Equal(expectedResult, stringBuilder.ToString().Trim());
        }

        [Fact]
        public void IsBalanced_IfEmpty_ShouldBeTrue()
        {
            HDBinarySearchTree<int> sut = new();

            var result = sut.IsBalanced();

            Assert.True(result);
        }

        [Fact]
        public void IsBalanced_IfTreeIsBalanced_ShouldReturnTrue()
        {
            HDBinarySearchTree<int> sut = new();
            sut.Insert(4);
            sut.Insert(2);
            sut.Insert(6);
            sut.Insert(1);
            sut.Insert(3);
            sut.Insert(5);
            sut.Insert(7);

            var result = sut.IsBalanced();

            Assert.True(result);
        }

        [Fact]
        public void IsBalanced_IfTreeIsSkewed_ShouldReturnFalse()
        {
            HDBinarySearchTree<int> sut = new();
            sut.Insert(4);
            sut.Insert(2);
            sut.Insert(10);
            sut.Insert(5);
            sut.Insert(7);
            sut.Insert(8);

            var result = sut.IsBalanced();

            Assert.False(result);
        }

        [Fact]
        public void GetLowestCommonAncestor_IfEmpty_ShouldReturnNull()
        {
            HDBinarySearchTree<int> sut = new();

            var node = sut.GetLowestCommonAncestor(5,3);

            Assert.Null(node);
        }

        [Fact]
        public void GetLowestCommonAncestor_IfExists_ShouldReturnNode()
        {
            HDBinarySearchTree<int> sut = new();
            sut.Insert(4);
            sut.Insert(2);
            sut.Insert(6);
            sut.Insert(1);
            sut.Insert(3);

            var node = sut.GetLowestCommonAncestor(1, 3);

            Assert.Equal(2, node.Value);
        }

        [Fact]
        public void GetLowestCommonAncestor_OwnDescendant_ShouldReturnNode()
        {
            HDBinarySearchTree<int> sut = new();
            sut.Insert(4);
            sut.Insert(2);
            sut.Insert(6);
            sut.Insert(1);
            sut.Insert(3);

            var node = sut.GetLowestCommonAncestor(1, 2);

            Assert.Equal(2, node.Value);
        }

        [Fact]
        public void GetKthSmallestNode_IfEmpty_ShouldReturnNull()
        {
            HDBinarySearchTree<int> sut = new();

            var node = sut.GetKthSmallestNode(1);

            Assert.Null(node);
        }

        [Fact]
        public void GetKthSmallestNode_IfNotExist_ShouldReturnNull()
        {
            HDBinarySearchTree<int> sut = new();
            sut.Insert(1);

            var node = sut.GetKthSmallestNode(2);

            Assert.Null(node);
        }

        [Fact]
        public void GetKthSmallestNode_IfExists_ShouldReturnNode()
        {
            HDBinarySearchTree<int> sut = new();
            sut.Insert(5);
            sut.Insert(6);
            sut.Insert(3);
            sut.Insert(4);
            sut.Insert(2);
            sut.Insert(1);

            var node = sut.GetKthSmallestNode(3);

            Assert.Equal(3, node.Value);
        }

        [Fact]
        public void Delete_IfEmpty_ShouldReturnNull()
        {
            HDBinarySearchTree<int> sut = new();

            var node = sut.Delete(1);

            Assert.Null(node);
        }

        [Fact]
        public void Delete_ShouldRemoveNode()
        {
            HDBinarySearchTree<int> sut = new();
            sut.Insert(4);
            sut.Insert(2);
            sut.Insert(6);
            sut.Insert(3);
            sut.Insert(5);
            sut.Insert(7);
            sut.Insert(1);

            sut.Delete(2);

            var expectedResult = "1 3 4 5 6 7";
            StringBuilder stringBuilder = new();

            sut.InOrderTraversal(sut.Root, stringBuilder);

            Assert.Equal(expectedResult, stringBuilder.ToString().Trim());
        }

        [Fact]
        public void Delete_IfRoot_ShouldReplaceWithSmallestOnRight()
        {
            HDBinarySearchTree<int> sut = new();
            sut.Insert(4);
            sut.Insert(2);
            sut.Insert(6);
            sut.Insert(3);
            sut.Insert(5);
            sut.Insert(7);
            sut.Insert(1);

            sut.Delete(4);

            Assert.Equal(5, sut.Root.Value);
        }
    }
}
