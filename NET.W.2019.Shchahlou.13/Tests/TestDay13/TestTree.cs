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
        [TestCase(new int[] { 5, 4, 3, 2, 6, 10, 8}, ExpectedResult = new int[] { 2, 3, 4, 5, 8, 10, 6 })]
        public int[] TestPointers(int[] points)
        {
            List<Point> list = new List<Point>();
            foreach(var point in points)
            {
                list.Add(new Point(point));
            }

            BinarySearchTree<Point> tree = new BinarySearchTree<Point>(list.ToArray());
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
    }
}
