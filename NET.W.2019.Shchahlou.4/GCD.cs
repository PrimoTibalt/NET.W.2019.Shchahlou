using System;
using System.Collections.Generic;
using System.Text;

namespace NET.W._2019.Shchahlou._4
{
    public static class GCD
    {
        /// <summary>
        /// Use Euclid algorithms to find GCD of any count of input numbers.
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="timeIt">
        /// In case of input true, method will return time
        /// in milliseconds to complete Euclid algorithm
        /// </param>
        /// <returns>GCD</returns>
        public static int EuclidGCD(int[] numbers, bool timeIt = false)
        {

            for (int num = 1; num < numbers.Length; num++)
            { 
                int a = numbers[num];
                int b = numbers[num-1];
                /* GCD(0,b) == v; GCD(a,0) == u, GCD(0,0) == 0 */
                if (a == 0) return a;
                if (b == 0) return b;

                if (a < 0 || b < 0)
                    throw new ArgumentException("Negative number in input array!");
                while (a != b)
                {
                    if (a > b)
                        a -= b;
                    else
                        b -= a;
                }
                numbers[num] = a;
            }
            return numbers[numbers.Length - 1];
        }

        /// <summary>
        /// Use binary Euclid algorithms to find GCD of any count of input numbers.
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns>GCD</returns>
        public static int BinaryEuclidGCD(int[] numbers, bool timeIt = false)
        {
            for (int num = 1; num < numbers.Length; num++)
            {
                int a = numbers[num];
                int b = numbers[num - 1];
                int shift = 0;

                /* GCD(0,b) == v; GCD(u,0) == u, GCD(0,0) == 0 */
                if (a == 0) return b;
                if (b == 0) return a;

                /* Let shift = lg K, where K is the greatest power of 2
                   dividing both u and v. */
                while (((a | b) & 1) == 0)
                {
                    shift++;
                    a >>= 1;
                    b >>= 1;
                }

                while ((a & 1) == 0)
                    a >>= 1;

                /* From here on, u is always odd. */
                do
                {
                    /* remove all factors of 2 in v -- they are not common */
                    /*   note: v is not zero, so while will terminate */
                    while ((b & 1) == 0)
                        b >>= 1;

                    /* Now u and v are both odd. Swap if necessary so u <= v,
                       then set v = v - u (which is even). For bignums, the
                       swapping is just pointer movement, and the subtraction
                       can be done in-place. */
                    if (a > b)
                    {
                        int t = b;
                        b = a;
                        a = t; // Swap u and v.
                    }

                    b -= a; // Here v >= u.
                } while (b != 0);

                /* restore common factors of 2 */
                numbers[num] = a << shift;
            }
            return numbers[numbers.Length - 1];
        }
    }
}
