using System;
using System.Collections.Generic;
using System.Text;

namespace QuickSortAndMergeSort
{
    struct QuickSort
    {
        public static void Sort(int[] arr, int begin, int end)
        {
            int pivot = arr[(begin + (end - begin) / 2)];
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
                    swap(arr, left, right);
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
        static void swap(int[] items, int x, int y)
        {
            int temp = items[x];
            items[x] = items[y];
            items[y] = temp;
        }
    }
}
