using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructure
{
    public class Utility
    {
        private const int min = 0;
        private const int max = 100;

        public static ListNode<int> CreateRandomList(int length)
        {
            if (length < 0)
            {
                throw new ArgumentNullException();
            }

            ListNode<int> rootNode = new ListNode<int>(GetRandom(min, max));
            ListNode<int> tempNode = rootNode;

            while (--length > 0)
            {
                System.Threading.Thread.Sleep(200);
                tempNode.NextNode = new ListNode<int>(GetRandom(min, max));
                tempNode = tempNode.NextNode;
            }

            return rootNode;
        }

        public static TreeNode<int> CreateRandomBinarySearchTree(TreeNode<int> node, int level)
        {
            if (level <= 0)
            {
                return node;
            }

            TreeNode<int> left = new TreeNode<int>(GetRandom(0, node.Value) - 2);
            TreeNode<int> right = new TreeNode<int>(GetRandom(node.Value, node.Value + 10) + 2);
            node.LeftNode = CreateRandomBinarySearchTree(left, level - 1);
            node.RightNode = CreateRandomBinarySearchTree(right, level - 1);

            return node;
        }

        private static int GetRandom(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        public static TreeNode<int> CreateBinarySearchTree()
        {
            TreeNode<int> root = new TreeNode<int>(10);
            TreeNode<int> left = new TreeNode<int>(8);
            TreeNode<int> right = new TreeNode<int>(12);
            root.LeftNode = left;
            root.RightNode = right;

            left.LeftNode = new TreeNode<int>(6);
            left.RightNode = new TreeNode<int>(9);

            right.LeftNode = new TreeNode<int>(11);
            right.RightNode = new TreeNode<int>(13);

            return root;
        }

        public static TreeNode<int> CreateRandomTree()
        {
            TreeNode<int> root = new TreeNode<int>(10);
            TreeNode<int> left = new TreeNode<int>(8);
            TreeNode<int> right = new TreeNode<int>(12);
            root.LeftNode = left;
            root.RightNode = right;

            left.LeftNode = new TreeNode<int>(6);
            left.LeftNode.LeftNode = new TreeNode<int>(7);

            right.RightNode = new TreeNode<int>(13);
            
            right = right.RightNode;
            right.LeftNode = new TreeNode<int>(14);
            right.RightNode = new TreeNode<int>(15);

            return root;
        }

        public static int GetTreeDepth(TreeNode<int> node)
        {
            if(node == null)
                return 0;

            int leftdepth = GetTreeDepth(node.LeftNode);
            int rightdepth = GetTreeDepth(node.RightNode);

            return Math.Max(leftdepth, rightdepth) + 1;
        }

        public static TreeNode<int> GetCommonAncestor(TreeNode<int> root, TreeNode<int> node1, TreeNode<int> node2)
        {
            return root;
        }

        // not correct, should pop when the path is wrong
        public static bool GetNodePath(TreeNode<int> root, TreeNode<int> node, Stack<int> stack)
        {
            if (root == null)
                return false;

            stack.Push(root.Value);

            if (node == root)
            {
                return true;
            }

            if (GetNodePath(root.LeftNode, node, stack))
            {
                return true;
            }

            if (GetNodePath(root.RightNode, node, stack))
            {
                return true;
            }

            stack.Pop();

            return false;
        }



        // duplicated with GetTreeDepth
        public static int GetMaxTreeDepthAndNode(TreeNode<int> root, TreeNode<int> node )
        {
            if (root == null)
            {
                node = root;
                return 0;
            }

            int leftsum = 0, rightsum = 0;
            
            leftsum = GetMaxTreeDepthAndNode(root.LeftNode, node);
            rightsum = GetMaxTreeDepthAndNode(root.RightNode, node);

            return Math.Max(leftsum, rightsum) + 1;
        }

        public static int GetTreeMaxDistance(TreeNode<int> root)
        {
            if (root == null)
                return 0;

            int leftSum = 0, rightSum = 0;

            if (root.LeftNode != null)
            {
                leftSum = GetTreeDepth(root.LeftNode);
            }

            if (root.RightNode != null)
            {
                rightSum = GetTreeDepth(root.RightNode);
            }

            return leftSum + rightSum;
        }
    }

    public class ListNode<T>
    {
        T value;
        ListNode<T> nextNode;

        public ListNode(T v)
        {
            value = v;
        }

        public T Value
        {
            get { return value; }
            set { this.value = value; }
        }

        public ListNode<T> NextNode
        {
            get { return nextNode; }
            set { nextNode = value; }
        }

        public void Add(ListNode<T> node)
        {
            nextNode = node;
        }
    }

    public class TreeNode<T>
    {
        T value;
        TreeNode<T> leftNode;
        TreeNode<T> rightNode;

        public TreeNode(T v)
        {
            value = v;
        }

        public T Value
        {
            get { return value; }
            set { this.value = value; }
        }

        public TreeNode<T> LeftNode
        {
            get { return leftNode; }
            set { leftNode = value; }
        }

        public TreeNode<T> RightNode
        {
            get { return rightNode; }
            set { rightNode = value; }
        }
    }
}
