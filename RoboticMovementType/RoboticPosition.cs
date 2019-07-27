using RoboticMovementType.BaseMovementModel;

namespace RoboticMovementType
{
    public class RoboticPosition : Position
    {
        public RoboticPosition(int x, int y) : base(x, y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}
