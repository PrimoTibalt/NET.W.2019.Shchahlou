using System;
using System.Collections.Generic;
using System.Text;

namespace NET.W._2019.Shchahlou._8
{
    class BookYearComparer<T> : IComparer<T>
        where T : Book
    {
        public int Compare(T x, T y)
        {
            return x.Year.CompareTo(y.Year);
        }
    }

    class BookCostComparer<T> : IComparer<T>
        where T : Book
    {
        public int Compare(T x, T y)
        {
            return x.Cost.CompareTo(y.Cost);
        }
    }

    //Could be more classes but what reason?
}
