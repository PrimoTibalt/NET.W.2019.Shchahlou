using NUnit.Framework;
using System;
using NET.W._2019.Shchahlou._13;

namespace TestDay13
{
    [TestFixture]
    public class TestsQueue
    {
        [TestCase(new object[] { "Sivir", "Ahri", "Malzahar", "Kindred", "al;sh830", "Clown" }, ExpectedResult = new object[] { "Sivir", "Ahri", "Malzahar", "Kindred", "al;sh830", "Clown" })]
        [TestCase(new object[] { 0, 1, 2, 3, -1, -2, -3, int.MaxValue, int.MinValue }, ExpectedResult = new object[] { 0, 1, 2, 3, -1, -2, -3, int.MaxValue, int.MinValue })]
        public object[] Test_Queue(object[] arr)
        {
            Queue<object> queue = new Queue<object>();
            for (int i = 0; i < arr.Length; i++) 
            {
                queue.Enqueue(arr[i]);
            }

            object[] arrNew = new object[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                arrNew[i] = queue.Dequeue();
            }

            return arrNew;
        }
    }
}
