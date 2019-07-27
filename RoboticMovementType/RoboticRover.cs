using RoboticMovementType.BaseMovementModel;
using RoboticMovementType.Enums;
using RoboticMovementType.Interface;
using System;

namespace RoboticMovementType
{
    /// <summary>
    /// Rover can move with the command
    /// Rover also moves on the plateau on the planets
    /// </summary>
    public class RoboticRover : Rover
    {
        public IMatrix Plateau { get; set; }
        public RoboticRover(IPosition position, Direction direction, IMatrix plateau) : base(position, direction)
        {
            this.Plateau = plateau;

            if (!RoverInMatrix())
                return;
        }

        /// <summary>
        /// Is Rover in the plateau
        /// </summary>
        /// <returns></returns>
        private bool RoverInMatrix()
        {
            return (Position.X >= 0) && (Position.X < Plateau.Matrixx) &&
                (Position.Y >= 0) && (Position.Y < Plateau.Matrixy);
        }

        /// <summary>
        /// Command that allows the rover to move
        /// </summary>
        /// <param name="moveCommand"></param>
        /// <returns></returns>
        public override bool Move(string moveCommand)
        {
            char[] moveInputs = moveCommand.ToCharArray();

            foreach (char movement in moveInputs)
            {
                switch (Enum.Parse(typeof(Movement), movement.ToString()))
                {
                    case Movement.L:
                        base.MoveLeft();
                        break;
                    case Movement.R:
                        base.MoveRight();
                        break;
                    case Movement.M:
                        this.MoveAhead();
                        break;
                    default:
                        throw new ArgumentException(string.Format("Incorrect input : {0}", movement));
                }
            }

            return true;
        }

        /// <summary>
        /// Rover go ahead
        /// Rover also be carefull
        /// </summary>
        public override void MoveAhead()
        {
            base.MoveAhead();

            if (this.Position.X < 0 || this.Position.Y < 0 || this.Position.X > this.Plateau.Matrixx || this.Position.Y > this.Plateau.Matrixy)
                throw new OperationCanceledException("Rover can not move, process canceled");
        }
    }
        
}
