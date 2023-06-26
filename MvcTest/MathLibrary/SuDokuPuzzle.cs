namespace MvcTest.MathLibrary
{
    public class SudokuPuzzle : Grid<int>
    {
        public const int Size = 9;

        public SudokuPuzzle() : base(Size, Size)
        {


        }

        public SudokuPuzzle(int[,] grid) : this()
        {
            for (int row = 0; row < Size; row++)
            {
                for (int col = 0; col < Size; col++)
                {
                    SetCell(col, row, grid[col, row]);
                }
            }
        }

        public override void SetCell(int X, int Y, int value)
        {
            // throw if invalid

            base.SetCell(X, Y, value);
        }


        public bool SectionContains(int X, int Y, int value)
        {
            int section_x = X / 3;
            int section_y = Y / 3;
            int section_x_start = section_x * 3;
            int section_y_start = section_y * 3;

            for (int col = section_x_start; col < section_x_start + 3; col++)
            {
                for (int row = section_y_start; row < section_y_start + 3; row++)
                {
                    if (GetCell(col, row) == value) return true;
                }
            }

            return false;
        }

        public int SolutionPass()
        {
            int solutions_made = 0;

            for (int x = 0; x < Size; x++)
            {
                for (int y = 0; y < Size; y++)
                {
                    if (GetCell(x, y) != 0) continue;

                    int possible_solutions_found = 0;
                    int last_solution_found = 0;

                    foreach (int possible_solution in GetPossibleSolutions(x, y))
                    {
                        possible_solutions_found++;
                        last_solution_found = possible_solution;
                    }


                    if (possible_solutions_found == 1)
                    {
                        SetCell(x, y, last_solution_found);
                        solutions_made++;
                    }
                }
            }

            return solutions_made;
        }

        public bool IsSolved
        {
            get
            {
                for (int x = 0; x < Size; x++)
                {
                    for (int y = 0; y < Size; y++)
                    {
                        if (GetCell(x, y) == 0) return false;
                    }
                }
                return true;
            }
        }

        public SudokuSolutionResult Solve()
        {
            bool solved = true;
            // keep calling SolutionPass() until it stops doing anything
            while (SolutionPass() > 0) ;

            if (IsSolved) return SudokuSolutionResult.SolvedWithoutGuessing;

            // this section serves multiple purposes:
            // determining if the puzzle was solved by the SolutionPass()es
            // and guessing solutions and checking to see if it works
            for (int x = 0; x < Size; x++)
            {
                for (int y = 0; y < Size; y++)
                {
                    if (GetCell(x, y) != 0) continue;

                    solved = false;

                    foreach (int guess in GetPossibleSolutions(x, y))
                    {
                        // take a guess
                        SudokuPuzzle copy = Copy();
                        copy.SetCell(x, y, guess);
                        if (copy.Solve() != SudokuSolutionResult.NotSolved)
                        {
                            CopyFrom(copy);
                            return SudokuSolutionResult.SolvedWithGuessing;
                        }
                    }

                    // if all guesses fail, then it's unsolvable!
                    return SudokuSolutionResult.NotSolved;
                }
            }

            return IsSolved ? SudokuSolutionResult.SolvedWithGuessing :
                SudokuSolutionResult.NotSolved;
        }

        IEnumerable<int> GetPossibleSolutions(int X, int Y)
        {
            return Enumerable.Range(1, Size).Where(i =>
                !ColumnContains(X, i) &&
                !RowContains(Y, i) &&
                !SectionContains(X, Y, i));
        }

        public void CopyFrom(SudokuPuzzle other)
        {
            for (int x = 0; x < Size; x++)
            {
                for (int y = 0; y < Size; y++)
                {
                    SetCell(x, y, other.GetCell(x, y));
                }
            }
        }

        public SudokuPuzzle Copy()
        {
            SudokuPuzzle copy = new SudokuPuzzle();
            copy.CopyFrom(this);

            return copy;
        }

        public static SudokuPuzzle Parse(string text)
        {
            return Parse(text.Split('\n'));
        }

        public static SudokuPuzzle Parse(IEnumerable<string> lines)
        {
            SudokuPuzzle puzzle = new SudokuPuzzle();
            int row = 0;
            foreach (string line in lines)
            {
                for (int col = 0; col < Size; col++)
                {
                    int digit = (int)char.GetNumericValue(line[col]);
                    puzzle.SetCell(col, row, digit);
                }

                row++;
                if (row > Size && !String.IsNullOrWhiteSpace(line))
                {
                    throw new ArgumentException("too many lines!");
                }
            }
            return puzzle;
        }
    }
}
