﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NET.W._2019.Shchahlou._6
{
    public sealed class Polynomial
    {
        private double[] polynom;
        public int Length;
        public double this[int index]
        {
            get { return polynom[index]; }
        }
        
        public Polynomial(params double[] coef)
        {
            polynom = coef;
            Length = polynom.Length;
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
            List<double> newCoef = new List<double>();
            Polynomial lengthBig = (first.Length < second.Length) ? second : first;
            Polynomial lengthSmall = (first.Length < second.Length) ? first : second;

            for (int i = 0; i < lengthBig.Length; i++)
            {
                if (i < lengthSmall.Length)
                    newCoef.Add(lengthBig[i] + lengthSmall[i]);
                else
                    newCoef.Add(lengthBig[i]);
            }
            return new Polynomial(newCoef.ToArray());
        }

        public static Polynomial operator-(Polynomial first, Polynomial second)
        {
            List<double> secCoefMinus = new List<double>();
            for(int i = 0; i < first.Length; i++)
            {
                secCoefMinus.Add(-second[i]);
            }
            return new Polynomial(secCoefMinus.ToArray()) + first;
        }

        public static Polynomial operator*(Polynomial first, Polynomial second)
        {
            return new Polynomial();
        }
    }
}