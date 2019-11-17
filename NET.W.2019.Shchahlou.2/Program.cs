using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace NET.W._2019.Shchahlou._2
{
    //TO DO:
    //3.README.md
    public class Program
    {
        static void Main(string[] args)
        {
        }
        //----------------------------------------------------------------------------
        //----------------------------------------------------------------------------
        #region InsertNumbersReg
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
            
            for (int num = i; num < j ; num++)
            {
                bitSource[num] = bitIn[num - i];
            }
            int[] zeroIsResult = new int[1];
            bitSource.CopyTo(zeroIsResult, 0);
            return zeroIsResult[0];
        }
        #endregion
        //----------------------------------------------------------------------------
        //----------------------------------------------------------------------------
        #region FindNextBiggerNumberReg
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
            for(int numTest = number+1; numTest < maxNumber; numTest++)
            {
                isGood = true;
                //Check, does numTest contain every symbol of number
                //and is their count the same as in number
                foreach(char c in number.ToString())
                {
                    if (!numTest.ToString().Contains(c) ||
                        (Count(c, numTest.ToString()) != Count(c, number.ToString()))
                        )
                    {
                        isGood = false;
                        break;
                    }
                }
                if(isGood)
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
            foreach(char letter in s)
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
            for(int i = 0; i < powOf10; i++)
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
        public static int? FindNextBiggerNumber(int number, bool time)
        {
            int? start = DateTime.Now.Millisecond;
            int? num = FindNextBiggerNumber(number);
            if (time)
                return DateTime.Now.Millisecond - start;
            else
                return num;
        }
        #endregion
        //----------------------------------------------------------------------------
        //----------------------------------------------------------------------------
        #region FilterDigitReg
        /// <summary>
        /// Choose all the numbers of the array which involves mainNum
        /// if mainNum = 13, arr = [13, 1312, 12123, 123, 113]
        /// return = [13, 1312, 113]
        /// </summary>
        /// <param name="mainNum"></param>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int[] FilterDigit(int mainNum, params int[] arr)
        {
            List<int> final = new List<int>();
            if (mainNum < 0)
                return null;
            foreach(int numeric in arr)
            {
                if (numeric.ToString().Contains(mainNum.ToString()))
                    final.Add(numeric);
            }
            return final.ToArray();
        }
        #endregion
        //----------------------------------------------------------------------------
        //----------------------------------------------------------------------------
        #region FindNthRootReg
        /// <summary>
        /// Calculate the root of number by Newton method
        /// </summary>
        /// <param name="number"></param>
        /// <param name="root"></param>
        /// <param name="precision"></param>
        /// <returns></returns>
        public static double FindNthRoot(float number, int root, float precision)
        {
            float x0 = number / root;
            float x1 = (1 / (float)root) * ((root - 1) * x0 + number / Pow(x0, (int)root - 1));
            while (Math.Abs(x1 - x0) > precision)
            {
                x0 = x1;
                x1 = (1 / (float)root) * ((root - 1) * x0 + number / Pow(x0, (int)root - 1));
            }
            return (double)Math.Round(x1, 3);
        }

        static float Pow(float a, int pow)
        {
            float result = 1;
            for (int i = 0; i < pow; i++) result *= a;
            return result;
        }
        #endregion
        //----------------------------------------------------------------------------
        //----------------------------------------------------------------------------
    }
}
