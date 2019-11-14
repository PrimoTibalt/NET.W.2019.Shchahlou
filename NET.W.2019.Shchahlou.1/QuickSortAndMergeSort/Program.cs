using System;

namespace QuickSortAndMergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 4, 7, 3, 5, 8 };
            QuickSort.Sort(arr, 0, arr.Length - 1);
            int[] newArr = { 4, 7, 3, 5, 8 };
            MergeSort.Sort(newArr);
            Console.WriteLine();
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine("{0}-{1} quick", arr[i], i);
                Console.WriteLine("{0}-{1} merge", newArr[i], i);
            }
            Console.ReadLine();

        }
    }
}
