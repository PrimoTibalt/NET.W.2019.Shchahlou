using System;
using System.Collections.Generic;
using System.Text;

namespace NET.W._2019.Shchahlou._4
{
    static class GCD
    {
        public static int EuclidGCD(params int[] numbers)
        {
            for (int num = 1; num < numbers.Length; num++)
            {
                int a = numbers[num];
                int b = numbers[num - 1];
                while (a != b)
                {
                    if (a > b)
                        a -= b;
                    else
                        b -= a;
                }
                numbers[num] = a;// a = b
            }
            return numbers[numbers.Length - 1];
        }
    }
}
