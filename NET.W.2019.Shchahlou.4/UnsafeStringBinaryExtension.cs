using System;
using System.Collections.Generic;
using System.Text;

namespace NET.W._2019.Shchahlou._4
{
    public static class DoubleExtension
    {
        /// <summary>
        /// Return binary version of the input double.
        /// </summary>
        /// <param name="number"></param>
        /// <returns>string of 63 bits</returns>
        unsafe public static string UnsafeBinaryString(this double number)
        {
            long temp;
            string result = string.Empty;
            long* lptr = (long*)&number;
            temp = *lptr;

            for(int i = 63; i >= 0; i--)
            {
                result += (((temp >> i) & 1) == 0) ? "0" : "1";
            }
            return result;
        }
    }
}
