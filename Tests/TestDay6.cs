using NET.W._2019.Shchahlou._6;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


namespace Tests
{
    [TestClass]
    public class TestDay6
    {
        [TestMethod]
        public void TestToString()
        {
            //arrange
            Polynomial vol1 = new Polynomial(Int32.MinValue, 0, Int32.MaxValue);
            Polynomial vol2 = new Polynomial(-2, -3, 10);

            //act
            string v1 = vol1.ToString();
            string v2 = vol2.ToString();

            //assert
            Assert.AreEqual($"({Int32.MaxValue})x^2+({Int32.MinValue})=0", v1);
            Assert.AreEqual("(10)x^2+(-3)x^1+(-2)=0", v2);
        }

        [TestMethod]
        public void TestEqual()
        {
            //arrange
            Polynomial vol1 = new Polynomial(Int32.MinValue, 0, Int32.MaxValue, 14);
            Polynomial vol1re = new Polynomial(Int32.MinValue, 0, Int32.MaxValue, 14);
            Polynomial vol2 = new Polynomial(-2, -3, 10, -5);
            Polynomial vol2re = new Polynomial(-2, -3, 10, -5);


            //act
            bool vF12 = vol1.Equals(vol2);
            bool vF21 = vol2.Equals(vol1);
            bool vT22 = vol2.Equals(vol2re);
            bool vT11 = vol1.Equals(vol1re);

            //assert
            Assert.IsFalse(vF12);
            Assert.IsFalse(vF21);
            Assert.IsTrue(vT22);
            Assert.IsTrue(vT11);
        }

        [TestMethod]
        public void TestPlus()
        {
            //arrange
            Polynomial vol1 = new Polynomial(0, 0, 0, 0);
            Polynomial vol2 = new Polynomial(0, 0, 1, -1);
            Polynomial vol3 = new Polynomial(-2, -3, 10, -5);
            Polynomial vol4 = new Polynomial(-2, -3, 10, -5);

            //act
            Polynomial v12 = vol1 + vol2;
            Polynomial v13 = vol1 + vol3;
            Polynomial v34 = vol3 + vol4;

            //assert
            Assert.AreEqual(vol2, v12);
            Assert.AreEqual(vol3, v13);
            Assert.AreEqual("(-10)x^3+(20)x^2+(-6)x^1+(-4)=0", v34.ToString());
        }

        [TestMethod]
        public void TestMinus()
        {
            //arrange
            Polynomial vol1 = new Polynomial(0, 0, 0, 0);
            Polynomial vol2 = new Polynomial(0, 0, 1, -1);
            Polynomial vol3 = new Polynomial(-2, -3, 10, -5);
            Polynomial vol4 = new Polynomial(-2, -3, 10, -5);

            //act
            Polynomial v12 = vol1 - vol2;
            Polynomial v13 = vol1 - vol3;
            Polynomial v34 = vol3 - vol4;

            //assert
            Assert.AreEqual("(1)x^3+(-1)x^2=0", v12.ToString());
            Assert.AreEqual("(5)x^3+(-10)x^2+(3)x^1+(2)=0", v13.ToString());
            Assert.AreEqual("Polynom is empty.", v34.ToString());
        }

        [TestMethod]
        public void TestMultiplication()
        {
            Polynomial vol1 = new Polynomial(0, 0, 0, 0);
            Polynomial vol2 = new Polynomial(0, 0, 1, -1);
            Polynomial vol3 = new Polynomial(-2, -3, 10, -5);
            Polynomial vol4 = new Polynomial(-2, -3, 10, -5);

            //act
            Polynomial v12 = vol1 * vol2;
            Polynomial v13 = vol1 * vol3;
            Polynomial v34 = vol3 * vol4;

            //assert
            Assert.AreEqual("Polynom is empty.", v12.ToString());
            Assert.AreEqual("Polynom is empty.", v13.ToString());
            Assert.AreEqual("(25)x^6+(-100)x^5+(130)x^4+(-40)x^3+(-31)x^2+(12)x^1+(4)=0", v34.ToString());
        }
    }
}
