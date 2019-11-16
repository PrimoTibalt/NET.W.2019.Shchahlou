using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace NET.W._2019.Shchahlou._2
{
    //TO DO:
    //1.Another 3 function from homework
    //2.Comments for main methods
    //3.README.md
    //THE END
    //(p.s. #region and another tags should be learned)
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(FindNextBiggerNumber(1234321));
            Console.WriteLine(maxNum(123));
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
        /// <param name="c">some symbol</param>
        /// <param name="s">some string</param>
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
        /// <param name="number">any integer</param>
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
  
    }
}
