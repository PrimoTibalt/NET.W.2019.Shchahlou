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
            var value15 = Program.InsertNumbers(15, 15, 0, 0);
            var value8 = Program.InsertNumbers(8, 15, 0, 0);
            var value120 = Program.InsertNumbers(8, 15, 3, 8);
            var valueNull = Program.InsertNumbers(8, 15, 4, 3);

            Assert.AreEqual(15, value15);
            Assert.AreEqual(8, value8);
            Assert.AreEqual(120, value120);
            Assert.AreEqual(null, valueNull);
        }

        [TestMethod]
        public void TestFindNextBiggerNumber()
        {
            var value21 = Program.FindNextBiggerNumber(12);
            var value531 = Program.FindNextBiggerNumber(513);
            var value2071 = Program.FindNextBiggerNumber(2017);
            var value441 = Program.FindNextBiggerNumber(414);
            var value414 = Program.FindNextBiggerNumber(144);
            var value1241233 = Program.FindNextBiggerNumber(1234321);
            var value1234162 = Program.FindNextBiggerNumber(1234126);
            var value3462345 = Program.FindNextBiggerNumber(3456432);
            var valueNull = Program.FindNextBiggerNumber(10);
            var valueNull0 = Program.FindNextBiggerNumber(20);

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
            var value7 = Program.FilterDigit(7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17);
            var value0 = Program.FilterDigit(0, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17, 1435, 13451, 11, 99, 10, 12, 123);
            var value1 = Program.FilterDigit(1, 127, 122, 23555, 12334, 674, 543, 1316, 9757, 628, 69, 70, 15, 17);
            var valueMinus1 = Program.FilterDigit(-1, 7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17);
            var value10 = Program.FilterDigit(10, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17, 1015, 11015, 111101010, 12310);

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
    }
}
