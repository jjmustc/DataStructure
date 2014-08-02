using System;
using System.Collections.Generic;
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

    }
}
