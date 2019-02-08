using MarsRover;
using MarsRover.Data;
using MarsRover.Intefaces;
using MarsRover.Repositories;
using NUnit.Framework;
using System.Collections.Generic;

namespace MarsRoverTests
{
    [TestFixture]
    class RoverControlTests
    {
        IRoverControl roverControl = new RoverControl();

        public List<Direction> GetAvailableDirections()
        {
            List<Direction> listOfDirections = new List<Direction>();
            listOfDirections.Add(new Direction { Angle = 0, Name = "East" });
            listOfDirections.Add(new Direction { Angle = 90, Name = "North" });
            listOfDirections.Add(new Direction { Angle = 180, Name = "West" });
            listOfDirections.Add(new Direction { Angle = 270, Name = "South" });

            return listOfDirections;
        }        

        [Test]
        public void GetPosition_ReturnsAStringValue1South_WhenPassedEmptyListOfCommandsFromDefaultStartingPosition()
        {
            // Arrange
            string expected = "1 South";
            CurrentPosition position = new CurrentPosition(){ XCoordinate = 0.5, YCoordinate = 0.5, Angle = 270 };
            List<Direction> listOfAvailableDirections = GetAvailableDirections();
            List<Command> commands = new List<Command>();            

            // Act
            string actual = roverControl.GetPosition(commands, position, listOfAvailableDirections);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetPosition_ReturnsAStringValue2South_WhenPassedEmptyListOfCommandsAndStartingPositionIsNotDefault()
        {
            // Arrange
            string expected = "2 South";
            CurrentPosition position = new CurrentPosition() { XCoordinate = 1.5, YCoordinate = 0.5, Angle = 270 };
            List<Direction> listOfAvailableDirections = GetAvailableDirections();
            List<Command> commands = new List<Command>();

            // Act
            string actual = roverControl.GetPosition(commands, position, listOfAvailableDirections);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetPosition_ReturnsAStringValue3South_WhenPassedACommandWithDistanceValue2AndDirectionValue0FromDefaultStartingPosition()
        {
            // Arrange
            string expected = "201 South";
            CurrentPosition position = new CurrentPosition() { XCoordinate = 0.5, YCoordinate = 0.5, Angle = 270 };
            List<Direction> listOfAvailableDirections = GetAvailableDirections();
            List<Command> commands = new List<Command>() 
            {
                new Command{ Distance = 2, Direction = 0 }
            };

            // Act
            string actual = roverControl.GetPosition(commands, position, listOfAvailableDirections);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetPosition_ReturnsAStringValue4624North_WhenPassedCommandsWithDistanceValue2AndDirectionValue0FromDefaultStartingPosition()
        {
            // Arrange
            string expected = "4624 North";
            CurrentPosition position = new CurrentPosition() { XCoordinate = 0.5, YCoordinate = 0.5, Angle = 270 };
            List<Direction> listOfAvailableDirections = GetAvailableDirections();
            List<Command> commands = new List<Command>() 
            {
                new Command{ Distance = 50, Direction = 0 },
                new Command{ Distance = 0, Direction = 90 },
                new Command{ Distance = 23, Direction = 0 },
                new Command{ Distance = 0, Direction = 90 },
                new Command{ Distance = 4, Direction = 0 }
            };

            // Act
            string actual = roverControl.GetPosition(commands, position, listOfAvailableDirections);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetPositionn_ReturnsAStringValue1And315Degrees_WhenPassedACommandWithDistanceValue0AndDirectionValue45FromDefaultStartingPosition()
        {
            // Arrange
            string expected = "1 315 Degrees";
            CurrentPosition position = new CurrentPosition() { XCoordinate = 0.5, YCoordinate = 0.5, Angle = 270 };
            List<Direction> listOfAvailableDirections = GetAvailableDirections();
            List<Command> commands = new List<Command>() 
            {
                new Command{ Distance = 0, Direction = 45 }
            };

            // Act
            string actual = roverControl.GetPosition(commands, position, listOfAvailableDirections);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetPosition_ReturnsAStringContainingAnErrorMessage_WhenPassedCommandsWhichLeadRoverOutsidePermittedAreaFromDefaultStartingPosition()
        {
            // Arrange
            string expected = "Cannot move outside perimeter. Rover stopped at 1 West";
            CurrentPosition position = new CurrentPosition() { XCoordinate = 0.5, YCoordinate = 0.5, Angle = 270 };
            List<Direction> listOfAvailableDirections = GetAvailableDirections();
            List<Command> commands = new List<Command>() 
            {
                new Command{ Distance = 0, Direction = -90 },
                new Command{ Distance = 2, Direction = 0 }
            };

            // Act
            string actual = roverControl.GetPosition(commands, position, listOfAvailableDirections);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetPosition_ReturnsAStringContainingAnErrorMessage_WhenPassed5CommandsWhichLeadRoverOutsidePermittedAreaFromDefaultStartingPosition()
        {
            // Arrange
            string expected = "Cannot move outside perimeter. Rover stopped at 26 North";
            CurrentPosition position = new CurrentPosition() { XCoordinate = 0.5, YCoordinate = 0.5, Angle = 270 };
            List<Direction> listOfAvailableDirections = GetAvailableDirections();
            List<Command> commands = new List<Command>() 
            {
                new Command{ Distance = 50, Direction = 0 },
                new Command{ Distance = 0, Direction = 90 },
                new Command{ Distance = 25, Direction = 0 },
                new Command{ Distance = 0, Direction = 90 },
                new Command{ Distance = 100, Direction = 0 }
            };

            // Act
            string actual = roverControl.GetPosition(commands, position, listOfAvailableDirections);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ComputeRoverMovement_CurrentPositionYCoordinateValueChangesTo2point5_WhenPassedACommandWithDistanceValue2AndDirectionValue0FromDefaultStartingPosition()
        {
            // Arrange
            double expectedXCoordinate = 0.5;
            double expectedYCoordinate = 2.5;
            CurrentPosition position = new CurrentPosition() 
            { 
                XCoordinate = 0.5, 
                YCoordinate = 0.5, 
                Angle = 270 
            };
            List<Command> commands = new List<Command>() 
            {
                new Command{ Distance = 2, Direction = 0 }
            };

            // Act
            roverControl.ComputeRoverMovement(commands, position);
            double actualXCoordinate = position.XCoordinate;
            double actualYCoordinate = position.YCoordinate;

            // Assert
            Assert.AreEqual(expectedXCoordinate, actualXCoordinate);
            Assert.AreEqual(expectedYCoordinate, actualYCoordinate);
        }

        [Test]
        public void ComputeRoverMovement_CurrentPositionYCoordinateValueChangesTo2point5AndXCoordinateValueChangesTo1point5_WhenPassed3CommandsWithInstructionsDistance2Direction0ThenDistance0Direction90ThenDistance1Direction0FromDefaultStartingPosition()
        {
            // Arrange
            double expectedXCoordinate = 1.5;
            double expectedYCoordinate = 2.5;
            double expectedAngle = 0;
            CurrentPosition position = new CurrentPosition() 
            { 
                XCoordinate = 0.5, 
                YCoordinate = 0.5, 
                Angle = 270 
            };
            List<Command> commands = new List<Command>() 
            {
                new Command{ Distance = 2, Direction = 0 },
                new Command{ Distance = 0, Direction = 90 },
                new Command{ Distance = 1, Direction = 0 },
            };

            // Act
            roverControl.ComputeRoverMovement(commands, position);
            double actualXCoordinate = position.XCoordinate;
            double actualYCoordinate = position.YCoordinate;
            double actualAngle = position.Angle;

            // Assert
            Assert.AreEqual(expectedXCoordinate, actualXCoordinate);
            Assert.AreEqual(expectedYCoordinate, actualYCoordinate);
            Assert.AreEqual(expectedAngle, actualAngle);
        }

        [Test]
        public void ExecuteCommandsDecision_ReturnsACommandStatesValueCompleted_WhenPassed3ValidCommandssFromDefaultStartingPosition()
        {
            // Arrange
            CommandStates expected = CommandStates.Completed;
            CurrentPosition position = new CurrentPosition()
            {
                XCoordinate = 0.5,
                YCoordinate = 0.5,
                Angle = 270
            };
            List<Command> commands = new List<Command>() 
            {
                new Command{ Distance = 2, Direction = 0 },
                new Command{ Distance = 0, Direction = 90 },
                new Command{ Distance = 1, Direction = 0 },
            };

            // Act
            CommandStates actual = roverControl.ExecuteCommandsDecision(commands, position);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ExecuteCommandsDecision_ReturnsACommandStatesValueStopped_WhenPassed1InvalidCommandFromDefaultStartingPosition()
        {
            // Arrange
            CommandStates expected = CommandStates.Stopped;
            CurrentPosition position = new CurrentPosition()
            {
                XCoordinate = 0.5,
                YCoordinate = 0.5,
                Angle = 270
            };
            List<Command> commands = new List<Command>() 
            {
                new Command{ Distance = 200, Direction = 0 }
            };

            // Act
            CommandStates actual = roverControl.ExecuteCommandsDecision(commands, position);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ExecuteCommandsDecision_ReturnsACommandStatesValueStopped_WhenPassed1ValidAnd1InvalidCommandFromDefaultStartingPosition()
        {
            // Arrange
            CommandStates expected = CommandStates.Stopped;
            CurrentPosition position = new CurrentPosition()
            {
                XCoordinate = 0.5,
                YCoordinate = 0.5,
                Angle = 270
            };
            List<Command> commands = new List<Command>() 
            {
                new Command{ Distance = 2, Direction = 0 },
                new Command{ Distance = 200, Direction = 0 }
            };

            // Act
            CommandStates actual = roverControl.ExecuteCommandsDecision(commands, position);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
