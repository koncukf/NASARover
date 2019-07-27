
using RoboticMovementType.BaseMovementModel;

namespace RoboticMovementType
{
    public class MarsPlateau : Plateau
    {
        public MarsPlateau(int width, int height) : base(width, height)
        {
            this.Matrixx = width;
            this.Matrixy = height;
        }
    }
}
