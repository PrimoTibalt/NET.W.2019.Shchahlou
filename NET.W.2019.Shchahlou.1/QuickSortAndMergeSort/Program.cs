using System;

namespace QuickSortAndMergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 4, 7, 3, 5, 8 };
            QuickSort.Sort(arr, 0, arr.Length - 1);
            Console.WriteLine();
            for (int i = 0; i < arr.Length; i++)
            {
               Console.Write("{0} ", arr[i]);
            }
            Console.ReadLine();

        }
    }
}
