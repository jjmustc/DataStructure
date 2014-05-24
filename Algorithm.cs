using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructure
{
    public class Algorithm
    {
        public static List<int> MergeTwoSortedList(List<int> list1, List<int> list2)
        {
            if(list1 == null || list1.Count == 0)
            {
                return (list2 == null || list2.Count == 0) ?  new List<int>() : list2;
            }
            else if (list2 == null || list2.Count == 0)
            {
                return (list1 == null || list1.Count == 0) ? new List<int>() : list1;
            }

            List<int> newList = new List<int>();

            int index1 = 0, index2 = 0;

            while (index1 < list1.Count && index2 < list2.Count)
            {
                newList.Add((list1[index1] <= list2[index2]) ? list1[index1++] : list2[index2++]);
            }

            if (index1 >= list1.Count)
            {
                newList.AddRange(list2.GetRange(index2, list2.Count-index2));
            }
            else
            {
                newList.AddRange(list1.GetRange(index1, list1.Count - index1));
            }

            return newList;
        }

        public static ListNode<int> MergeTwoSortedListByListNode(ListNode<int> list1, ListNode<int> list2)
        {
            if (list1 == null)
            {
                return list2;
            }
            else if (list2 == null)
            {
                return list1;
            }

            ListNode<int> rootNode = list1;
            ListNode<int> tailNode = list1;

            ListNode<int> listIndex1 = list1;
            ListNode<int> listIndex2 = list2;

            if (listIndex1.Value <= listIndex2.Value)
            {
                rootNode = listIndex1;
                tailNode = listIndex1;
                listIndex1 = listIndex1.NextNode;
            }
            else
            {
                rootNode = listIndex2;
                tailNode = listIndex2;
                listIndex2 = listIndex2.NextNode;
            }
            
            while (listIndex1 != null && listIndex2 != null)
            {
                if (listIndex1.Value <= listIndex2.Value)
                {
                    tailNode.NextNode = listIndex1;
                    tailNode = listIndex1;
                    listIndex1 = listIndex1.NextNode;
                }
                else
                {
                    tailNode.NextNode = listIndex2;
                    tailNode = listIndex2;
                    listIndex2 = listIndex2.NextNode;
                }                
            }

            if (listIndex1 == null)
            {
                tailNode.NextNode = listIndex2;
            }
            else
            {
                tailNode.NextNode = listIndex1;
            }

            return rootNode;
        }

        /// <summary>
        /// check whether two linear segments intersect on the plane 
        /// </summary>
        /// <param name="seg1"></param>
        /// <param name="seg2"></param>
        /// <returns></returns>
        public static bool CheckSegmentIntersection(Segment seg1, Segment seg2)
        {
            bool isSameSide1 = CheckPointOnSameSide(seg1, seg2);
            bool isSameSide2 = CheckPointOnSameSide(seg2, seg1);

            return (!isSameSide1) & (!isSameSide2);
        }
        
        /// <summary>
        /// check the points on targetSeg is on the same side of a segment
        /// </summary>
        /// <param name="seg"></param>
        /// <param name="targetSeg"></param>
        /// <returns></returns>
        private static bool CheckPointOnSameSide(Segment seg, Segment targetSeg)
        {
            PointLocation location1 = CheckPointLocation(seg, targetSeg.P1);
            PointLocation location2 = CheckPointLocation(seg, targetSeg.P2);
            return Convert.ToBoolean(location1 & location2);
        }

        /// <summary>
        /// Check point location toward a segment 
        /// </summary>
        /// <param name="seg"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        private static PointLocation CheckPointLocation(Segment seg, Point point)
        {
            double yValue = 0.0;
            if ((seg.Slope != null) && (seg.Intercept != null))
            {
                yValue = (double)seg.Slope * point.X + (double)seg.Intercept;

                if (point.Y > yValue)
                    return PointLocation.Above;
                else
                    if (point.Y == yValue)
                        return PointLocation.OnSeg;
                    else
                        return PointLocation.Below;
            }
            else
            {
                if (point.X == seg.P1.X)
                {
                    if (point.Y > Math.Max(seg.P2.Y, seg.P1.Y))
                        return PointLocation.Above;
                    else
                        if (point.Y < Math.Min(seg.P2.Y, seg.P1.Y))
                            return PointLocation.Below;
                        else
                            return PointLocation.OnSeg;
                }
                else
                {
                    return (point.X > seg.P1.X) ? PointLocation.Below : PointLocation.Above;
                }
            }
        }
    }

    [Flags]
    public enum PointLocation
    { 
        OnSeg = 0,
        Above = 1,
        Below = 2
    }

    public struct Segment
    {
        public Point P1, P2;
        
        public double? Slope
        {
            get 
            {
                if (P2.X != P1.X)
                    return (P2.Y - P1.Y) / (P2.X - P1.X);
                return null;
            }
        }

        public double? Intercept
        {
            get
            {
                if (P2.X != P1.X)
                    return (P2.X * P1.Y - P1.X * P2.Y) / (P2.X - P1.X);
                return null;
            }
        }
    }

    public struct Point
    {
        public double X;
        public double Y;
    }
}
