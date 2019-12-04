using System;

namespace NET.W._2019.Shchahlou._4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            unsafe
            {
                Console.WriteLine(255.255.UnsafeBinaryString());
            }
        }
    }
}
