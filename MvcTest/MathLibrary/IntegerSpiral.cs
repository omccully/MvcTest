using System.Drawing;

namespace MvcTest.MathLibrary
{
    public class IntegerSpiral : Grid<int>
    {
        public IntegerSpiral(int width, bool clockwise = true) : base(width, width)
        {
            if (width % 2 == 0) throw new ArgumentException("width must be odd");

            int highest_number = width * width;
            int center = width / 2;

            Point p = new Point(center, center);

            Direction d = Direction.East;
            int distance_from_center = 0;

            for (int i = 1; i <= highest_number; i++)
            {
                SetCell(p.X, p.Y, i);

                p = d.Move(p);

                // turn when the next move would mean going out of bounds

                // continue on past distance_from_center when going east
                Point next_move = d.Move(p);

                if (d == Direction.East)
                {
                    if (Math.Abs(next_move.X - center) > distance_from_center + 1 ||
                        Math.Abs(next_move.Y - center) > distance_from_center + 1)
                    {
                        distance_from_center++;
                        if (clockwise) d = d.Clockwise();
                        else d = d.CounterClockwise();
                    }
                }
                else // turn at distance_from_center otherwise
                {
                    if (Math.Abs(next_move.X - center) > distance_from_center ||
                        Math.Abs(next_move.Y - center) > distance_from_center)
                    {
                        if (clockwise) d = d.Clockwise();
                        else d = d.CounterClockwise();
                    }
                }
            }
        }
    }
}
