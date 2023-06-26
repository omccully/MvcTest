using MvcTest.MathLibrary;

namespace MvcTest.Models
{
    public class SudokuInputViewModel : Grid<SudokuInputCellViewModel>
    {
        private const int Size = SudokuPuzzle.Size;

        public SudokuInputViewModel(SudokuSolutionResult? result) : base(Size, Size)
        {
            Initialize((x, y) => null);
            Result = result;
        }

        public SudokuInputViewModel(Grid<int> grid, SudokuSolutionResult? result) : base(Size, Size)
        {
            Initialize((x, y) => grid.GetCell(x, y));
            Result = result;
        }

        public SudokuSolutionResult? Result { get; set; }

        public static string GetCellName(int x, int y)
        {
            return $"sudoku_cell_{x}_{y}";
        }

        private void Initialize(Func<int, int, int?> getCellValue)
        {
            for (int x = 0; x < Size; x++)
            {
                for (int y = 0; y < Size; y++)
                {
                    SetCell(x, y, new SudokuInputCellViewModel(GetCellName(x, y), getCellValue(x, y)));
                }
            }
        }
    }
}
