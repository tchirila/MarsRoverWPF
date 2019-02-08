using MarsRover;
using MarsRover.Data;
using MarsRover.Intefaces;
using MarsRover.Repositories;
using NUnit.Framework;
using System.Collections.Generic;

namespace MarsRoverTests
{
    [TestFixture]
    class PositionOutputTests
    {
        IPositionOutput positionOutput = new PositionOutput();

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
        public void GetPositionOutput_ReturnsAStringValue1South_WhenPassedCurrentPositionObjectWithXCoordinateValue0Point5AndYCoordinateValue0Point5AndAngleValue270ListOfDirectionsObjectAndACommandStateValueCompleted()
        {
            // Arrange
            string expected = "1 South";
            CurrentPosition position = new CurrentPosition() 
            { 
                XCoordinate = 0.5,
                YCoordinate = 0.5,
                Angle = 270
            };

            CommandStates commandState = CommandStates.Completed;
            List<Direction> listOfAvailableDirections = GetAvailableDirections();

            // Act
            string actual = positionOutput.GetPositionOutput(position, listOfAvailableDirections, commandState);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetPositionOutput_ReturnsAStringValueCannotMoveOutsidePerimeterRoverStoppedAt1North_WhenPassedCurrentPositionObjectWithXCoordinateValue0Point5AndYCoordinateValue0Point1AndAngleValue90ListOfDirectionsObjectAndACommandStateValueStopped()
        {
            // Arrange
            string expected = "Cannot move outside perimeter. Rover stopped at 1 North";
            CurrentPosition position = new CurrentPosition()
            {
                XCoordinate = 0.5,
                YCoordinate = 0.1,
                Angle = 90
            };

            CommandStates commandState = CommandStates.Stopped;
            List<Direction> listOfAvailableDirections = GetAvailableDirections();

            // Act
            string actual = positionOutput.GetPositionOutput(position, listOfAvailableDirections, commandState);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
