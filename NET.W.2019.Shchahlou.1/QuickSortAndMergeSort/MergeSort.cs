using System;
using System.Collections.Generic;
using System.Text;

namespace QuickSortAndMergeSort
{
    public class MergeSort
    {
        public static void Sort(int[] input, int low, int high)
        {
            if (low < high)
            {
                int middle = (low / 2) + (high / 2);
                Sort(input, low, middle);
                Sort(input, middle + 1, high);
                Merge(input, low, middle, high);
            }
        }

        public static void Sort(int[] input)
        {
            Sort(input, 0, input.Length - 1);
        }

        public static string PrintArray(int[] input)
        {
            string result = string.Empty;

            for (int i = 0; i < input.Length; i++)
            {
                result = result + input[i] + " ";
            }

            if (input.Length == 0)
            {
                result = "Array is empty.";
                return result;
            }
            else
            {
                return result;
            }
        }

        private static void Merge(int[] input, int low, int middle, int high)
        {
            int left = low;
            int right = middle + 1;
            int[] tmp = new int[(high - low) + 1];
            int tmpIndex = 0;

            while ((left <= middle) && (right <= high))
            {
                if (input[left] < input[right])
                {
                    tmp[tmpIndex] = input[left];
                    left++;
                }
                else
                {
                    tmp[tmpIndex] = input[right];
                    right++;
                }

                tmpIndex++;
            }

            if (left <= middle)
            {
                while (left <= middle)
                {
                    tmp[tmpIndex] = input[left];
                    left++;
                    tmpIndex++;
                }
            }

            if (right <= high)
            {
                while (right <= high)
                {
                    tmp[tmpIndex] = input[right];
                    right++;
                    tmpIndex++;
                }
            }

            for (int i = 0; i < tmp.Length; i++)
            {
                input[low + i] = tmp[i];
            }
        }
    }
}
