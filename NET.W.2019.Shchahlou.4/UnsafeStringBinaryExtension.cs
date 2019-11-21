using System;
using System.Collections.Generic;
using System.Text;

namespace NET.W._2019.Shchahlou._4
{
    public static class DoubleExtension
    {
        unsafe public static string UnsafeBinaryString(this double number)
        {
            string result = Convert.ToString(BitConverter.DoubleToInt64Bits(number), 2);
            return result;
        }
    }
}
