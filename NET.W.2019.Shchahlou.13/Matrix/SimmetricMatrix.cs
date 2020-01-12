namespace NET.W._2019.Shchahlou._13.Matrix
{
    using System;

    public class SimmetricMatrix<T> : Matrix<T> where T : struct
    {
        /// <summary>
        /// Creates matrix 3*3
        /// </summary>
        public SimmetricMatrix()
        {
            matrix = new T[3, 3];
            if (!CheckSimmetric(matrix))
            {
                throw new SystemException("Wrong method to implement simmetric matrix.");
            }
        }

        /// <summary>
        /// Set deffault simmetric matrix.
        /// if matrix m isn't simmetric - will throw exception
        /// </summary>
        /// <param name="m"></param>
        public SimmetricMatrix(T[,] m)
        {
            if (m == null || !CheckSimmetric(m))
            {
                throw new ArgumentException("You pass wrong parameter in constructor.");
            }

            matrix = m;
        }

        /// <summary>
        /// If in simmetric matrix we change one element, then we have to change simmetric element
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
                matrix[row, column] = value;
                matrix[column, row] = value;
            }
        }

        /// <summary>
        /// Checks, does this matrix equial to the transporated matrix.
        /// </summary>
        /// <param name="matrixToCheck"></param>
        /// <returns></returns>
        private bool CheckSimmetric(T[,] matrixToCheck)
        {
            for (int i = 0; i < matrixToCheck.GetUpperBound(0); i++)
            {
                for (int j = 0; j < matrixToCheck.GetUpperBound(1); j++)
                {
                    if (matrix[i,j].Equals(matrix[j, i]))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
