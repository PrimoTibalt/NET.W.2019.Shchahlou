namespace Tests
{
    using NET.W._2019.Shchahlou._6;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    [TestClass]
    public class TestDay6
    {
        #region Polynomial
        [TestMethod]
        public void TestToStringRand()
        {
            //arrange
            Polynomial vol2 = new Polynomial(-2, -3, 10);

            //act
            string v2 = vol2.ToString();

            //assert
            Assert.AreEqual("(10)x^2+(-3)x^1+(-2)=0", v2);
        }

        [TestMethod]
        public void TestToStringMax()
        {
            //arrange
            Polynomial vol1 = new Polynomial(Int32.MinValue, 0, Int32.MaxValue);

            //act
            string v1 = vol1.ToString();

            //assert
            Assert.AreEqual($"({Int32.MaxValue})x^2+({Int32.MinValue})=0", v1);
        }

        [TestMethod]
        public void TestEqualRand()
        {
            //arrange
            Polynomial vol = new Polynomial(-2, -3, 10, -5);
            Polynomial volRe = new Polynomial(-2, -3, 10, -5);


            //act
            bool res = vol.Equals(volRe);

            //assert
            Assert.IsTrue(res);
        }

        [TestMethod]
        public void TestEqualMax()
        {
            //arrange
            Polynomial vol = new Polynomial(Int32.MinValue, 0, Int32.MaxValue, 14);
            Polynomial volRe = new Polynomial(Int32.MinValue, 0, Int32.MaxValue, 14);


            //act
            bool res = vol.Equals(volRe);

            //assert
            Assert.IsTrue(res);
        }

        [TestMethod]
        public void TestPlus()
        {
            //arrange
            Polynomial vol1 = new Polynomial(0, 0, 0, 0);
            Polynomial vol3 = new Polynomial(-2, -3, 10, -5);

            //act
            Polynomial v13 = vol1 + vol3;

            //assert
            Assert.AreEqual(vol3, v13);
        }

        [TestMethod]
        public void TestMinus()
        {
            //arrange
            Polynomial vol1 = new Polynomial(0, 0, 0, 0);
            Polynomial vol3 = new Polynomial(-2, -3, 10, -5);

            //act
            Polynomial v13 = vol1 - vol3;

            //assert
            Assert.AreEqual("(5)x^3+(-10)x^2+(3)x^1+(2)=0", v13.ToString());
        }

        [TestMethod]
        public void TestMultiplication()
        {
            Polynomial vol3 = new Polynomial(-2, -3, 10, -5);
            Polynomial vol4 = new Polynomial(-2, -3, 10, -5);

            //act
            Polynomial v34 = vol3 * vol4;

            //assert
            Assert.AreEqual("(25)x^6+(-100)x^5+(130)x^4+(-40)x^3+(-31)x^2+(12)x^1+(4)=0", v34.ToString());
        }
        #endregion

        #region BubbleSort

        int[][] M1 = {
                new int[]{ 1, 2, 3 },
                new int[]{ 1, 2 },
                new int[]{ 1, 4 }
            };
        int[][] M2 =
        {
                new int[]{1999, 2017, 9999, Int32.MinValue, Int32.MaxValue },
                new int[]{ 2000, 200000, 0, 12, 7, 0, 20000, 2000},
                new int[]{ 1},
                new int[]{ 0},
                new int[]{ -1}
            };
        int[][] M3 =
        {
                new int[]{ -123},
                new int[]{ -123, 0},
                new int[]{ 0, 0, 0}
            };


        delegate int[][] SortingMethod(int[][] M);
        BubbleSort sort = new BubbleSort();



        bool MatrixEqual(int[][] M1, int[][] M2)
        {
            try
            {
                for (int i = 0; i < M1.Length; i++)
                    for (int j = 0; j < M1[i].Length; j++)
                        if (M1[i][j] != M2[i][j])
                            return false;
                return true;
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }
        }

        #region SumOfLines
        [TestMethod]
        public void TestAscendingSumOfLines()
        {
            //arrange
            SortingMethod sm = sort.AscendingSumOfLines;

            int[][] M2r =
            {
                new int[]{ 2000, 200000, 0, 12, 7, 0, 20000, 2000},
                new int[]{ 1999, 2017, 9999, Int32.MinValue, Int32.MaxValue },
                new int[]{ 1},
                new int[]{ 0},
                new int[]{ -1}
            };

            //act
            int[][] newest2 = sm(M2);

            //assert
            Assert.IsTrue(MatrixEqual(newest2, M2r));
        }

        [TestMethod]
        public void TestDecreasingSumOfLines()
        {
            //arrange
            SortingMethod sm = sort.DecreasingSumOfLines;
            
            int[][] M2r =
            {
                new int[]{ -1},
                new int[]{ 0},
                new int[]{ 1},
                new int[]{ 1999, 2017, 9999, Int32.MinValue, Int32.MaxValue },
                new int[]{ 2000, 200000, 0, 12, 7, 0, 20000, 2000}         
            };
            
            //act
            int[][] newest2 = sm(M2);

            //assert
            Assert.IsTrue(MatrixEqual(newest2, M2r));
        }
        #endregion

        #region MaxElementValue
        [TestMethod]
        public void TestAscendingMaxElementValue()
        {
            //arrange
            SortingMethod sm = sort.AscendingMaxElementValue;
            
            int[][] M2r =
            {
                new int[]{ 1999, 2017, 9999, Int32.MinValue, Int32.MaxValue },
                new int[]{ 2000, 200000, 0, 12, 7, 0, 20000, 2000 },
                new int[]{ 1},
                new int[]{ 0},
                new int[]{ -1}
            };
            
            //act
            int[][] newest2 = sm(M2);

            //assert
            Assert.IsTrue(MatrixEqual(newest2, M2r));
        }

        [TestMethod]
        public void TestDecreasingMaxElementValue()
        {
            //arrange
            SortingMethod sm = sort.DecreasingMaxElementValue;
            
            int[][] M2r =
            {
                new int[]{ -1},
                new int[]{ 0},
                new int[]{ 1},
                new int[]{ 2000, 200000, 0, 12, 7, 0, 20000, 2000 },
                new int[]{ 1999, 2017, 9999, Int32.MinValue, Int32.MaxValue },
            };

            //act
            int[][] newest2 = sm(M2);

            //assert
            Assert.IsTrue(MatrixEqual(newest2, M2r));
        }
        #endregion

        #region MinElementValue
        [TestMethod]
        public void TestAscendingMinElementValue()
        {
            //arrange
            SortingMethod sm = sort.AscendingMinElementValue;

            int[][] M2r =
            {
                new int[]{ 1},
                new int[]{ 2000, 200000, 0, 12, 7, 0, 20000, 2000},
                new int[]{ 0},
                new int[]{ -1},
                new int[]{ 1999, 2017, 9999, Int32.MinValue, Int32.MaxValue },
            };
            
            //act
            int[][] newest2 = sm(M2);

            //assert
            Assert.IsTrue(MatrixEqual(newest2, M2r));
        }


        [TestMethod]
        public void TestDecreasingMinElementValue()
        {
            //arrange
            SortingMethod sm = sort.DecreasingMinElementValue;


            int[][] M1r = {
                new int[]{ 1, 2, 3 },
                new int[]{ 1, 2 },
                new int[]{ 1, 4 }
            };

            //act
            int[][] newest1 = sm(M1);

            //assert
            Assert.IsTrue(MatrixEqual(newest1, M1r));
        }
        #endregion

        #endregion
    }
}
