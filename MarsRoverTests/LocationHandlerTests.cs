using MarsRover.Data;
using MarsRover.Intefaces;
using MarsRover.Repositories;
using NUnit.Framework;

namespace MarsRoverTests
{
    [TestFixture]
    class LocationHandlerTests
    {
        ILocationHandler locationHandler = new LocationHandler();

        [Test]
        public void GetLocationNumberAsString_ReturnsStringValue1_WhenPassedCurrentPositionWithXCoordinateValue0Point5AndYCoordinateValue0Point5()
        {
            // Arrange
            string expected = "1";
            CurrentPosition position = new CurrentPosition() { XCoordinate = 0.5, YCoordinate = 0.5 };

            // Act
            string actual = locationHandler.GetLocationNumberAsString(position);
            
            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetLocationNumberAsString_ReturnsStringValue100_WhenPassedCurrentPositionWithXCoordinateValue99Point9AndYCoordinateValue0Point5()
        {
            // Arrange
            string expected = "100";
            CurrentPosition position = new CurrentPosition() { XCoordinate = 99.9, YCoordinate = 0.5 };

            // Act
            string actual = locationHandler.GetLocationNumberAsString(position);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetLocationNumberAsString_ReturnsAStringValue101_WhenPassedCurrentPositionWithXCoordinateValue0point5AndYCoordinateValue1point5()
        {
            // Arrange
            string expected = "101";
            CurrentPosition curPosition = new CurrentPosition() { XCoordinate = 0.5, YCoordinate = 1.5 };

            // Act
            string actual = locationHandler.GetLocationNumberAsString(curPosition);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetLocationNumberAsString_ReturnsStringValue9901_WhenPassedCurrentPositionWithXCoordinateValue0Point5AndYCoordinateValue99Point9()
        {
            // Arrange
            string expected = "9901";
            CurrentPosition position = new CurrentPosition() { XCoordinate = 0.5, YCoordinate = 99.9 };

            // Act
            string actual = locationHandler.GetLocationNumberAsString(position);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetLocationNumberAsString_ReturnsStringValue10000_WhenPassedCurrentPositionWithXCoordinateValue99Point9AndYCoordinateValue99Point9()
        {
            // Arrange
            string expected = "10000";
            CurrentPosition position = new CurrentPosition() { XCoordinate = 99.9, YCoordinate = 99.9 };

            // Act
            string actual = locationHandler.GetLocationNumberAsString(position);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetLocationNumberAsString_ReturnsStringValue1_WhenPassedCurrentPositionWithXCoordinateValue0AndYCoordinateValue0()
        {
            // Arrange
            string expected = "1";
            CurrentPosition position = new CurrentPosition() { XCoordinate = 0, YCoordinate = 0 };

            // Act
            string actual = locationHandler.GetLocationNumberAsString(position);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
