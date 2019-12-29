using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace NET.W._2019.Shchahlou._13.BinarySearchTree.Comparers
{
    public class DefaultComparer<T> : IComparer<T>
    {
        public int Compare([AllowNull] T x, [AllowNull] T y)
        {
            return x.GetHashCode().CompareTo(y.GetHashCode());
        }
    }
}
