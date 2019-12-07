namespace NET.W._2019.Shchahlou._10
{
    using System.Collections.Generic;

    /// <summary>
    /// Structure with methods to sort jugged array by some feature.
    /// </summary>
    public struct BubbleSort
    {
        public delegate int Comparator(int[] x, int[] y);

        /// <summary>
        /// Call Sort with input type of sorting(integer Comparator(integer[], integer[])) and Matrix to sort
        /// This method sorts lines in array, not elements.
        /// </summary>
        /// <param name="comp">Some integer Method_Name(integer[], integer[]) for one line arrays</param>
        /// <param name="m">Jugged array to sort</param>
        /// <returns>Sorted jugged array</returns>
        public int[][] SortByComparator(Comparator comp, params int[][] m)
        {
            Sort(comp, ref m);
            return m;
        }

        /// <summary>
        /// Call Sort with input type of sorting(IComparer) and Matrix to sort
        /// This method sorts lines in array, not elements.
        /// </summary>
        /// <param name="type">Some comparer for one line arrays</param>
        /// <param name="m">Jugged array to sort</param>
        /// <returns>Sorted jugged array</returns>
        public int[][] SortByComparer(IComparer<int[]> type, params int[][] m)
        {
            Sort(type, ref m);
            return m;
        }

        /// <summary>
        /// Swap of parameters by reference
        /// </summary>
        /// <param name="obj1"></param>
        /// <param name="obj2"></param>
        private static void Bubble(ref int[] obj1, ref int[] obj2)
        {
            int[] temp = obj1;
            obj1 = obj2;
            obj2 = temp;
        }

        /// <summary>
        /// Goes through the Matrix lines Matrix.Length times
        /// Sort it's by BubbleSort in addition of inCase parameter.
        /// </summary>
        /// <param name="comp">IComparer</param>
        /// <param name="m">jugged array</param>
        private static void Sort(IComparer<int[]> comp, ref int[][] m)
        {
            int len = m.Length;
            for (int i = 0; i < len; i++)
            {
                for (int j = 1; j < len; j++)
                {
                    if (comp.Compare(m[j], m[j - 1]) == -1)
                    {
                        Bubble(ref m[j], ref m[j - 1]);
                    }
                }
            }
        }

        /// <summary>
        /// Goes through the Matrix lines Matrix.Length times
        /// Sort it's by BubbleSort in addition of inCase parameter.
        /// </summary>
        /// <param name="comp">integer Comparator(integer[], integer[])</param>
        /// <param name="m">jugged array</param>
        private static void Sort(Comparator comp, ref int[][] m)
        {
            int len = m.Length;
            for (int i = 0; i < len; i++)
            {
                for (int j = 1; j < len; j++)
                {
                    if (comp(m[j], m[j - 1]) == 1)
                    {
                        Bubble(ref m[j], ref m[j - 1]);
                    }
                }
            }
        }
    }
}
