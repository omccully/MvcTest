using System.Text;

namespace MvcTest.MathLibrary
{
    public class Grid<T>
    {
        T[,] Cells;

        public int Height
        {
            get
            {
                return Cells.GetLength(0);
            }
        }

        public int Width
        {
            get
            {
                return Cells.GetLength(1);
            }
        }

        public T GetCell(int X, int Y)
        {
            return Cells[Y, X];
        }

        public virtual void SetCell(int X, int Y, T value)
        {
            Cells[Y, X] = value;
        }

        public Grid(int height, int width) : this(new T[height, width])
        {

        }

        protected Grid(T[,] cells)
        {
            this.Cells = cells;
        }

        public T[] GetVerticalLine(int x, int y, int length)
        {
            T[] line = new T[length];

            for (int i = 0; i < length; i++)
            {
                line[i] = Cells[y + i, x];
            }

            return line;
        }

        public T[] GetHorizontalLine(int x, int y, int length)
        {
            T[] line = new T[length];

            for (int i = 0; i < length; i++)
            {
                line[i] = Cells[y, x + i];
            }

            return line;
        }

        /// <summary>
        /// Diagonal line that goes down and to the right
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public T[] GetSouthEastDiagonalLine(int x, int y, int length)
        {
            T[] line = new T[length];

            for (int i = 0; i < length; i++)
            {
                line[i] = Cells[y + i, x + i];
            }

            return line;
        }

        /// <summary>
        /// Diagonal line that goes down and to the left
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public T[] GetSouthWestDiagonalLine(int x, int y, int length)
        {
            T[] line = new T[length];

            for (int i = 0; i < length; i++)
            {
                line[i] = Cells[y + i, x - i];
            }

            return line;
        }

        public T[] GetBothDiagonals()
        {
            T[] se_diag = GetSouthEastDiagonalLine(0, 0, Math.Min(Width, Height));
            List<T> values = new List<T>(se_diag);

            for (int i = 0; i < se_diag.Length; i++)
            {
                int x = i;
                int y = (Width - 1) - i;
                if (x == y) continue; // overlapping

                values.Add(Cells[x, y]);
            }

            return values.ToArray();
        }

        public T GetSouthEastDiagonalSum()
        {
            return LineSum(GetSouthEastDiagonalLine(0, 0, Math.Min(Width, Height)));
        }

        public T GetSouthWestDiagonalSum()
        {
            return LineSum(GetSouthWestDiagonalLine(Width - 1, 0, Math.Min(Width, Height)));
        }

        private T LineSum(T[] line)
        {
            dynamic sum = default(T);

            foreach (T ele in line)
            {
                sum += ele;
            }

            return sum;
        }

        public virtual bool RowContains(int row, T val)
        {
            // a class may override this to use 
            // a HashSet if efficiency is needed
            EqualityComparer<T> comparer = EqualityComparer<T>.Default;

            for (int col = 0; col < Width; col++)
            {
                if (comparer.Equals(GetCell(col, row), val)) return true;
            }

            return false;
        }

        public virtual bool ColumnContains(int col, T val)
        {
            // a class may override this to use 
            // a HashSet if efficiency is needed

            EqualityComparer<T> comparer = EqualityComparer<T>.Default;

            for (int row = 0; row < Height; row++)
            {
                if (comparer.Equals(GetCell(col, row), val)) return true;
            }

            return false;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    result.Append(GetCell(x, y).ToString().PadLeft(4));

                }
                result.Append(Environment.NewLine);
            }
            return result.ToString();
        }
    }
}
