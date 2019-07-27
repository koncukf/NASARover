using RoboticMovementType.Enums;

namespace RoboticMovementType.Interface
{
    public interface IRover
    {
        IPosition Position { get; set; }

        Direction Direction { get; set; }
    }
}
