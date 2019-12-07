using System;


namespace NET.W._2019.Shchahlou._10
{
    /// <summary>
    /// Structure with methods to sort jugged array by some feature.
    /// </summary>
    public struct BubbleSort
    {
        /// <summary>
        /// Delegate, which incapsulates logic to compare 
        /// massives number1 and number2
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        private delegate bool DoBubble(int[] n1, int[] n2);

        public int[][] AscendingSumOfLines(params int[][] M)
        {
            static bool BiggestSum(int[] arr1, int[] arr2)
            {
                return arr1.Sum() > arr2.Sum();
            }

            Sort(BiggestSum, ref M);
            return M;
        }

        public int[][] DecreasingSumOfLines(params int[][] M)
        {
            static bool SmallestSum(int[] arr1, int[] arr2)
            {
                return arr1.Sum() < arr2.Sum();
            }

            Sort(SmallestSum, ref M);
            return M;
        }

        public int[][] AscendingMaxElementValue(params int[][] M)
        {
            static bool BiggestElementIncrease(int[] arr1, int[] arr2)
            {
                int biggest1 = Int32.MinValue;
                int biggest2 = Int32.MinValue;
                foreach (int val1 in arr1)
                {
                    biggest1 = (val1 > biggest1) ? val1 : biggest1;
                }

                foreach (int val2 in arr2)
                {
                    biggest2 = (val2 > biggest2) ? val2 : biggest2;
                }

                return biggest1 > biggest2;
            }
            Sort(BiggestElementIncrease, ref M);
            return M;
        }

        public int[][] DecreasingMaxElementValue(params int[][] M)
        {
            static bool BiggestElementDecrease(int[] arr1, int[] arr2)
            {
                int biggest1 = Int32.MinValue;
                int biggest2 = Int32.MinValue;
                foreach (int val1 in arr1)
                {
                    biggest1 = (val1 > biggest1) ? val1 : biggest1;
                }

                foreach (int val2 in arr2)
                {
                    biggest2 = (val2 > biggest2) ? val2 : biggest2;
                }

                return biggest1 < biggest2;
            }

            Sort(BiggestElementDecrease, ref M);
            return M;
        }

        public int[][] AscendingMinElementValue(params int[][] M)
        {
            static bool MinElementIncrease(int[] arr1, int[] arr2)
            {
                int smallest1 = Int32.MaxValue;
                int smallest2 = Int32.MaxValue;
                foreach (int val1 in arr1)
                {
                    smallest1 = (val1 > smallest1) ? smallest1 : val1;
                }

                foreach (int val2 in arr2)
                {
                    smallest2 = (val2 > smallest2) ? smallest2 : val2;
                }

                return smallest1 > smallest2;
            }

            Sort(MinElementIncrease, ref M);
            return M;
        }

        public int[][] DecreasingMinElementValue(params int[][] M)
        {
            static bool MinElementDecrease(int[] arr1, int[] arr2)
            {
                int smallest1 = int.MaxValue;
                int smallest2 = int.MaxValue;
                foreach (int val1 in arr1)
                {
                    smallest1 = (val1 > smallest1) ? smallest1 : val1;
                }

                foreach (int val2 in arr2)
                {
                    smallest2 = (val2 > smallest2) ? smallest2 : val2;
                }

                return smallest1 < smallest2;
            }

            Sort(MinElementDecrease, ref M);
            return M;
        }

        private static void Bubble(ref int[] obj1, ref int[] obj2)
        {
            int[] temp = obj1;
            obj1 = obj2;
            obj2 = temp;
        }

        private static void Sort(DoBubble inCase, ref int[][] M)
        {
            int Len = M.Length;
            for (int i = 0; i < Len; i++)
            {
                for (int j = 1; j < Len; j++)
                {
                    if (inCase.Invoke(M[j], M[j - 1]))
                    {
                        Bubble(ref M[j], ref M[j - 1]);
                    }
                }
            }
        }
    }
}
