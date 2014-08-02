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
            TestSegmentIntersec();
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
