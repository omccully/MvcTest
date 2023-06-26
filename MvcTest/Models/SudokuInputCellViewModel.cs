using System.Security.Policy;

namespace MvcTest.Models
{
    public class SudokuInputCellViewModel
    {
        public string CellName { get; set; }

        public int? CellValue { get; set; }

        public string? CellValueString { get; set; }

        public SudokuInputCellViewModel(string cellName, int? cellValue)
        {
            CellName = cellName;
            CellValue = cellValue;
            CellValueString = cellValue != null && cellValue > 0 ? cellValue.ToString() : "";
        }
    }
}
