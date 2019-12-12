using System;
using System.Collections.Generic;
using System.Text;

namespace QuickSortAndMergeSort
{
    /// <summary>
    /// Structure, that sorts input array by QuickSort algorithm
    /// </summary>
    public struct QuickSort
    {
        /// <summary>
        /// Main algorithm part
        /// </summary>
        /// <param name="arr">Array of elements, that will be sorted</param>
        /// <param name="begin">start of part to sort</param>
        /// <param name="end">end of part to sort</param>
        public static void Sort(int[] arr, int begin, int end)
        {
            int pivot = arr[(begin + ((end - begin) / 2))];
            int left = begin;
            int right = end;
            while (left <= right)
            {
                while (arr[left] < pivot)
                {
                    left++;
                }

                while (arr[right] > pivot)
                {
                    right--;
                }

                if (left <= right)
                {
                    Swap(arr, left, right);
                    left++;
                    right--;
                }
            }

            if (begin < right)
            {
                Sort(arr, begin, left - 1);
            }

            if (end > left)
            {
                Sort(arr, right + 1, end);
            }
        }

        /// <summary>
        /// Makes elements x and y of the array swap their places
        /// </summary>
        /// <param name="items"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private static void Swap(int[] items, int x, int y)
        {
            int temp = items[x];
            items[x] = items[y];
            items[y] = temp;
        }
    }
}
