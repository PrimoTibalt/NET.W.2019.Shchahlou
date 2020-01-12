namespace NET.W._2019.Shchahlou._13.Matrix
{
    using System;

    /// <summary>
    /// Matrix with every element, that not on a main diagonal are equal 0.
    /// </summary>
    public class DiagonalMatrix<T> : Matrix<T> where T : struct
    {
        /// <summary>
        /// Creates matrix 3*3
        /// </summary>
        public DiagonalMatrix()
        {
            matrix = new T[3, 3];
            if (!CheckDiagonal(matrix))
            {
                throw new SystemException("Wrong method to implement simmetric matrix.");
            }
        }

        /// <summary>
        /// Set deffault diagonal matrix.
        /// if matrix m isn't diagonal - will throw exception
        /// </summary>
        /// <param name="m"></param>
        public DiagonalMatrix(T[,] m)
        {
            if (m == null || !CheckDiagonal(m))
            {
                throw new ArgumentException("You pass wrong parameter in constructor.");
            }

            matrix = m;
        }

        /// <summary>
        /// If in diagonal matrix we can change only elements from main diagonal, other are 0.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        public override T this[int row, int column]
        {
            get
            {
                return base[row, column];
            }

            set
            {
                if (row != column && !value.Equals(new T()))
                {
                    throw new ArgumentException("Tried to set some number to element not from main diagonal.");
                }
                else
                {
                    if (row != column)
                    {
                        matrix[row, column] = new T();
                    }
                }

                if (row == column)
                {
                    matrix[row, column] = value;
                }
            }
        }

        /// <summary>
        /// Checks, do elements, that not on main diagonal equal to standart value of structure.
        /// </summary>
        /// <param name="matrixToCheck"></param>
        /// <returns></returns>
        private bool CheckDiagonal(T[,] matrixToCheck)
        {

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (i != j && matrix[i, j].Equals(new T()))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
