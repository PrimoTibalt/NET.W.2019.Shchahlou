using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace NET.W._2019.Shchahlou._2
{
    public static class FindNextBiggerNumberCls
    {
        /// <summary>
        /// Find number, that minimally bigger than param 'number'
        /// and consists of the same symbols as 'number'
        /// '123' -> '132', '12' -> '21', '1234321' -> '1241234'
        /// </summary>
        /// <param name="number"></param>
        /// <returns>Null is we can't find any</returns>
        public static int? FindNextBiggerNumber(int number)
        {
            int minimalBigger = 0;
            int maxNumber = maxNum(number);
            bool isGood = true;
            for (int numTest = number + 1; numTest < maxNumber; numTest++)
            {
                isGood = true;
                //Check, does numTest contain every symbol of number
                //and is their count the same as in number
                foreach (char c in number.ToString())
                {
                    if (!numTest.ToString().Contains(c) ||
                        (Count(c, numTest.ToString()) != Count(c, number.ToString()))
                        )
                    {
                        isGood = false;
                        break;
                    }
                }
                if (isGood)
                {
                    minimalBigger = numTest;
                    break;
                }
            }
            if (minimalBigger == 0)
                return null;
            return minimalBigger;
        }

        /// <summary>
        /// Method to help FindNextBiggerNumber. 
        /// </summary>
        /// <param name="c"></param>
        /// <param name="s"></param>
        /// <returns>number of symbols 'c' in string 's'</returns>
        private static int Count(char c, string s)
        {
            int num = 0;
            foreach (char letter in s)
            {
                if (letter == c)
                    num++;
            }
            return num;
        }
        /// <summary>
        /// Method to help FindNextBiggerNumber
        /// </summary>
        /// <param name="number"></param>
        /// <returns>numeric, which contains as many nine's as many symbols in param number</returns>
        private static int maxNum(int number)
        {
            int maxNumber = 0;
            int powOf10 = number.ToString().Length;
            for (int i = 0; i < powOf10; i++)
            {
                maxNumber += (int)(9 * (Math.Pow(10, i)));
            }
            return maxNumber;
        }

        /// <summary>
        /// Extends FindNextBiggerNumber
        /// </summary>
        /// <param name="number"></param>
        /// <param name="time">
        /// True - method returns time, spent on FindNextBiggerNumber
        /// Fale - returns FindNextBiggerNumber result
        /// </param>
        /// <returns>Count of milliseconds spent on FindNextBiggerNumber. Or the number.</returns>
        public static long FindNextBiggerNumber(int number, bool time)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            int? num = FindNextBiggerNumber(number);
            timer.Stop();
            if (time)
                return timer.ElapsedMilliseconds;
            else
                return (long)num;
        }
    }
}
