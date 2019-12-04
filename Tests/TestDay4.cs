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
            long v5 = GCD.EuclidGCD(value5);
            long v3 = GCD.EuclidGCD(value3);
            long v1 = GCD.EuclidGCD(value1);

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
            long v5 = GCD.BinaryEuclidGCD(value5);
            long v3 = GCD.BinaryEuclidGCD(value3);
            long v1 = GCD.BinaryEuclidGCD(value1);

            //assert
            Assert.ThrowsException<ArgumentException>(() => GCD.EuclidGCD(valueException));
            Assert.AreEqual(5, v5);
            Assert.AreEqual(3, v3);
            Assert.AreEqual(1, v1);
        }

        [TestMethod]
        public void TestUnsafeBinaryString()
        {
            //arrange
            double value0 = -255.255;
            double value1 = 255.255;
            double value2 = 4294967295.0;
            double value3 = double.MinValue;
            double value4 = double.MaxValue;
            double value5 = double.Epsilon;
            double value6 = double.NaN;
            double value7 = double.NegativeInfinity;
            double value8 = double.PositiveInfinity;
            double value9 = -0.0;
            double value10 = 0.0;

            //act
            string result0 = value0.UnsafeBinaryString();
            string result1 = value1.UnsafeBinaryString();
            string result2 = value2.UnsafeBinaryString();
            string result3 = value3.UnsafeBinaryString();
            string result4 = value4.UnsafeBinaryString();
            string result5 = value5.UnsafeBinaryString();
            string result6 = value6.UnsafeBinaryString();
            string result7 = value7.UnsafeBinaryString();
            string result8 = value8.UnsafeBinaryString();
            string result9 = value9.UnsafeBinaryString();
            string result10 = value10.UnsafeBinaryString();

            //assert
            Assert.AreEqual("1100000001101111111010000010100011110101110000101000111101011100", result0);
            Assert.AreEqual("0100000001101111111010000010100011110101110000101000111101011100", result1);
            Assert.AreEqual("0100000111101111111111111111111111111111111000000000000000000000", result2);
            Assert.AreEqual("1111111111101111111111111111111111111111111111111111111111111111", result3);
            Assert.AreEqual("0111111111101111111111111111111111111111111111111111111111111111", result4);
            Assert.AreEqual("0000000000000000000000000000000000000000000000000000000000000001", result5);
            Assert.AreEqual("1111111111111000000000000000000000000000000000000000000000000000", result6);
            Assert.AreEqual("1111111111110000000000000000000000000000000000000000000000000000", result7);
            Assert.AreEqual("0111111111110000000000000000000000000000000000000000000000000000", result8);
            Assert.AreEqual("1000000000000000000000000000000000000000000000000000000000000000", result9);
            Assert.AreEqual("0000000000000000000000000000000000000000000000000000000000000000", result10);
        }
    }
}
