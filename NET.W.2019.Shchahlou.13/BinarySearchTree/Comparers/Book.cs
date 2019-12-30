using System;
using System.Collections.Generic;
using System.Text;

namespace NET.W._2019.Shchahlou._13.BinarySearchTree.Comparers
{
    public class Book : IComparable
    {
        public int Year { get; set; }

        public Book(int year)
        {
            this.Year = year;
        }

        public int CompareTo(object obj)
        {
            if (!(obj is Book))
            {
                throw new ArgumentException("Try to compare Pointer with non Book.");
            }

            Book second = obj as Book;
            return this.Year.CompareTo(second.Year);
        }
    }
}
