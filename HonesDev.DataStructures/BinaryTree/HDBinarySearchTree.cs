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

        public bool IsBalanced()
        {
            return GetTreeHeight(_root) != int.MinValue;
        }

        private int GetTreeHeight(TreeNode<T> node)
        {
            if (node is null)
            {
                return -1;
            }

            var leftHeight = GetTreeHeight(node.Left);
            if (leftHeight == int.MinValue)
            {
                return int.MinValue;
            }

            var rightHeight = GetTreeHeight(node.Right);
            if (rightHeight == int.MinValue)
            {
                return int.MinValue;
            }

            if (Math.Abs(leftHeight - rightHeight) > 1)
            {
                return int.MinValue;
            }
            else
            {
                return Math.Max(leftHeight, rightHeight) + 1;
            }
        }

        public TreeNode<T> GetLowestCommonAncestor(T first, T second)
        {
            var node = _root;
            while(node != null)
            {
                if (node.Value.CompareTo(first) > 0 && node.Value.CompareTo(second) > 0)
                {
                    node = node.Left;
                }
                else if (node.Value.CompareTo(first) < 0 && node.Value.CompareTo(second) < 0)
                {
                    node = node.Right;
                }
                else
                {
                    break;
                }
            }
            return node;
        }

        public TreeNode<T> GetKthSmallestNode(int k)
        {
            var count = 0;
            return FindKthSmallest(_root, k, ref count);
        }

        private TreeNode<T> FindKthSmallest(TreeNode<T> node, int k, ref int count)
        {
            if (node is null)
            {
                return null;
            }

            var left = FindKthSmallest(node.Left, k, ref count);

            if (left != null)
            {
                return left;
            }

            count++;

            if(count == k)
            {
                return node;
            }

            return FindKthSmallest(node.Right, k, ref count);
;        }
    }

    public record TreeNode<T>
    {
        public T Value { get; init; }
        public TreeNode<T> Left { get; set; }
        public TreeNode<T> Right { get; set; }

        public override string ToString() => $"{Value} ";
    }
}
