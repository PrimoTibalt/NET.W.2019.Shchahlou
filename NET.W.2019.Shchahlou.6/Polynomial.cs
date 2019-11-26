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
            return this.ToString().Equals(pol.ToString());
        }

        public override int GetHashCode()
        {
            //We could get 2 objects with same HashCode.
            //What is better to do?

            return this.ToString().GetHashCode();
        }

        public override string ToString()
        {
            StringBuilder strPolynom = new StringBuilder();
            for(int power = polynom.Length-1; power >= 0 ; power--)
            {
                if (polynom[power] == 0)
                    continue;
                if (power != 0)
                    strPolynom.Append($"({polynom[power]})x^{power}+");
                else
                    strPolynom.Append($"({polynom[power]})=0");
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

        public static Polynomial operator*(Polynomial first, Polynomial second)
        {
            return new Polynomial();
        }
    }
}
