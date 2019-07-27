using RoboticMovementType.Interface;

namespace RoboticMovementType.BaseMovementModel
{
    public class Plateau : IMatrix
    {
        public Plateau(int matrixx, int matrixy)
        {
            Matrixx = matrixx;
            Matrixy = matrixy;
        }
        public int Matrixx { get; set; }
        public int Matrixy { get; set; }
    }
}
