using System.Drawing;

namespace MvcTest.Models
{
    public class IntegerSpiralCellViewModel
    {
        public int DisplayValue { get; set; }

        public string CellBackgroundColor { get; set; }

        public IntegerSpiralCellViewModel(int displayValue, string cellBackgroundColor)
        {
            DisplayValue = displayValue;
            CellBackgroundColor = cellBackgroundColor;
        }
    }
}
