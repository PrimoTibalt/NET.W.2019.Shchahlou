namespace NET.W._2019.Shchahlou._12.Book
{
    using System.Collections.Generic;

    public class BookYearComparer<T> : IComparer<T>
        where T : Book
    {
        public int Compare(T x, T y)
        {
            return x.Year.CompareTo(y.Year);
        }
    }

    public class BookCostComparer<T> : IComparer<T>
        where T : Book
    {
        public int Compare(T x, T y)
        {
            return x.Cost.CompareTo(y.Cost);
        }
    }
}
