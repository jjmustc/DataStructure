using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class SearchAlgorithm
    {
        public int BinarySearch(int[] array, int v)
        {
            int length = array.Length;

            int start = 0; 
            int end = array.Length - 1;
            int index = Math.Floor((start+end)/2);

            while (end >= start)
            {
                if (v == array[index])
                {
                    return index;
                }

                if (v < array[index])
                {
                    end = index - 1;                   
                }
                else
                {
                    start = index + 1;
                }

                index = Math.Floor((start + end) / 2);
            }

            return -1;
        }

        public int BinarySearchRecurse(int[] array, int v)
        {
            int length = array.Length;

            int start = 0;
            int end = array.Length - 1;

            return BinarySearchCore(array, v, start, end);
        }

        public int BinarySearchcore(int[] array, int v, int start, int end)
        {
            int index = Math.Floor((start + end) / 2);
            if(end < start)
            {
                return -1;
            }

            if (v == array[index])
            {
                return index;
            }

            if (v < array[index])
            {
                BinarySearchCore(array, start, index - 1);
            }
            else
            {
                BinarySearchcore(array, index + 1, end);
            }
        }
    }
}
