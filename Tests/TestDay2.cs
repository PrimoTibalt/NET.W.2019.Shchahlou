namespace Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NET.W._2019.Shchahlou._2;

    [TestClass]
    public class TestDay2
    {
        // --------------------------Test Insert--------------------------
        [TestMethod]
        public void TestInsertNumberConst()
        {
            var value15 = InsertNumbersCls.InsertNumbers(15, 15, 0, 0);

            Assert.AreEqual(15, value15);
        }

        [TestMethod]
        public void TestInsertNumberMain()
        {            
            var value120 = InsertNumbersCls.InsertNumbers(8, 15, 3, 8);
            
            Assert.AreEqual(120, value120);
        }

        [TestMethod]
        public void TestInsertNumberZero()
        {
            var value8 = InsertNumbersCls.InsertNumbers(8, 15, 0, 0);

            Assert.AreEqual(8, value8);
        }
        // --------------------------End of test Insert--------------------------

        // --------------------------Test Find-----------------------------------
        [TestMethod]
        public void TestFindNextBiggerNumberZero()
        {
            var value = FindNextBiggerNumberCls.FindNextBiggerNumber(0);

            Assert.AreEqual(null, value);
        }

        [TestMethod]
        public void TestFindNextBiggerNumber()
        {
            var value1234162 = FindNextBiggerNumberCls.FindNextBiggerNumber(1234126);

            Assert.AreEqual(1234162, value1234162);
        }
        // --------------------------End of test Find--------------------------

        // --------------------------Test Filter-----------------------------------
        [TestMethod]
        public void TestFilterDigit()
        {
            var value7 = FilterDigitCls.FilterDigit(7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17);            

            Assert.IsTrue(CheckArrays(new int[] { 7, 70, 17 }, value7));
        }

        [TestMethod]
        public void TestFilterDigitNull()
        {
            Assert.ThrowsException<ArgumentNullException>(() => FilterDigitCls.FilterDigit(7, null));
        }

        [TestMethod]
        public void TestFilterDigitMax()
        {
            var value7 = FilterDigitCls.FilterDigit(int.MaxValue, int.MaxValue, int.MinValue, 10, -10, 0, 150, 7984900, int.MinValue, int.MinValue, int.MaxValue, int.MaxValue);

            Assert.IsTrue(CheckArrays(new int[] { int.MaxValue, int.MaxValue, int.MaxValue }, value7));
        }

        private bool CheckArrays(int[] expect, int[] have)
        {
            if (expect is null && have is null)
            {
                return true;
            }
                
            if (expect.Length != have.Length)
            {
                return false;
            }
            
            for(int i = 0; i < expect.Length; i++)
            {
                if (expect[i] != have[i])
                {
                    return false;
                }
            }

            return true;
        }
        // --------------------------End of test Filter-----------------------------------

        // --------------------------Test FindNthRoot-----------------------------------------
        [TestMethod]
        public void TestFindNthRoot()
        {
            var value0d545 = FindNthRootCls.FindNthRoot(0.004241979f,9,0.00000001f);

            Assert.AreEqual(0.545, value0d545);
        }

        [TestMethod]
        public void TestFindNthRootNumberZero()
        {
            var value0 = FindNthRootCls.FindNthRoot(0f, 9, 0.03f);

            Assert.AreEqual(0, value0);
        }

        [TestMethod]
        public void TestFindNthRootPrecisionZero()
        {
            var value0 = FindNthRootCls.FindNthRoot(0.1f, 9, 0.0f);

            Assert.AreEqual(0.774, value0);
        }
            // --------------------------End of test FindNthRoot-----------------------------------
        }
}
