using MarsRover.Data;
using MarsRover.Intefaces;
using MarsRover.Repositories;
using NUnit.Framework;

namespace MarsRoverTests
{
    [TestFixture]
    class AngleNormalisationTests
    {
        IAngleNormalisation angle = new AngleNormalisation();

        [Test]
        public void NormaliseAngle_SetsCurrentPositionAngleValueTo180_WhenPassedCurrentPositionWithAngleValue180()
        {
            // Arrange
            double expected = 180;
            CurrentPosition position = new CurrentPosition() { Angle = 180 };

            // Act
            angle.NormaliseAngle(position);
            double actual = position.Angle; 

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void NormaliseAngle_SetsCurrentPositionAngleValueTo270_WhenPassedACurrentPositionWithAngleValueMinus90()
        {
            // Arrange
            double expected = 270;
            CurrentPosition position = new CurrentPosition() { Angle = -90 };

            // Act
            angle.NormaliseAngle(position);
            double actual = position.Angle;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void NormaliseAngle_SetsCurrentPositionAngleValueTo0_WhenPassedCurrentPositionWithAngleValue360()
        {
            // Arrange
            double expected = 0;
            CurrentPosition position = new CurrentPosition() { Angle = 360 };

            // Act
            angle.NormaliseAngle(position);
            double actual = position.Angle;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void NormaliseAngle_SetsCurrentPositionAngleValueTo0_WhenPassedCurrentPositionWithAngleValue0()
        {
            // Arrange
            double expected = 0;
            CurrentPosition position = new CurrentPosition() { Angle = 0 };

            // Act
            angle.NormaliseAngle(position);
            double actual = position.Angle;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void NormaliseAngle_SetsCurrentPositionAngleValueTo45_WhenPassedCurrentPositionWithAngleValue405()
        {
            // Arrange
            double expected = 45;
            CurrentPosition position = new CurrentPosition() { Angle = 405 };

            // Act
            angle.NormaliseAngle(position);
            double actual = position.Angle;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void NormaliseAngle_SetsCurrentPositionAngleValueTo5_WhenPassedCurrentPositionWithAngleValue725()
        {
            // Arrange
            double expected = 5;
            CurrentPosition position = new CurrentPosition() { Angle = 725 };

            // Act
            angle.NormaliseAngle(position);
            double actual = position.Angle;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void NormaliseAngle_SetsCurrentPositionAngleValueTo355_WhenPassedCurrentPositionWithAngleValueMinus725()
        {
            // Arrange
            double expected = 355;
            CurrentPosition position = new CurrentPosition() { Angle = -725 };

            // Act
            angle.NormaliseAngle(position);
            double actual = position.Angle;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
