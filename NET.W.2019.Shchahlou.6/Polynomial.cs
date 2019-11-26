using System;
using System.Collections.Generic;
using System.Text;

namespace NET.W._2019.Shchahlou._6
{
    public sealed class Polynomial
    {
        private double[] polynom;
        
        public Polynomial(params double[] coef)
        {
            polynom = coef;
        }
        public override bool Equals(object pol)
        {
            return base.Equals(pol);
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public override string ToString()
        {
            StringBuilder strPolynom = new StringBuilder();
            for(int power = 0; power < polynom.Length; power++)
            {
                strPolynom.Append($"{polynom[power]}x^{power}");
                if (power != polynom.Length - 1)
                    strPolynom.Append("+");
                else
                    strPolynom.Append("=0");
            }
            return strPolynom.ToString();
        }

        public static Polynomial operator+(Polynomial first, Polynomial second)
        {
            return new Polynomial();
        }

        public static Polynomial operator-(Polynomial first, Polynomial second)
        {
            return new Polynomial();
        }

        public static Polynomial operator *(Polynomial first, Polynomial second)
        {
            return new Polynomial();
        }
    }
}
