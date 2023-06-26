using System.Drawing;

namespace MvcTest.MathLibrary
{
    public class Direction
    {
        public static Direction North = new Direction(0, -1);
        public static Direction South = new Direction(0, 1);
        public static Direction East = new Direction(1, 0);
        public static Direction West = new Direction(-1, 0);

        public readonly int XDirection, YDirection;


        /// <summary>
        /// positive x is right; positive y is down
        /// </summary>
        /// <param name="x_direction"></param>
        /// <param name="y_direction"></param>
        private Direction(int x_direction, int y_direction)
        {
            XDirection = x_direction;
            YDirection = y_direction;
        }

        public Point Move(Point p)
        {
            return new Point(p.X + XDirection, p.Y + YDirection);
        }

        public Direction Clockwise()
        {
            if (Equals(North)) return East;
            else if (Equals(East)) return South;
            else if (Equals(South)) return West;
            else if (Equals(West)) return North;
            else throw new Exception();
        }

        public Direction CounterClockwise()
        {
            if (Equals(North)) return West;
            else if (Equals(East)) return North;
            else if (Equals(South)) return East;
            else if (Equals(West)) return South;
            else throw new Exception();
        }

        public static bool operator ==(Direction left, Direction right)
        {
            if (Object.ReferenceEquals(left, right)) return true;

            if ((object)left == null || (object)right == null) return false;

            return left.XDirection == right.XDirection &&
                left.YDirection == right.YDirection;
        }
        public static bool operator !=(Direction left, Direction right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            Direction v = obj as Direction;
            if ((object)v == null) return false;

            return base.Equals(obj) && this == v;
        }

        public override int GetHashCode()
        {
            return XDirection.GetHashCode() ^ YDirection.GetHashCode();
        }
    }
}
