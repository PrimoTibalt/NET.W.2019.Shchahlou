﻿namespace NET.W._2019.Shchahlou._13.BinarySearchTree.Comparers
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    public class StringComparer<T> : IComparer<T>
    {
        public int Compare([AllowNull] T x, [AllowNull] T y)
        {
            return x.GetHashCode().ToString().CompareTo(y.ToString().GetHashCode());
        }
    }
}
