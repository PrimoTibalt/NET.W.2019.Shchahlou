using System;
using System.Collections.Generic;
using NET.W._2019.Shchahlou._13.BinarySearchTree;
using NET.W._2019.Shchahlou._13.BinarySearchTree.Comparers;
using NUnit.Framework;

namespace TestDay13
{
    [TestFixture]
    public class TestTree
    {
        [TestCase(new int[] { int.MaxValue / 2, int.MinValue, 0, -1, int.MaxValue }, EnumTest.Int, ExpectedResult = new int[] { -1, 0, int.MinValue, int.MaxValue / 2, int.MaxValue })]
        [TestCase(new int[] { int.MaxValue / 2, int.MinValue, 0, -1, int.MaxValue }, EnumTest.Default, ExpectedResult = new int[] { -1, 0, int.MinValue, int.MaxValue / 2, int.MaxValue })]
        public int[] TestInt(int[] points, EnumTest testCase)
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>(points);
            SetComparer(tree, testCase);
            List<int> list = new List<int>();

            foreach (var node in tree.Inorder())
            {
                list.Add(node.Value);
            }

            return list.ToArray();
        }

        [TestCase(new int[] { int.MaxValue/2, int.MinValue, 0, -1, int.MaxValue }, EnumTest.Point,  ExpectedResult = new int[] { -1, 0, int.MinValue, int.MaxValue / 2, int.MaxValue })]
        [TestCase(new int[] { 5, 4, 3, 2, 6, 10, 8 }, EnumTest.Default, ExpectedResult = new int[] { 2, 3, 4, 5, 8, 10, 6 })]
        public int[] TestPointers(int[] points, EnumTest testCase)
        {
            List<Point> list = new List<Point>();
            foreach (var point in points)
            {
                list.Add(new Point(point));
            }

            BinarySearchTree<Point> tree = new BinarySearchTree<Point>(list.ToArray());
            SetComparer(tree, testCase);
            int[] array = new int[list.Count];

            list.Clear();
            foreach (var node in tree.Inorder())
            {
                list.Add(node.Value);
            }

            for (int i = 0; i < list.Count; i++)
            {
                array[i] = list[i].Number;
            }

            return array;
        }

        [TestCase(new int[] { int.MaxValue / 2, int.MinValue, 0, -1, int.MaxValue }, EnumTest.Book, ExpectedResult = new int[] { int.MaxValue / 2, int.MinValue, 0, -1, int.MaxValue })]
        [TestCase(new int[] { 5, 4, 3, 2, 6, 10, 8 }, EnumTest.Default, ExpectedResult = new int[] { 5, 4, 3, 2, 6, 10, 8 })]
        public int[] TestBooks(int[] points, EnumTest testCase)
        {
            List<Book> list = new List<Book>();
            foreach (var point in points)
            {
                list.Add(new Book(point));
            }

            BinarySearchTree<Book> tree = new BinarySearchTree<Book>(list.ToArray());
            SetComparer(tree, testCase);
            int[] array = new int[list.Count];

            list.Clear();
            foreach (var node in tree.Preorder())
            {
                list.Add(node.Value);
            }

            for (int i = 0; i < list.Count; i++)
            {
                array[i] = list[i].Year;
            }

            return array;
        }

        [TestCase(EnumTest.String, ExpectedResult = new string[] { "a", "b", "e", "d", "c" })]
        [TestCase(EnumTest.Default, ExpectedResult = new string[] { "a", "b", "e", "d", "c"})]
        public string[] TestString(EnumTest testCase)
        {
            string[] points = new string[] { "c", "b", "a", "d", "e" };
            List<string> list = new List<string>();

            BinarySearchTree<string> tree = new BinarySearchTree<string>(points);
            SetComparer(tree, testCase);

            foreach (var node in tree.Postorder())
            {
                list.Add(node.Value);
            }

            return list.ToArray();
        }

        public static void SetComparer<T>(BinarySearchTree<T> tree, EnumTest enumTest)
        {
            switch (enumTest)
            {
                case EnumTest.Book:
                    tree.SetComparer(new StringComparer<T>());
                    break;
                case EnumTest.String:
                    tree.SetComparer(new StringComparer<T>());
                    break;
                case EnumTest.Int:
                    tree.SetComparer(new StringComparer<T>());
                    break;
                case EnumTest.Point:
                    tree.SetComparer(new StringComparer<T>());
                    break;
                case EnumTest.Default:
                    tree.SetComparer(new DefaultComparer<T>());
                    break;
            }
        }
    }
}
