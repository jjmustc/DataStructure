using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructure
{
    public class SortAlgorithm
    {
        public static void HeapSort(int[] inputArray)
        {
            int length = inputArray.Length;

            // build heap (minimum top heap)
            for (int i = Math.Floor(length / 2); i>=0; i--)
            {
                HeapAdjust(inputArray, i);
            }

            // heap sort
            for(int i = length - 1; i >= 0; i--)
            {
                Console.WriteLine(inputArray[0]);
                SwapItem(inputArray, 0, i);
                HeapAdjust(inputArray, 0, i-1);
            }
        }

        private static void HeapAdjust(int[] inputArray, int nodeIndex, int largestlength)
        {            
            while(nodeIndex*2 <= largestlength)
            {
                if(nodeIndex*2 + 1 >= largestlength)
                {
                    if(inputArray[nodeIndex] > inputArray[nodeIndex*2])
                    {
                        SwapItem(inputArray, nodeIndex, nodeIndex*2);
                        nodeIndex = nodeIndex*2;
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    if(inputArray[nodeIndex*2] < inputArray[nodeIndex*2 + 1])
                    {
                        SwapItem(inputArray, nodeIndex, nodeIndex*2);
                        nodeIndex = nodeIndex*2;
                    }
                    else
                    {
                        SwapItem(inputArray, nodeIndex, nodeIndex*2+1);
                        nodeIndex = nodeIndex*2+1;
                    }
                }
            }
        }

        private static SwapItem(int[] inputArray, int i, int j)
        {
            if (i >= inputArray.Length || j >=inputArray.Length)
            {
                throw new InvalidOperationException("out of index length for Swap");
            }

            int temp = inputArray[i];
            inputArray[i] = inputArray[j];
            inputArray[j] = temp;
        }

        public static void QuickSort(int[] inputArray)
        {
            if (inputArray == null || inputArray.Length == 0)
            {
                throw new NullReferenceException("empty or null");
            }

            int length = inputArray.Length;

            QuickSortCore(inputArray, 0, length - 1);
        }

        public static void QuickSortCore(int[] inputArray, int start, int end)
        {
            if (start == end)
                return;

            int left = start;
            int right = end;
            int pivotkey = left;

            int newPivot = PartitionArray(inputArray, pivotkey, left, right);
            QuickSortCore(inputArray, start, newPivot - 1);
            QuickSortCore(inputArray, newPivot + 1, end);         
        }

        private static int PartitionArray(int[] array, int pivotkey, int left, int right)
        {
            if (left > right || right >= array.Length || pivotkey < left || pivotkey > right)
            {
                throw new Exception("invalid index in PartitionArray: " + pivotkey + " " + left + " " + right);
            }

            while (left < right)
            {
                while (pivotkey < right)
                {
                    if (array[right] < array[pivotkey])
                    {
                        int temp = array[right];
                        array[right] = array[pivotkey];
                        array[pivotkey] = temp;
                        pivotkey = right;
                        right--;
                        break;
                    }
                    else
                    {
                        right--;
                    }
                }

                while (left < pivotkey)
                {
                    if (array[left] > array[pivotkey])
                    {
                        int temp = array[left];
                        array[left] = array[pivotkey];
                        array[pivotkey] = temp;
                        pivotkey = left;
                        left++;
                        break;
                    }
                    else
                    {
                        left++;
                    }
                }
            }

            return pivotkey;
        }
    }
}
