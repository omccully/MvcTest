using MvcTest.MathLibrary;
using System.Drawing;

namespace MvcTest.Models
{
    public class IntegerSpiralViewModel : Grid<IntegerSpiralCellViewModel>
    {
        public IntegerSpiralViewModel(int width, bool clockwise = true) : base(width, width)
        {
            var spiral = new IntegerSpiral(width, clockwise);

            int maxVal = spiral.Width * spiral.Width;

            for (int x = 0; x < spiral.Width; x++)
            {
                for (int y = 0; y < spiral.Height; y++)
                {
                    int cellVal = spiral.GetCell(x, y);

                    const int CellColorCount = 15;
                    byte colorVal = cellVal < CellColorCount ? (byte)(((float)cellVal / CellColorCount) * 255) : (byte)255;

                    string str = "#" + colorVal.ToString("X2") + "FF" + colorVal.ToString("X2");

                    var cell = new IntegerSpiralCellViewModel(cellVal, str);
                    base.SetCell(x, y, cell);
                }
            }
        }
    }
}
