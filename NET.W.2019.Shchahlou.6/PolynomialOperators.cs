using System;
using System.Collections.Generic;
using System.Text;

namespace NET.W._2019.Shchahlou._6
{
    /// <summary>
    /// Summarize, subtract and multiply polynomials with this class.
    /// Constructor gets your massive of coefficient.
    /// Overrides objects methods.
    /// </summary>
    public sealed partial class Polynomial
    {
        private readonly double[] polynom;

        public Polynomial(params double[] coef)
        {
            polynom = coef;
            Length = polynom.Length;
        }

        public int Length { get; set; }

        public double this[int index]
        {
            get { return polynom[index]; }
        }

        public static Polynomial operator +(Polynomial first, Polynomial second)
        {
            List<double> newCoef = new List<double>();
            Polynomial lengthBig = (first.Length < second.Length) ? second : first;
            Polynomial lengthSmall = (first.Length < second.Length) ? first : second;

            for (int i = 0; i < lengthBig.Length; i++)
            {
                if (i < lengthSmall.Length)
                {
                    newCoef.Add(lengthBig[i] + lengthSmall[i]);
                }
                else
                {
                    newCoef.Add(lengthBig[i]);
                }
            }

            return new Polynomial(newCoef.ToArray());
        }

        public static Polynomial operator -(Polynomial first, Polynomial second)
        {
            List<double> secCoefMinus = new List<double>();
            for (int i = 0; i < first.Length; i++)
            {
                secCoefMinus.Add(-second[i]);
            }

            return new Polynomial(secCoefMinus.ToArray()) + first;
        }

        public static Polynomial operator *(Polynomial first, Polynomial second)
        {
            int count = first.Length + second.Length - 1;
            double[] resultCoef = new double[count];

            for (int i = 0; i < first.Length; i++)
            {
                for (int j = 0; j < second.Length; j++)
                {
                    resultCoef[i + j] += first[i] * second[j];
                }
            }

            return new Polynomial(resultCoef);
        }

        public static bool operator ==(Polynomial first, Polynomial second)
        {
            return first.Equals(second);
        }

        public static bool operator !=(Polynomial first, Polynomial second)
        {
            return first.Equals(second);
        }
    }
}
