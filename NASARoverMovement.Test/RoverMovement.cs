using Microsoft.VisualStudio.TestTools.UnitTesting;
using NASARover.MovementManager;
using RoboticMovementType;
using RoboticMovementType.Enums;
using RoboticMovementType.Interface;

namespace NASARoverMovement.Test
{
    [TestClass]
    public class RoverMovement
    {
        [TestMethod]
        public void All_Robotic_rover_move_inmars_plateau()
        {
            IMatrix plateau = new MarsPlateau(5, 5);
            IPosition positionfirst = new RoboticPosition(1, 2);
            IPosition positionsecond = new RoboticPosition(3, 3);
            var roboticRoverFirst = new RoboticRover(positionfirst, Direction.N, plateau);
            var roboticRoverSecond = new RoboticRover(positionsecond, Direction.E, plateau);

            roboticRoverFirst.Move("LMLMLMLMM");

            var control = new MovementControl<IRover, IMatrix>(roboticRoverFirst, plateau).RoverInMatrix();

            Assert.IsTrue(control);
            Assert.IsTrue(roboticRoverFirst.Position.X == 1, "First Position X is not true!");
            Assert.IsTrue(roboticRoverFirst.Position.Y == 3, "First Position Y is not true!");
            Assert.IsTrue(roboticRoverFirst.Direction == Direction.N, "First Direction is wrong!");

            roboticRoverSecond.Move("MMRMMRMRRM");
            control = new MovementControl<IRover, IMatrix>(roboticRoverSecond, plateau).RoverInMatrix();

            Assert.IsTrue(control);
            Assert.IsTrue(roboticRoverSecond.Position.X == 5, "Second Position X is not true!");
            Assert.IsTrue(roboticRoverSecond.Position.Y == 1, "Second Position Y is not true!");
            Assert.IsTrue(roboticRoverSecond.Direction == Direction.E, "Second Direction is wrong!");
        }

        [TestMethod]
        public void First_Robotic_rover_move_inmars_plateau()
        {
            IMatrix plateau = new MarsPlateau(5, 5);
            IPosition position = new RoboticPosition(1, 2);

            var roboticRover = new RoboticRover(position, Direction.N, plateau);
            roboticRover.Move("LMLMLMLMM");

            var control = new MovementControl<IRover, IMatrix>(roboticRover, plateau).RoverInMatrix();

            Assert.IsTrue(control);
            Assert.IsTrue(roboticRover.Position.X == 1, "Position X is not true");
            Assert.IsTrue(roboticRover.Position.Y == 3, "Position Y is not true");
            Assert.IsTrue(roboticRover.Direction == Direction.N, "Direction is not true");
        }

        [TestMethod]
        public void Second_Robotic_rover_move_inmars_plateau()
        {
            IMatrix plateau = new MarsPlateau(5, 5);
            IPosition position = new RoboticPosition(3, 3);

            var roboticRover = new RoboticRover(position, Direction.E, plateau);

            roboticRover.Move("MMRMMRMRRM");
            var control = new MovementControl<IRover, IMatrix>(roboticRover, plateau).RoverInMatrix();

            Assert.IsTrue(control);
            Assert.IsTrue(roboticRover.Position.X == 5, "Position X is not true");
            Assert.IsTrue(roboticRover.Position.Y == 1, "Position Y is not true");
            Assert.IsTrue(roboticRover.Direction == Direction.E, "Direction is not true");
        }
    }
}
