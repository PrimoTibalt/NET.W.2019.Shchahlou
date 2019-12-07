using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace NET.W._2019.Shchahlou._10.SortComparer
{
    public class AscendingSumOfLines : IComparer<int[]>
    {
        public int Compare([DisallowNull] int[] x, [DisallowNull] int[] y)
        {
            return x.Sum().CompareTo(y.Sum());
        }
    }

    public class DecreasingSumOfLines : IComparer<int[]>
    {
        public int Compare([DisallowNull] int[] x, [DisallowNull] int[] y)
        {
            return y.Sum().CompareTo(x.Sum());
        }
    }

    public class AscendingMaxElementValue : IComparer<int[]>
    {
        public int Compare([DisallowNull] int[] x, [DisallowNull] int[] y)
        {
            int biggest1 = int.MinValue;
            int biggest2 = int.MinValue;
            foreach (int val1 in x)
            {
                biggest1 = (val1 > biggest1) ? val1 : biggest1;
            }

            foreach (int val2 in y)
            {
                biggest2 = (val2 > biggest2) ? val2 : biggest2;
            }

            return biggest1.CompareTo(biggest2);
        }
    }

    public class DecreasingMaxElementValue : IComparer<int[]>
    {
        public int Compare([DisallowNull] int[] x, [DisallowNull] int[] y)
        {
            int biggest1 = int.MinValue;
            int biggest2 = int.MinValue;
            foreach (int val1 in x)
            {
                biggest1 = (val1 > biggest1) ? val1 : biggest1;
            }

            foreach (int val2 in y)
            {
                biggest2 = (val2 > biggest2) ? val2 : biggest2;
            }

            return biggest2.CompareTo(biggest1);
        }
    }

    public class AscendingMinElementValue : IComparer<int[]>
    {
        public int Compare([DisallowNull] int[] x, [DisallowNull] int[] y)
        {
            int smallest1 = int.MaxValue;
            int smallest2 = int.MaxValue;
            foreach (int val1 in x)
            {
                smallest1 = (val1 > smallest1) ? smallest1 : val1;
            }

            foreach (int val2 in y)
            {
                smallest2 = (val2 > smallest2) ? smallest2 : val2;
            }

            return smallest1.CompareTo(smallest2);
        }
    }

    public class DecreasingMinElementValue : IComparer<int[]>
    {
        public int Compare([DisallowNull] int[] x, [DisallowNull] int[] y)
        {
            int smallest1 = int.MaxValue;
            int smallest2 = int.MaxValue;
            foreach (int val1 in x)
            {
                smallest1 = (val1 > smallest1) ? smallest1 : val1;
            }

            foreach (int val2 in y)
            {
                smallest2 = (val2 > smallest2) ? smallest2 : val2;
            }

            return smallest2.CompareTo(smallest1);
        }
    }
}
