using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructure
{
    class Program
    {
        static void Main(string[] args)
        {
            //TreeTraverse();

            //TestTreeDepth();

            //TestGetNodePath();
            //TestSegmentIntersec();
            //TestMyLeet();
            //TestReverseList();
            //TestLongestValidParenthese();
            //TestSearchForRange();
            //TestCombinationSum();
            //TestPermutationRecursive();
            //TestFindAllSumPath();
            //TestRestoreIPAddress();
            TestFindMinimumWindow();
        }

        private static void TestMyLeet()
        {
            MyLeet myleet = new MyLeet();

            TestSwapPairs();
        }

        private static void TestSwapPairs()
        {
            ListNode<int> root = Utility.CreateRandomList(6);
            ListNode<int> firstNode = root;
            while (firstNode != null)
            {
                Console.Write(firstNode.Value + "->");
                firstNode = firstNode.NextNode;
            }

            Console.WriteLine();

            MyLeet myLeet = new MyLeet();
            ListNode<int> newRoot = myLeet.SwapPairs(root);

            while (newRoot != null)
            {
                Console.Write(newRoot.Value + "->");
                newRoot = newRoot.NextNode;
            }
        }

        private static void TestReverseList()
        {
            ListNode<int> root = Utility.CreateRandomList(6);
            ListNode<int> firstNode = root;
            while (firstNode != null)
            {
                Console.Write(firstNode.Value + "->");
                firstNode = firstNode.NextNode;
            }
            
            Console.WriteLine();

            MyLeet myLeet = new MyLeet();
            ListNode<int> newRoot = myLeet.ReverseList(root);

            while (newRoot != null)
            {
                Console.Write(newRoot.Value + "->");
                newRoot = newRoot.NextNode;
            }
        }

        private static void TestLongestValidParenthese()
        {
            MyLeet myLeet = new MyLeet();
            Console.WriteLine(myLeet.LongestValidParenthese("((())"));
            Console.WriteLine(myLeet.LongestValidParenthese("(("));
            Console.WriteLine(myLeet.LongestValidParenthese("(()"));
        }

        private static void TestSearchForRange()
        {
            int[] input = new int[] {8, 8, 8, 8, 8};
            MyLeet myLeet = new MyLeet();
            int l = -1, r = -1;
            myLeet.SearchForRange(input, 8, out l, out r);
            Console.WriteLine(l + " " + r);
        }

        private static void TestCombinationSum()
        {
            int[] input = new[] {2, 3, 6, 7};

            MyLeet myLeet = new MyLeet();
            List<string> results = myLeet.CombinationSum(input, 7);
            results.ForEach(i => Console.WriteLine(i));
        }

        private static void TestPermutationRecursive()
        {
            MyLeet myLeet = new MyLeet();
            List<string> results = myLeet.PermutationDFS("abcd");

            results.ForEach(i => Console.WriteLine(i.ToString()));
        }

        private static void TestFindAllSumPath()
        {
            TreeNode<int> root = new TreeNode<int>(3);
            root.LeftNode = new TreeNode<int>(5);
            root.RightNode = new TreeNode<int>(7);
            root.LeftNode.LeftNode = new TreeNode<int>(2);
            root.LeftNode.RightNode = new TreeNode<int>(6);
            root.LeftNode.LeftNode.LeftNode = new TreeNode<int>(4);
            root.LeftNode.LeftNode.RightNode = new TreeNode<int>(6);
            root.LeftNode.RightNode.LeftNode = new TreeNode<int>(5);
            root.RightNode.LeftNode = new TreeNode<int>(9);

            MyLeet myLeet = new MyLeet();
            //Console.WriteLine(myLeet.GetTreeDepth(root));

            //Console.WriteLine(myLeet.FindPathSum(root, 18));

            myLeet.FindAllSumPath(root, 19).ForEach(i=>Console.WriteLine(i));
        }

        private static void TestRestoreIPAddress()
        {
            MyLeet myLeet = new MyLeet();
            List<string> results = myLeet.RestoreIPAddress("25525511135");
            if (results.Count > 0)
            {
                results.ForEach(i => Console.WriteLine(i));
            }
        }

        private static void TestFindMinimumWindow()
        {
            MyLeet myLeet = new MyLeet();
            Console.WriteLine(myLeet.FindMinimumWindow("adobecodebanc", "abc"));
        }

    /// <summary>
    /// Basic sample for intersec / Not-intersec
    /// ([1.0, 2.0], [2.0, 3.0]) ([1.0, 1.0], [2.0, 2.0])  - false
    /// ([1.0, 2.0], [2.0, 2.0]) ([1.0, 1.0], [2.0, 3.0])  - ture
    /// 
    /// one segment is vertical , other segment is random (vertical, horizontal ...)
    /// ([0,0], [0,2])  ([1,1], [1,3])  - false
    /// ([0,0], [0,2])  ([0,-2], [0,5])  - true
    /// ([0,0], [0,2])  ([0,-2], [1,3])  - false
    /// ([0,0], [0,2])  ([0, 1], [1,3])  - true
    /// 
    /// one segment is horizontal , other segment is random (vertical, horizontal ...)
    /// ([0,0], [2,0])  ([1,1], [2,3]   -false
    /// ([0,0], [2,0])  ([-2,0], [5,0])  - true
    /// ([0,0], [2,0])  ([-2,0], [1,3])  - false
    /// ([0,0], [2,0])  ([1,0], [1,3])  - true
    /// 
    /// segment is just a point, the other is random (point, pass the point ...)
    /// ([0,0], [0,0])  ([1,1], [2,3]   -false
    /// ([0,0], [0,0])  ([-1,1], [1,1]   -true
    /// ([0,0], [0,0])  ([1,1], [2,2]   -true
    /// ([0,0], [0,0])  ([1,1], [1,1]   -false
    /// 
    /// </summary>
    static void TestSegmentIntersec()
    {
        Segment seg1 = new Segment
        {
            P1 = new Point { X = 0.0, Y = 0.0 },
            P2 = new Point { X = 2.0, Y = 0.0 }
        };

        Segment seg2 = new Segment
        {
            P1 = new Point { X = 1.0, Y = 1.0},
            P2 = new Point { X = 1.0, Y = 3.0}
        };

        Console.WriteLine(Algorithm.CheckSegmentIntersection(seg1, seg2));
    }

        static void TreeTraverse()
        {
            TreeNode<int> root;
            root = Utility.CreateBinarySearchTree();
            //Console.WriteLine("InOrder");
            //Utility.InOrderTraverse(root);

            //Console.WriteLine("PreOsrder");
            //Utility.PreOrderTraverse(root);

            //Console.WriteLine("PostOsrder");
            //Utility.PostOrderTraverse(root);
        }

        static void TestTreeDepth()
        {
            TreeNode<int> root;
            root = Utility.CreateRandomTree();
            Console.WriteLine(Utility.GetTreeDepth(root));
        }

        static void TestGetNodePath()
        {
            TreeNode<int> root;
            root = Utility.CreateBinarySearchTree();

            TreeNode<int> node = root.LeftNode.RightNode;
            Console.WriteLine("candidate node is " + node.Value);

            if (node != null)
            {
                Stack<int> stack = new Stack<int>();
                Boolean hasNode = Utility.GetNodePath(root, node, stack);
                if (hasNode)
                {
                    Console.WriteLine(String.Join(" ", stack.Select(n => n.ToString()).ToArray()));
                }
                else
                {
                    Console.WriteLine("Not contain the node");
                }
            }
            else
            {
                Console.WriteLine("the node is null");
            }
        }


    }
}
