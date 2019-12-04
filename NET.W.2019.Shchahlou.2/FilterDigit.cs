﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NET.W._2019.Shchahlou._2
{
    public static class FilterDigitCls
    {
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
            foreach (int numeric in arr)
            {
                if (numeric.ToString().Contains(mainNum.ToString()))
                    final.Add(numeric);
            }
            return final.ToArray();
        }
    }
}
