using RoboticMovementType.Enums;
using RoboticMovementType.Interface;
using System;

namespace RoboticMovementType.BaseMovementModel
{
    /// <summary>
    /// Rover base class
    /// Moveable rover
    /// </summary>
    public class Rover : IRover
    {
        public Rover(IPosition position, Direction direction)
        {
            this.Position = position;
            this.Direction = direction;
        }

        public IPosition Position { get; set; }
        public Direction Direction { get; set; }

        /// <summary>
        /// Command that allows the rover to move
        /// </summary>
        /// <param name="moveCommand"></param>
        /// <returns></returns>
        public virtual bool Move(string moveCommand)
        {
            char[] moveInputs = moveCommand.ToCharArray();

            foreach (char movement in moveInputs)
            {
                switch (Enum.Parse(typeof(Movement), movement.ToString()))
                {
                    case Movement.L:
                        this.MoveLeft();
                        break;
                    case Movement.R:
                        this.MoveRight();
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

        public virtual void MoveLeft()
        {
            this.Direction = (this.Direction - 1) < Direction.N ? Direction.W : this.Direction - 1;
        }

        public virtual void MoveRight()
        {
            this.Direction = (this.Direction + 1) > Direction.W ? Direction.N : this.Direction + 1;
        }

        /// <summary>
        /// Rover go ahead
        /// Rover don't have to be careful
        /// </summary>
        public virtual void MoveAhead()
        {
            switch (this.Direction)
            {
                case Direction.N:
                    this.Position.Y++;
                    break;
                case Direction.S:
                    this.Position.Y--;
                    break;
                case Direction.E:
                    this.Position.X++;
                    break;
                case Direction.W:
                    this.Position.X--;
                    break;
                default:
                    throw new ArgumentException(string.Format("Invalid direction {0}", Direction));
            }
        }     
    }
}
