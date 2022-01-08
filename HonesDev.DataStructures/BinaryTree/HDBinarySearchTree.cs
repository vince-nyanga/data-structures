using System;
using System.Text;

namespace HonesDev.DataStructures.BinaryTree
{
    public class HDBinarySearchTree<T> where T : IComparable
    {
        private TreeNode<T> _root;
        public TreeNode<T> Root { get => _root; }

        public void Insert(T value)
        {
            TreeNode<T> newNode = new() { Value = value };

            if (_root is null)
            {
                _root = newNode;
                return;
            }

            TreeNode<T> node = _root;
            TreeNode<T> parent = null;
          
            while (node != null)
            {
                parent = node;
                if (value.CompareTo(node.Value) <= 0)
                {
                    node = node.Left;
                }
                else
                {
                    node = node.Right;
                }
            }

            if (value.CompareTo(parent.Value) <= 0)
            {
                parent.Left = newNode;
            }
            else
            {
                parent.Right = newNode;
            }
        }

        public TreeNode<T> Search(T value)
        {
            return FindNode(_root, value);
        }


        private TreeNode<T> FindNode(TreeNode<T> node, T value)
        {
            if (node is null)
            {
                return null;
            }

            if (value.CompareTo(node.Value) == 0)
            {
                return node;
            }

            if (value.CompareTo(node.Value)< 0)
            {
                return FindNode(node.Left, value);
            }

            return FindNode(node.Right, value);
        }

        public void InOrderTraversal(TreeNode<T> node, StringBuilder stringBuilder)
        {
            if (node is null)
            {
                return;
            }

            InOrderTraversal(node.Left, stringBuilder);

            // visit node
            stringBuilder.Append(node.ToString());

            InOrderTraversal(node.Right, stringBuilder);
        }

        public void PreOrderTraversal(TreeNode<T> node, StringBuilder stringBuilder)
        {
            if (node is null)
            {
                return;
            }

            // visit node
            stringBuilder.Append(node.ToString());
            PreOrderTraversal(node.Left, stringBuilder);
            PreOrderTraversal(node.Right, stringBuilder);
        }

        public void PostOrderTraversal(TreeNode<T> node, StringBuilder stringBuilder)
        {
            if (node is null)
            {
                return;
            }

            PostOrderTraversal(node.Left, stringBuilder);

            PostOrderTraversal(node.Right, stringBuilder);

            // visit node
            stringBuilder.Append(node.ToString());
        }
    }

    public record TreeNode<T>
    {
        public T Value { get; init; }
        public TreeNode<T> Left { get; set; }
        public TreeNode<T> Right { get; set; }

        public override string ToString() => $"{Value} ";
    }
}
