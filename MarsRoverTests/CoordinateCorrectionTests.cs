using MarsRover.Data;
using MarsRover.Intefaces;
using MarsRover.Repositories;
using NUnit.Framework;

namespace MarsRoverTests
{
    [TestFixture]
    class CoordinateCorrectionTests
    {
        ICoordinateCorrection correction = new CoordinateCorrection();

        [Test]
        public void CalculateCoordinateCorrection_ReturnsADoubleValue0_WhenPassedADoubleValueMinus1()
        {
            // Arrange
            double expected = 0;
            double difference = -1;

            // Act
            double actual = correction.CalculateCoordinateCorrection(difference);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CalculateCoordinateCorrection_ReturnsADoubleValue0Point1_WhenPassedADoubleValue0()
        {
            // Arrange
            double expected = 0.1;
            double difference = 0;

            // Act
            double actual = correction.CalculateCoordinateCorrection(difference);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CalculateRoundingDifference_ReturnsADoubleValue0_WhenPassedADoubleValue1()
        {
            // Arrange
            double expected = 0;
            double number = 1;

            // Act
            double actual = correction.CalculateRoundingDifference(number);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CalculateRoundingDifference_ReturnsADoubleValueMinus0Point5_WhenPassedADoubleValue1Point5()
        {
            // Arrange
            double expected = -0.5;
            double number = 1.5;

            // Act
            double actual = correction.CalculateRoundingDifference(number);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CalculateXCoordinateCorrection_ReturnsADoubleValue0Point1_WhenPassedADoubleValue1()
        {
            // Arrange
            double expected = 0.1;
            CurrentPosition position = new CurrentPosition() { XCoordinate = 1 };

            // Act
            double actual = correction.CalculateXCoordinateCorrection(position);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CalculateXCoordinateCorrection_ReturnsADoubleValue0_WhenPassedADoubleValue0Point5()
        {
            // Arrange
            double expected = 0;
            CurrentPosition position = new CurrentPosition() { XCoordinate = 0.5 };

            // Act
            double actual = correction.CalculateXCoordinateCorrection(position);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CalculateYCoordinateCorrection_ReturnsADoubleValue0Point1_WhenPassedADoubleValue1()
        {
            // Arrange
            double expected = 0.1;
            CurrentPosition position = new CurrentPosition() { YCoordinate = 1 };

            // Act
            double actual = correction.CalculateYCoordinateCorrection(position);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CalculateYCoordinateCorrection_ReturnsADoubleValue0_WhenPassedADoubleValue0Point5()
        {
            // Arrange
            double expected = 0;
            CurrentPosition position = new CurrentPosition() { YCoordinate = 0.5 };

            // Act
            double actual = correction.CalculateYCoordinateCorrection(position);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
