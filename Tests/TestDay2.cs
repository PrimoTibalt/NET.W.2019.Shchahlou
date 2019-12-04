using Microsoft.VisualStudio.TestTools.UnitTesting;
using NET.W._2019.Shchahlou._2;

namespace Tests
{
    [TestClass]
    public class TestDay2
    {
        [TestMethod]
        public void TestInsertNumber()
        {
            var value15 = InsertNumbersCls.InsertNumbers(15, 15, 0, 0);
            var value8 = InsertNumbersCls.InsertNumbers(8, 15, 0, 0);
            var value120 = InsertNumbersCls.InsertNumbers(8, 15, 3, 8);
            var valueNull = InsertNumbersCls.InsertNumbers(8, 15, 4, 3);

            Assert.AreEqual(15, value15);
            Assert.AreEqual(8, value8);
            Assert.AreEqual(120, value120);
            Assert.AreEqual(null, valueNull);
        }

        [TestMethod]
        public void TestFindNextBiggerNumber()
        {
            var value21 = FindNextBiggerNumberCls.FindNextBiggerNumber(12);
            var value531 = FindNextBiggerNumberCls.FindNextBiggerNumber(513);
            var value2071 = FindNextBiggerNumberCls.FindNextBiggerNumber(2017);
            var value441 = FindNextBiggerNumberCls.FindNextBiggerNumber(414);
            var value414 = FindNextBiggerNumberCls.FindNextBiggerNumber(144);
            var value1241233 = FindNextBiggerNumberCls.FindNextBiggerNumber(1234321);
            var value1234162 = FindNextBiggerNumberCls.FindNextBiggerNumber(1234126);
            var value3462345 = FindNextBiggerNumberCls.FindNextBiggerNumber(3456432);
            var valueNull = FindNextBiggerNumberCls.FindNextBiggerNumber(10);
            var valueNull0 = FindNextBiggerNumberCls.FindNextBiggerNumber(20);

            Assert.AreEqual(21, value21);
            Assert.AreEqual(531, value531);
            Assert.AreEqual(2071, value2071);
            Assert.AreEqual(441, value441);
            Assert.AreEqual(414, value414);
            Assert.AreEqual(1241233, value1241233);
            Assert.AreEqual(1234162, value1234162);
            Assert.AreEqual(3462345, value3462345);
            Assert.AreEqual(null, valueNull);
            Assert.AreEqual(null, valueNull0);
        }

        [TestMethod]
        public void TestFilterDigit()
        {
            var value7 = FilterDigitCls.FilterDigit(7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17);
            var value0 = FilterDigitCls.FilterDigit(0, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17, 1435, 13451, 11, 99, 10, 12, 123);
            var value1 = FilterDigitCls.FilterDigit(1, 127, 122, 23555, 12334, 674, 543, 1316, 9757, 628, 69, 70, 15, 17);
            var valueMinus1 = FilterDigitCls.FilterDigit(-1, 7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17);
            var value10 = FilterDigitCls.FilterDigit(10, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17, 1015, 11015, 111101010, 12310);

            Assert.IsTrue(CheckArrays(new int[] { 7, 70, 17 }, value7));
            Assert.IsTrue(CheckArrays(new int[] { 70, 10 }, value0));
            Assert.IsTrue(CheckArrays(new int[] { 127, 122, 12334, 1316, 15, 17 }, value1));
            Assert.IsTrue(CheckArrays(null, valueMinus1));
            Assert.IsTrue(CheckArrays(new int[] { 1015, 11015, 111101010, 12310 }, value10));
        }

        private bool CheckArrays(int[] expect, int[] have)
        {
            if (expect is null && have is null)
                return true;
            if (expect.Length != have.Length)
                return false;
            for(int i = 0; i < expect.Length; i++)
            {
                if (expect[i] != have[i])
                    return false;
            }
            return true;
        }

        [TestMethod]
        public void TestFindNthRoot()
        {
            var value1 = FindNthRootCls.FindNthRoot(1,5,0.0001f);
            var value2 = FindNthRootCls.FindNthRoot(8,3,0.0001f);
            var value0d1 = FindNthRootCls.FindNthRoot(0.001f,3,0.0001f);
            var value0d45 = FindNthRootCls.FindNthRoot(0.04100625f,4,0.0001f);
            var value2s = FindNthRootCls.FindNthRoot(8,3,0.0001f);
            var value0d6 = FindNthRootCls.FindNthRoot(0.0279936f,7,0.0001f);
            var value0d36 = FindNthRootCls.FindNthRoot(0.0081f,4,0.1f);
            var value0d22 = FindNthRootCls.FindNthRoot(0.008f,3,0.1f);
            var value0d545 = FindNthRootCls.FindNthRoot(0.004241979f,9,0.00000001f);

            Assert.AreEqual(1.0, value1);
            Assert.AreEqual(2.0, value2);
            Assert.AreEqual(0.1, value0d1);
            Assert.AreEqual(0.45, value0d45);
            Assert.AreEqual(2.0, value2s);
            Assert.AreEqual(0.6, value0d6);
            Assert.AreEqual(0.36, value0d36);
            Assert.AreEqual(0.22, value0d22);
            Assert.AreEqual(0.545, value0d545);
        }
    }
}
