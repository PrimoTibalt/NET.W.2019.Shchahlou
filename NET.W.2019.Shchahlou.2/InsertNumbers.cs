using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace NET.W._2019.Shchahlou._2
{
    public static class InsertNumbersCls
    {
        /// <summary>
        /// We inserts bits from numberIn to numberSource
        /// </summary>
        /// <param name="numberSource">Where will be inserted</param>
        /// <param name="numberIn">What will be inserted</param>
        /// <param name="i">The beggining of the place where we insert</param>
        /// <param name="j">The end</param>
        /// <returns>the integer, which represents denery from the bits</returns>
        public static long? InsertNumbers(int numberSource, int numberIn, int i, int j)
        {
            BitArray bitSource = new BitArray(new int[] { numberSource });
            BitArray bitIn = new BitArray(new int[] { numberIn });
            if (i > j)
                return null;

            for (int num = i; num < j; num++)
            {
                bitSource[num] = bitIn[num - i];
            }
            int[] zeroIsResult = new int[1];
            bitSource.CopyTo(zeroIsResult, 0);
            return zeroIsResult[0];
        }
    }
}
