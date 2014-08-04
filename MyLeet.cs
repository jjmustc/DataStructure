﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;

namespace DataStructure
{
    public class MyLeet
    {
        public List<string> GenerateParentheses(int number)
        {
            List<string> results = new List<string>();

            GetParentheses(results, "", number, 0, 0);

            return results;
        }

        private void GetParentheses(List<string> results, string oneResult, int number, int leftNumber, int rightNumber)
        {

            if (leftNumber == number && rightNumber == number)
            {
                results.Add(oneResult);
                return;
            }

            if (leftNumber < number)
            {
                oneResult += "(";
                GetParentheses(results, oneResult, number, leftNumber + 1, rightNumber);
            }

            if (rightNumber < number && rightNumber < number)
            {                
                oneResult += ")";
                GetParentheses(results, oneResult, number, leftNumber, rightNumber + 1);
            }

        }

        public int LongestValidParenthese(string input)
        {
            if (input == null || input.Length == 0)
            {
                throw new NullReferenceException("input is null");
            }

            Stack<int> leftParenStack = new Stack<int>();

            int validNum = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    leftParenStack.Push(input[i]);
                }
                else if(input[i] == ')' && leftParenStack.Count != 0)
                {
                    leftParenStack.Pop();
                    validNum++;
                }
            }

