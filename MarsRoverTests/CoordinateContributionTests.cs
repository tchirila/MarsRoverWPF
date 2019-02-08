using MarsRover.Data;
using MarsRover.Intefaces;
using MarsRover.Repositories;
using NUnit.Framework;

namespace MarsRoverTests
{
    [TestFixture]
    class CoordinateContributionTests
    {
        ICoordinateContribution contribution = new CoordinateContribution();

        [Test]
        public void CalculateXContribution_ReturnsADoubleValue1_WhenPassedCurrentPositionWithXCoordinateValue0Point5()
        {
            // Arrange
            double expected = 1;
            CurrentPosition position = new CurrentPosition() { XCoordinate = 0.5 };

            // Act
            double actual = contribution.CalculateXContribution(position);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CalculateXContribution_ReturnsADoubleValue1_WhenPassedCurrentPositionWithXCoordinateValue0()
        {
            // Arrange
            double expected = 1;
            CurrentPosition position = new CurrentPosition() { XCoordinate = 0 };

            // Act
            double actual = contribution.CalculateXContribution(position);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CalculateXContribution_ReturnsADoubleValue100_WhenPassedCurrentPositionWithXCoordinateValue99Point9()
        {
            // Arrange
            double expected = 100;
            CurrentPosition position = new CurrentPosition() { XCoordinate = 99.9 };

            // Act
            double actual = contribution.CalculateXContribution(position);

            // Assert
            Assert.AreEqual(expected, actual);
        }        
        
        [Test]
        public void CalculateYContribution_ReturnsADoubleValue1_WhenPassedCurrentPositionWithYCoordinateValue0Point5()
        {
            // Arrange
            double expected = 0;
            CurrentPosition position = new CurrentPosition() { YCoordinate = 0.5 };

            // Act
            double actual = contribution.CalculateYContribution(position);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CalculateYContribution_ReturnsADoubleValue0_WhenPassedCurrentPositionWithYCoordinateValue0()
        {
            // Arrange
            double expected = 0;
            CurrentPosition position = new CurrentPosition() { YCoordinate = 0 };

            // Act
            double actual = contribution.CalculateYContribution(position);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CalculateYContribution_ReturnsADoubleValue9900_WhenPassedCurrentPositionWithYCoordinateValue99Point9()
        {
            // Arrange
            double expected = 9900;
            CurrentPosition position = new CurrentPosition() { YCoordinate = 99.9 };

            // Act
            double actual = contribution.CalculateYContribution(position);

            // Assert
            Assert.AreEqual(expected, actual);
        }        
    }
}
