using System;
using System.Diagnostics;

namespace NET.W._2019.Shchahlou._4
{
    /// <summary>
    /// Contains 2 methods. 
    /// Do the same but different ways(find GCD by Euclid and BinaryEuclid algorithms)
    /// Also they have way to give time that they spend to find GCD.
    /// </summary>
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
       #region Classic Euclid
        public static long EuclidGCD(int[] numbers, bool timeIt = false)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            for (int num = 1; num < numbers.Length; num++)
            { 
                int a = numbers[num];
                int b = numbers[num - 1];
                /* GCD(0,b) == b; GCD(a,0) == a, GCD(0,0) == 0 */
                if (a == 0)
                {
                    return a;
                }

                if (b == 0)
                {
                    return b;
                }

                if (a < 0 || b < 0)
                {
                    throw new ArgumentException("Negative number in input array!");
                }

                while (a != b)
                {
                    if (a > b)
                    {
                        a -= b;
                    }
                    else
                    {
                        b -= a;
                    }
                }

                numbers[num] = a;
            }

            timer.Stop();
            if (timeIt)
            {
                return timer.ElapsedMilliseconds;
            }

            return numbers[numbers.Length - 1];
        }
        #endregion

        /// <summary>
        /// Use binary Euclid algorithms to find GCD of any count of input numbers.
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name = "timeIt" >
        /// In case of input true, method will return time
        /// in milliseconds to complete Euclid algorithm
        /// </param>
        /// <returns>GCD</returns>
        #region
        public static long BinaryEuclidGCD(int[] numbers, bool timeIt = false)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            for (int num = 1; num < numbers.Length; num++)
            {
                int a = numbers[num];
                int b = numbers[num - 1];
                int shift = 0;

                /* GCD(0,b) == b; GCD(a,0) == a, GCD(0,0) == 0 */
                if (a == 0)
                {
                    return b;
                }

                if (b == 0)
                {
                    return a;
                }

                /* Let shift = lg K, where K is the greatest power of 2
                   dividing both a and b. */
                while (((a | b) & 1) == 0)
                {
                    shift++;
                    a >>= 1;
                    b >>= 1;
                }

                while ((a & 1) == 0)
                {
                    a >>= 1;
                }

                /* From here on, a is always odd. */
                do
                {
                    /* remove all factors of 2 in b -- they are not common */
                    /*   note: b is not zero, so while will terminate */
                    while ((b & 1) == 0)
                    {
                        b >>= 1;
                    }

                    /* Now a and b are both odd. Swap if necessary so a <= b,
                       then set b = b - a (which is even). For bignums, the
                       swapping is just pointer movement, and the subtraction
                       can be done in-place. */
                    if (a > b)
                    {
                        int t = b;
                        b = a;
                        a = t; // Swap a and b.
                    }

                    b -= a; // Here b >= a.
                } 
                while (b != 0);

                /* restore common factors of 2 */
                numbers[num] = a << shift;
            }

            timer.Stop();
            if (timeIt)
            {
                return timer.ElapsedMilliseconds;
            }

            return numbers[numbers.Length - 1];
        }
        #endregion
    }
}
