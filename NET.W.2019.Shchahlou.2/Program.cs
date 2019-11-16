using System;
using System.Collections;


namespace NET.W._2019.Shchahlou._2
{
    public class Program
    {
        static void Main(string[] args)
        {

        }

        public static long? InsertNumbers(int numberSource, int numberIn, int i, int j)
        {
            BitArray bitSource = new BitArray(new int[] { numberSource });
            BitArray bitIn = new BitArray(new int[] { numberIn });
            if (i > j)
                return null;
            
            for (int num = i; num < j ; num++)
            {
                bitSource[num] = bitIn[num - i];
            }
            int[] zeroIsResult = new int[1];
            bitSource.CopyTo(zeroIsResult, 0);
            return zeroIsResult[0];
        }
    }
}
