namespace NET.W._2019.Shchahlou._13.BinarySearchTree.Comparers
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Have only compare method, that compares by standart comparer of the type(if exists) if comparer doesnt exist, than compares HashCode(like int).
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DefaultComparer<T> : IComparer<T>
    {
        /// <summary>
        /// Compares by standart comparer of the type(if exists) if comparer doesnt exist, than compares HashCode(like int).
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int Compare([AllowNull] T x, [AllowNull] T y)
        {
            if (x is IComparable first && y is IComparable second)
            {
                return first.CompareTo(second);
            }

            return x.GetHashCode().CompareTo(y.GetHashCode());
        }
    }
}
