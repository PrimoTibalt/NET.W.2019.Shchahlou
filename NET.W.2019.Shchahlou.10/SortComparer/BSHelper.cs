using System;
using System.Collections.Generic;
using System.Text;

namespace NET.W._2019.Shchahlou._10
{
    public static class BSHelper
    {
        public static int Sum(this int[] arr)
        {
            int sum = 0;
            foreach (int a in arr)
            {
                sum += a;
            }

            return sum;
        }
    }
}
