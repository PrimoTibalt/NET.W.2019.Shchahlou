namespace Tests
{
    using NET.W._2019.Shchahlou._4;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    [TestClass]
    public class TestDay4
    {
        // -------------------- Test of EuclidGCD --------------------
        [TestMethod]
        public void TestEuclidGCDMax()
        {
            //arrange
            int[] valueException = { Int32.MaxValue, Int32.MinValue };

            //assert
            Assert.ThrowsException<ArgumentException>(() => GCD.EuclidGCD(valueException));
        }

        [TestMethod]
        public void TestEuclidGCDZero()
        {
            //arrange
            int[] value = { 0, 0, 0, 0 };

            //act
            long val = GCD.EuclidGCD(value);

            //assert
            Assert.AreEqual(0, val); 
        }

        [TestMethod]
        public void TestEuclidGCDRandFirst()
        {
            //arrange
            int[] value = { 5, 10, 15 };

            //act
            long val = GCD.EuclidGCD(value);

            //assert
            Assert.AreEqual(5, val);
        }

        [TestMethod]
        public void TestEuclidGCDRandSecond()
        {
            //arrange
            int[] value = { 3, 6, 9, 12, 15, 18 };

            //act
            long val = GCD.EuclidGCD(value);

            //assert
            Assert.AreEqual(3, val);
        }

        [TestMethod]
        public void TestEuclidGCDRandThird()
        {
            //arrange
            int[] value = { 7, 9, 13, 23, 28, 12, 12 };

            //act
            long val = GCD.EuclidGCD(value);

            //assert
            Assert.AreEqual(1, val);
        }

        // -------------------- End of test EuclidGCD --------------------

        // -------------------- Test of BinaryEuclidGCD --------------------
        [TestMethod]
        public void TestBinaryEuclidGCDMax()
        {
            //arrange
            int[] valueException = { Int32.MaxValue, Int32.MinValue };

            //assert
            Assert.ThrowsException<ArgumentException>(() => GCD.BinaryEuclidGCD(valueException));
        }

        [TestMethod]
        public void TestBinaryEuclidGCDZero()
        {
            //arrange
            int[] value = { 0, 0, 0, 0 };

            //act
            long val = GCD.BinaryEuclidGCD(value);

            //assert
            Assert.AreEqual(0, val);
        }

        [TestMethod]
        public void TestBinaryEuclidGCDRandFirst()
        {
            //arrange
            int[] value = { 5, 10, 15 };

            //act
            long val = GCD.BinaryEuclidGCD(value);

            //assert
            Assert.AreEqual(5, val);
        }

        [TestMethod]
        public void TestBinaryEuclidGCDRandSecond()
        {
            //arrange
            int[] value = { 3, 6, 9, 12, 15, 18 };

            //act
            long val = GCD.BinaryEuclidGCD(value);

            //assert
            Assert.AreEqual(3, val);
        }

        [TestMethod]
        public void TestBinaryEuclidGCDRandThird()
        {
            //arrange
            int[] value = { 7, 9, 13, 23, 28, 12, 12 };

            //act
            long val = GCD.BinaryEuclidGCD(value);

            //assert
            Assert.AreEqual(1, val);
        }
        // -------------------- End of test BinaryEuclidGCD --------------------

        // -------------------- Test of UnsafeBinaryString --------------------
        [TestMethod]
        public void TestUnsafeBinaryStringRandFirst()
        {
            //arrange
            double value = -255.255;

            //act
            string result = value.UnsafeBinaryString();

            //assert
            Assert.AreEqual("1100000001101111111010000010100011110101110000101000111101011100", result);
        }

        [TestMethod]
        public void TestUnsafeBinaryStringRandSecond()
        {
            //arrange
            double value = 255.255;
            //act
            string result = value.UnsafeBinaryString();

            //assert
            Assert.AreEqual("0100000001101111111010000010100011110101110000101000111101011100", result);
        }

        [TestMethod]
        public void TestUnsafeBinaryStringRandThird()
        {
            //arrange
            double value = 4294967295.0;
            //act
            string result = value.UnsafeBinaryString();

            //assert
            Assert.AreEqual("0100000111101111111111111111111111111111111000000000000000000000", result);
        }

        [TestMethod]
        public void TestUnsafeBinaryStringMin()
        {
            //arrange
            double value = double.MinValue;

            //act
            string result = value.UnsafeBinaryString();

            //assert
            Assert.AreEqual("1111111111101111111111111111111111111111111111111111111111111111", result);
        }

        [TestMethod]
        public void TestUnsafeBinaryStringMax()
        {
            //arrange
            double value = double.MaxValue;

            //act
            string result = value.UnsafeBinaryString();

            //assert
            Assert.AreEqual("0111111111101111111111111111111111111111111111111111111111111111", result);
        }

        [TestMethod]
        public void TestUnsafeBinaryStringEpsilon()
        {
            //arrange
            double value = double.Epsilon;

            //act
            string result = value.UnsafeBinaryString();

            //assert
            Assert.AreEqual("0000000000000000000000000000000000000000000000000000000000000001", result);
        }

        [TestMethod]
        public void TestUnsafeBinaryStringNaN()
        {
            //arrange
            double value = double.NaN;

            //act
            string result = value.UnsafeBinaryString();

            //assert
            Assert.AreEqual("1111111111111000000000000000000000000000000000000000000000000000", result);
        }

        [TestMethod]
        public void TestUnsafeBinaryStringNegativeInfinity()
        {
            //arrange
            double value = double.NegativeInfinity;

            //act
            string result = value.UnsafeBinaryString();

            //assert
            Assert.AreEqual("1111111111110000000000000000000000000000000000000000000000000000", result);
        }

        [TestMethod]
        public void TestUnsafeBinaryStringPositiveInfinity()
        {
            //arrange
            double value = double.PositiveInfinity;

            //act
            string result = value.UnsafeBinaryString();

            //assert
            Assert.AreEqual("0111111111110000000000000000000000000000000000000000000000000000", result);
        }

        [TestMethod]
        public void TestUnsafeBinaryStringMinusZero()
        {
            //arrange
            double value = -0.0;

            //act
            string result = value.UnsafeBinaryString();

            //assert
            Assert.AreEqual("1000000000000000000000000000000000000000000000000000000000000000", result);
        }

        [TestMethod]
        public void TestUnsafeBinaryStringZero()
        {
            //arrange
            double value = 0.0;

            //act
            string result = value.UnsafeBinaryString();

            //assert
            Assert.AreEqual("0000000000000000000000000000000000000000000000000000000000000000", result);
        }
        // -------------------- End of test UnsafeBinaryString --------------------
    }
}
