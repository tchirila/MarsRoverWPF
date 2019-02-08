using MarsRover.Data;
using MarsRover.Intefaces;
using MarsRover.Repositories;
using NUnit.Framework;

namespace MarsRoverTests
{
    [TestFixture]
    class PositionUpdaterTests
    {
        IPositionUpdater updater = new PositionUpdater();

        [Test]
        public void SetValidPosition_ReturnsBoolValueTrue_WhenPassedCurrentPositionWithXCoordinateValue0Point5YCoordinate0Point5AngleValue270()
        {
            // Arrange
            bool expected = true;
            CurrentPosition position = new CurrentPosition() 
            { 
                XCoordinate = 0.5, 
                YCoordinate = 0.5, 
                Angle = 270 
            };

            // Act
            bool actual = updater.SetValidPosition(position);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SetValidPosition_ReturnsBoolValueFalse_WhenPassedCurrentPositionWithXCoordinateValueMinus5YCoordinate1AngleValue270()
        {
            // Arrange
            bool expected = false;
            CurrentPosition position = new CurrentPosition()
            {
                XCoordinate = -5,
                YCoordinate = 1,
                Angle = 270
            };

            // Act
            bool actual = updater.SetValidPosition(position);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SetValidPosition_ReturnsBoolValueFalse_WhenPassedCurrentPositionWithXCoordinateValue120YCoordinate1AngleValue270()
        {
            // Arrange
            bool expected = false;
            CurrentPosition position = new CurrentPosition()
            {
                XCoordinate = 120,
                YCoordinate = 1,
                Angle = 270
            };

            // Act
            bool actual = updater.SetValidPosition(position);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SetValidPosition_ReturnsBoolValueFalse_WhenPassedCurrentPositionWithXCoordinateValue1YCoordinateMinus5AngleValue270()
        {
            // Arrange
            bool expected = false;
            CurrentPosition position = new CurrentPosition()
            {
                XCoordinate = 1,
                YCoordinate = -5,
                Angle = 270
            };

            // Act
            bool actual = updater.SetValidPosition(position);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SetValidPosition_ReturnsBoolValueFalse_WhenPassedCurrentPositionWithXCoordinateValue1YCoordinate120AngleValue270()
        {
            // Arrange
            bool expected = false;
            CurrentPosition position = new CurrentPosition()
            {
                XCoordinate = 1,
                YCoordinate = 120,
                Angle = 270
            };

            // Act
            bool actual = updater.SetValidPosition(position);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SetValidPosition_ReturnsBoolValueTrue_WhenPassedCurrentPositionWithXCoordinateValue0Point5YCoordinate0Point5AngleValue623()
        {
            // Arrange
            bool expected = true;
            CurrentPosition position = new CurrentPosition()
            {
                XCoordinate = 0.5,
                YCoordinate = 0.5,
                Angle = 623
            };

            // Act
            bool actual = updater.SetValidPosition(position);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
