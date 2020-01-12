namespace NET.W._2019.Shchahlou._13
{
    using System;

    /// <summary>
    /// square matrix
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Matrix<T> where T : struct
    {
        protected T[,] matrix;

        /// <summary>
        /// Creates matrix 3*3.
        /// </summary>
        public Matrix()
        {
            matrix = new T[3, 3];
        }

        /// <summary>
        /// Sets matrix with elements from m.
        /// </summary>
        /// <param name="m"></param>
        public Matrix(T[,] m)
        {
            if (m == null || m.Length < 2)
            {
                throw new ArgumentNullException("Marix cannot be null.");
            }
            else
            {
                matrix = m;
            }
        }

        /// <summary>
        /// Create matrix with size*size proportion.
        /// </summary>
        /// <param name="size"></param>
        public Matrix(int size)
        {
            if (size < 2)
            {
                throw new ArgumentException("Size of matrix cannot be less than 2.");
            }
            else
            {
                matrix = new T[size, size];
            }
        }

        public virtual T this[int row, int column]
        {
            get
            {
                return matrix[row, column];
            }

            set
            {
                matrix[row, column] = value;
            }
        }
    }
}
