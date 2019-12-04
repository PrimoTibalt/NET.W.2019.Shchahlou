using System;
using System.Collections.Generic;
using System.Text;

namespace NET.W._2019.Shchahlou._6
{
    public sealed partial class Polynomial
    {
        /// <summary>
        /// Compare result of ToString methods.
        /// </summary>
        public override bool Equals(object pol)
        {
            return this.ToString().Equals(pol.ToString());
        }

        /// <summary>
        /// HashCode result of ToString.
        /// </summary>
        public override int GetHashCode()
        {
            // We could get 2 objects with same HashCode.
            // What is better to do?
            return this.ToString().GetHashCode();
        }

        /// <summary>
        /// With 'new Polynomial(10, 5, -3, 0);'
        /// </summary>
        /// <returns>'(-3)x^2+(5)x^1+(10)=0'</returns>
        public override string ToString()
        {
            StringBuilder strPolynom = new StringBuilder();

            // Add coefficient with higest power in polynom.
            strPolynom.Append((polynom[polynom.Length - 1] != 0) ?
                $"({polynom[polynom.Length - 1]})x^{polynom.Length - 1}" : string.Empty);

            if (Polynomial.IsEmpty(this))
            {
                return "Polynom is empty.";
            }

            for (int power = polynom.Length - 2; power >= 0; power--)
            {
                // Last coefficient (with power=0) dont have 'x'
                // and after him '=0' thats why we need another behavior.
                if (power != 0)
                {
                    // If coefficient of some 'x' is 0 then we wouldn't show it.
                    if (polynom[power] == 0)
                    {
                        continue;
                    }

                    strPolynom.Append($"+({polynom[power]})x^{power}");
                }
                else
                {
                    if (polynom[power] != 0)
                    {
                        strPolynom.Append($"+({polynom[power]})=0");
                    }
                    else
                    {
                        strPolynom.Append("=0");
                    }
                }
            }

            return strPolynom.ToString();
        }

        /// <returns>
        /// true - if every coefficient of pol is '0'.
        /// false - if have at least one coefficient not equal to '0'.
        /// </returns>
        private static bool IsEmpty(Polynomial pol)
        {
            for (int i = 0; i < pol.Length; i++)
            {
                if (pol[i] != 0)
                { 
                    return false;
                }
            }

            return true;
        }
    }
}
