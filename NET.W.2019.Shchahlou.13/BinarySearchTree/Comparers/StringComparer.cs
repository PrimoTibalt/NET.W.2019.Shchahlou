using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace NET.W._2019.Shchahlou._13.BinarySearchTree.Comparers
{
    public class StringComparer<T> : IComparer<T>
    {
        public int Compare([AllowNull] T x, [AllowNull] T y)
        {
            return x.GetHashCode().ToString().CompareTo(y.GetHashCode().GetHashCode());
        }
    }
}
