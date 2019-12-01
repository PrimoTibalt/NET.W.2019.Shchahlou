using System;

namespace NET.W._2019.Shchahlou._4
{
    public class Program
    {

        static void Main(string[] args)
        {
            
            unsafe
            {
                Console.WriteLine((255.255).UnsafeBinaryString());
            }
        }
    }


    public unsafe static class Acc<TDest, TSource>
    {
        public static unsafe TDest ReinterpretCast(TSource source)
        {
            var sourceRef = __makeref(source);
            var dest = default(TDest);
            var destRef = __makeref(dest);
            *(IntPtr*)&destRef = *(IntPtr*)&sourceRef;
            return __refvalue(destRef, TDest);
        }
    }
}
