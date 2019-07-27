using RoboticMovementType.Interface;

namespace NASARover.MovementManager
{
    /// <summary>
    /// Any plateau related to any rover is also used to perform process.
    /// </summary>
    /// <typeparam name="R"></typeparam>
    /// <typeparam name="P"></typeparam>
    public class MovementControl<R, P> where R : IRover
    where P : IMatrix
    {
        R _rover;
        P _plateau;

        public MovementControl(R rover,P plateau )
        {
            this._rover = rover;
            this._plateau = plateau;
        }

        public bool RoverInMatrix()
        {
            return (this._rover.Position.X >= 0) && (this._rover.Position.X <= this._plateau.Matrixx) &&
                (this._rover.Position.Y >= 0) && (this._rover.Position.Y <= this._plateau.Matrixy);
        }
    }
}
