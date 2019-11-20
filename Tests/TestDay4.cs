using NET.W._2019.Shchahlou._4;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests
{
    [TestClass]
    public class TestDay4
    {
        [TestMethod]
        public void TestEuclidGCD()
        {
            //arrange
            int[] valueException = { Int32.MaxValue, Int32.MinValue };
            int[] value5 = { 5, 10, 15 };
            int[] value3 = { 3, 6, 9, 12, 15, 18 };
            int[] value1 = { 7, 9, 13, 23, 28, 12, 12 };

            //act
            int v5 = GCD.EuclidGCD(value5);
            int v3 = GCD.EuclidGCD(value3);
            int v1 = GCD.EuclidGCD(value1);

            //assert
            Assert.ThrowsException<ArgumentException>(()=>GCD.EuclidGCD(valueException));
            Assert.AreEqual(5, v5);
            Assert.AreEqual(3, v3);
            Assert.AreEqual(1, v1);
        }

        [TestMethod]
        public void TestBinaryEuclidGCD()
        {
            //arrange
            int[] valueException = { Int32.MaxValue, Int32.MinValue };
            int[] value5 = { 5, 10, 15 };
            int[] value3 = { 3, 6, 9, 12, 15, 18 };
            int[] value1 = { 7, 9, 13, 23, 28, 12, 12 };

            //act
            int v5 = GCD.BinaryEuclidGCD(value5);
            int v3 = GCD.BinaryEuclidGCD(value3);
            int v1 = GCD.BinaryEuclidGCD(value1);

            //assert
            Assert.ThrowsException<ArgumentException>(() => GCD.EuclidGCD(valueException));
            Assert.AreEqual(5, v5);
            Assert.AreEqual(3, v3);
            Assert.AreEqual(1, v1);
        }
    }
}