            return validNum;
        }

        public ListNode<int> SwapPairs(ListNode<int> list)
        {
            ListNode<int> firstNode = null;
            if (list != null && list.NextNode != null)
            {
                firstNode = list.NextNode;
            }

            ListNode<int> tempNode = null;

            while (list != null && list.NextNode != null)
            {
                list = SwapNode(list, list.NextNode);
                if (tempNode != null)
                {
                    tempNode.NextNode = list;
                }
                tempNode = list.NextNode;
                list = list.NextNode.NextNode;
            }

            return firstNode;
        }

        private ListNode<int> SwapNode(ListNode<int> first, ListNode<int> second)
        {
            first.NextNode = second.NextNode;
            second.NextNode = first;
            return second;
        }

        public ListNode<int> ReverseList(ListNode<int> root)
        {
            ListNode<int> temp = null;
            ListNode<int> previous = null;
            ListNode<int> current = root;
            ListNode<int> next = current.NextNode;
            while (current != null && next != null)
            {
                temp = next.NextNode;
                next.NextNode = current;
                current.NextNode = previous;
                previous = current;
                current = next;
                next = temp;
            }

            return current;
        }

        public void SearchForRange(int[] input, int v, out int leftIndex, out int rightIndex)
        {
            leftIndex = -1;
            rightIndex = -1;

            if (input == null || input.Length == 0)
            {
                throw new NullReferenceException("input is not valid");
            }

            int l = 0, r = input.Length - 1;
            int findIndex = -1;
            while (l <= r && r >= 0 && l <= input.Length - 1)
            {
                int mid = (int)Math.Floor((decimal)(r + l) / 2);
                if (v == input[mid])
                {
                    findIndex = mid;
                    break;
                }
                if (v < input[mid])
                {
                    r = mid - 1;
                }
                else
                {
                    l = mid + 1;
                }
            }

            if (findIndex != -1)
            {
                leftIndex = findIndex;
                rightIndex = findIndex;
                while (leftIndex - 1>= 0)
                {
                    if(input[leftIndex-1] != input[findIndex])
                    {
                        break;
                    }

                    leftIndex--;
                }

                while (rightIndex + 1 <= input.Length - 1)
                {
                    if (input[rightIndex + 1] != input[findIndex])
                    {
                        break;
                    }

                    rightIndex++;
                }
            }
        }

        public List<string> CombinationSum(int[] input, int sum)
        {
            if (input == null || input.Length == 0)
            {
                throw new NullReferenceException("input is null");
            }

            List<string> results = new List<string>();

            GenerateSum(results, input, string.Empty, sum);

            return results;
        }

        private void GenerateSum(List<string> results, int[] input, string s, int sum)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (s.Length > 0 && input[i] < (s[s.Length - 1] - '0'))
                {
                    continue;
                }

                if (sum - input[i] == 0)
                {
                    s += " " + input[i].ToString();
                    results.Add(s);
                    return;
                }
                else if (sum - input[i] > 0)
                {
                    s += " " + input[i].ToString();
                    GenerateSum(results, input, s, sum - input[i]);
                }
                else
                {
                    s = String.Empty;
                    return;
                }
            }
        }

        public List<string> PermutationDFS(string input)
        {
            List<string> results = new List<string>();

            for (int i = 0; i < input.Length; i++)
            {
                string temp = input;
                results.AddRange(Perm(input.Substring(i, 1), temp.Remove(i, 1)));
            }

            return results;
        }

        private List<string> Perm(string a, string c)
        {
            if (c.Length == 1)
            {
                return new List<string>() {a + c};
            }

            List<string> tempResults = new List<string>();
            for (int i = 0; i < c.Length; i++)
            {
                string temp = c;
                tempResults.AddRange(Perm(c.Substring(i, 1), temp.Remove(i, 1)));
            }

            List<string> results = new List<string>();

            tempResults.ForEach(i => results.Add(a + i));

            return results;
        }

        public int GetTreeDepth(TreeNode<int> root)
        {
            return GetTreeDepthRecursive(root, 0);
        }

        private int GetTreeDepthRecursive(TreeNode<int> root, int depth)
        {
            if (root == null)
            {
                return depth;
            }

            int leftDepth = GetTreeDepthRecursive(root.LeftNode, depth + 1);
            int rightDepth = GetTreeDepthRecursive(root.RightNode, depth + 1);

            return Math.Max(leftDepth, rightDepth);
        }

        public bool FindPathSum(TreeNode<int> root, int sum)
        {
            return FindPathSumRecursive(root, sum, 0, false);
        }

        private bool FindPathSumRecursive(TreeNode<int> node, int sum, int currentSum, bool find)
        {
            if (find)
            {
                return true;
            }

            if (node == null)
            {
                return currentSum == sum;
            }

            bool findLeft = FindPathSumRecursive(node.LeftNode, sum, currentSum + node.Value, find);

            find = findLeft;

            bool findRight = FindPathSumRecursive(node.RightNode, sum, currentSum + node.Value, find);

            find = findRight || findLeft;

            return find;
        }

        public List<string> FindAllSumPath(TreeNode<int> root, int sum)
        {
            List<string> results = new List<string>();

            Stack<int> stack = new Stack<int>();

            FindAllSumPathRecursive(root, results, stack, sum, 0);

            return results;
        }

        private void FindAllSumPathRecursive(TreeNode<int> node, List<string> results, Stack<int> stack, int sum, int currentSum)
        {
            if (node == null)
            {
                return;
            }

            if (node.LeftNode == null && node.RightNode == null)
            {
                if (currentSum + node.Value == sum)
                {
                    int[] array = new int[stack.Count];
                    stack.CopyTo(array, 0);
                    results.Add(node.Value + " " + string.Join(" ", array));
                }

                return;
            }

            stack.Push(node.Value);

            FindAllSumPathRecursive(node.LeftNode, results, stack, sum, currentSum + node.Value);

            FindAllSumPathRecursive(node.RightNode, results, stack, sum, currentSum + node.Value);

            stack.Pop();
        }

        public bool SymmetricTree(TreeNode<int> root)
        {
            if (root == null)
            {
                throw new NullReferenceException("root is null");
            }

            if (root.LeftNode != null && root.RightNode != null)
            {
                return IsSubTreeSymmetric(root.LeftNode, root.RightNode);
            }

            return false;
        }

        private bool IsSubTreeSymmetric(TreeNode<int> leftNode, TreeNode<int> rightNode)
        {
            if (leftNode == null || rightNode == null)
            {
                if((leftNode == null && rightNode != null) || (leftNode != null && rightNode == null))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            
            if (leftNode.Value != rightNode.Value)
            {
                return false;
            }

            bool leftSymmetric = IsSubTreeSymmetric(leftNode.LeftNode, rightNode.RightNode);
            bool rightSymmetric = IsSubTreeSymmetric(leftNode.RightNode, rightNode.LeftNode);

            return leftSymmetric && rightSymmetric;
        }
    }
}
