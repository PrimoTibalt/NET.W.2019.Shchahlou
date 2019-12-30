using System;
using System.Collections.Generic;
using System.Text;

namespace NET.W._2019.Shchahlou._13.BinarySearchTree.Comparers
{
    public struct Point : IComparable
    {
        public int Number { get; set; }

        public Point(int num)
        {
            this.Number = num;
        }

        public int CompareTo(object obj)
        {
            if (!(obj is Point))
            {
                throw new ArgumentException("Try to compare Pointer with non pointer.");
            }

            Point second = (Point) obj;
            return this.Number.CompareTo(second.Number);
        }
    }
}
