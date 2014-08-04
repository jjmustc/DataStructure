using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class TreeAlgorithm
    {
        public void InOrderTraversal(TreeNode<int> root)
        {
            if (root == null)
            {
                return;
            }

            TreeNode<int> currentNode = root;
            InOrderTraversal(currentNode.LeftNode);
            Console.WriteLine(currentNode.Value);
            InOrderTraversal(currentNode.RightNode);
        }

        public void InOrderTraversalNonRecurse(TreeNode<int> root)
        {
            Stack<TreeNode<int>> stack = new Stack<TreeNode<int>>();

            Console.WriteLine(root);
            TreeNode<int> temp = root;
            while (temp != null)
            {
                Console.WriteLine(temp.LeftNode);
                if (temp.RightNode != null)
                {
                    stack.Push(temp.RightNode);
                }

                temp = temp.LeftNode;
            }
        }

        public void PreOrderTraversal(TreeNode<int> root)
        {
            if (root == null)
            {
                return;
            }

            TreeNode<int> currentNode = root;
            Console.WriteLine(currentNode.Value);
            PreOrderTraversal(currentNode.LeftNode);
            PreOrderTraversal(currentNode.RightNode);            
        }

        public void PostOrderTraversal(TreeNode<int> root)
        {
            if (root == null)
            {
                return;
            }

            TreeNode<int> currentNode = root;
            PostOrderTraversal(currentNode.LeftNode);
            PostOrderTraversal(currentNode.RightNode);
            Console.WriteLine(currentNode.Value);
        }
    }
}
