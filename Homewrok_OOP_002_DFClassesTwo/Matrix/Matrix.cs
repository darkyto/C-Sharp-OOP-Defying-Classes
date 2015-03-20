namespace Homewrok_OOP_002_DFClassesTwo.Matrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Media;

    public class Matrix<T> where T : IComparable
    {
        #region fields
        private int rows;
        private int cols;
        private T[,] matrix;

        #endregion

        #region constructors
        public Matrix(int x, int y)
        {
            this.Rows = x;
            this.Cols = y;
            this.matrix = new T[x, y];
        }
        #endregion

        #region properties
        public int Rows
        {
            get { return rows; }
            set { rows = value; }
        }
        public int Cols
        {
            get { return cols; }
            set { cols = value; }
        }
        public T this[int rowIndex, int colIndex] // Implement an indexer this[row, col] to access the inner matrix cells.
        {
            get
            {
                if ((rowIndex < 0 || rowIndex >= this.rows) || (colIndex < 0 || colIndex >= this.cols))
                {
                    throw new IndexOutOfRangeException("Index out of range!!");
                }

                return this.matrix[rowIndex, colIndex];

            }
            set
            {
                if ((rowIndex < 0 || rowIndex >= this.rows) || (colIndex < 0 || colIndex >= this.cols))
                {
                    throw new IndexOutOfRangeException("Index out of range!!");
                }

                this.matrix[rowIndex, colIndex] = value;
            }
        }

        #endregion

        #region methods
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int index = 0; index < matrix.GetLength(1); index++)
                {
                    sb.Append(matrix[i, index] + " ");
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }

        public static Matrix<T> operator +(Matrix<T> a, Matrix<T> b) // operation ADDING a matrixes
        {
            if (a.Cols != b.Cols || a.Rows != b.Rows)
            {
                throw new ArgumentException("Compared matrixes do not have equal size!");
            }

            Matrix<T> result = new Matrix<T>(a.Rows, a.Cols);

            for (int x = 0; x < result.Rows; x++)
            {
                for (int y = 0; y < result.Cols; y++)
                {
                    result[x, y] = (dynamic)a[x, y] + b[x, y];
                }
            }
            return result;
        }

        public static Matrix<T> operator -(Matrix<T> a, Matrix<T> b) // operation SUBSTRACTION a matrixes
        {
            if (a.Cols != b.Cols || a.Rows != b.Rows)
            {
                throw new ArgumentException("Compared matrixes do not have equal size!");
            }

            Matrix<T> result = new Matrix<T>(a.Rows, a.Cols);

            for (int x = 0; x < result.Rows; x++)
            {
                for (int y = 0; y < result.Cols; y++)
                {
                    result[x, y] = (dynamic)a[x, y] - b[x, y];
                }
            }
            return result;
        }

        public static Matrix<T> operator *(Matrix<T> a, Matrix<T> b) // MULTIPLY MATRIX 
        {
            if (a.Cols != b.Rows)
            {
                throw new ArgumentException("Multiplication possible only when Matrix.A.Columns are equal to Matrix.B.Rows!");
            }
            Matrix<T> result = new Matrix<T>(a.Rows, b.Cols);
            T temp = (dynamic)0;

            for (int x = 0; x < a.Rows; x++)
            {
                for (int y = 0; y < b.Cols; y++)
                {
                    for (int i = 0; i < a.Cols; i++)
                    {
                        temp += (dynamic)a[x, i] * b[i, y];
                    }
                    result[x, y] = temp;
                    temp = (dynamic)0;
                }
            }
            return result;
        }

        public static bool operator true(Matrix<T> matrix) //true
        {
            for (int x = 0; x < matrix.Rows; x++)
            {
                for (int y = 0; y < matrix.Cols; y++)
                {
                    if (matrix[x, y] == (dynamic)0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public static bool operator false(Matrix<T> matrix) // beacuse of True we now need False
        {
            for (int x = 0; x < matrix.Rows; x++)
            {
                for (int y = 0; y < matrix.Cols; y++)
                {
                    if (matrix[x, y] == (dynamic)0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        #endregion
    }
}
