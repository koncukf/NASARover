using RoboticMovementType.Interface;

namespace RoboticMovementType.BaseMovementModel
{
    public class Position : IPosition
    {
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }
        public int X { get; set; }
        public int Y { get; set; }
    }
}
