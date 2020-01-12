using System;
using System.Collections.Generic;
using System.Text;

namespace NET.W._2019.Shchahlou._2
{
    public static class FindNthRootCls
    {
        /// <summary>
        /// Calculate the root of number by Newton method
        /// </summary>
        /// <param name="number"></param>
        /// <param name="root"></param>
        /// <param name="precision"></param>
        /// <returns></returns>
        public static double FindNthRoot(float number, int root, float precision)
        {
            if (number == 0)
            {
                return 0;
            }

            float x0 = number / root;
            float x1 = (1 / (float)root) * (((root - 1) * x0) + (number / Pow(x0, (int)root - 1)));
            while (Math.Abs(x1 - x0) > precision)
            {
                x0 = x1;
                x1 = (1 / (float)root) * (((root - 1) * x0) + (number / Pow(x0, (int)root - 1)));
            }

            return (double)Math.Round(x1, 3);
        }

        private static float Pow(float a, int pow)
        {
            float result = 1;
            for (int i = 0; i < pow; i++)
            {
                result *= a;
            }

            return result;
        }
    }
}
