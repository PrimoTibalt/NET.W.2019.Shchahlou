namespace NET.W._2019.Shchahlou._2.TestNUnit
{
    using NET.W._2019.Shchahlou._2;
    using NUnit.Framework;

    [TestFixture]
    public class TestFilter
    {
        [TestCase(int.MaxValue, new int[] { int.MaxValue, int.MinValue, 0, 1, -1, 123411, -12341464, int.MinValue}, ExpectedResult = new int[] { int.MaxValue, int.MinValue, int.MinValue})]
        [TestCase(0, new int[] { 0 }, ExpectedResult = new int[] { 0 })]
        [TestCase(7, new int[] { 7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 }, ExpectedResult = new int[] { 7, 70, 17 })]
        public int[] TestFilterDigit(int main, params int[] arr)
        {
            return FilterDigitCls.FilterDigit(main, arr);
        }
    }

    // Tests, that use MSUnit in package Test.
}
