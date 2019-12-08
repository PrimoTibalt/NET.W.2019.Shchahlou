using System;

namespace NET.W._2019.Shchahlou._10
{
    public static class BookExtension
    {
        public static string ToString(this Book bk, string format, IFormatProvider provider, bool hollyDay)
        {
            if (hollyDay)
            {
                return $"****{ bk.ToString(format) }*****";
            }
            else
            {
                return bk.ToString(format);
            }
        }
    }
}
