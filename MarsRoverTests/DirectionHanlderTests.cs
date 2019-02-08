using MarsRover.Data;
using MarsRover.Intefaces;
using MarsRover.Repositories;
using NUnit.Framework;
using System.Collections.Generic;

namespace MarsRoverTests
{
    [TestFixture]
    class DirectionHanlderTests
    {
        IDirectionHandler directionHandler = new DirectionHandler();

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
        public void GetDirection_ReturnsAStringValueSouth_WhenPassedListOfDirectionsObjectAndAngleValue270PresentInListOfDirectionsObject()
        {
            // Arrange
            string expected = "South";
            double angle = 270;
            List<Direction> listOfAvailableDirections = GetAvailableDirections();

            // Act
            string actual = directionHandler.GetDirection(angle, listOfAvailableDirections);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetDirection_ReturnsAStringValue45Degrees_WhenPassedListOfDirectionsObjectAndAngleValue45NotPresentInListOfDirectionsObject()
        {
            // Arrange
            string expected = "45 Degrees";
            double angle = 45;
            List<Direction> listOfAvailableDirections = GetAvailableDirections();

            // Act
            string actual = directionHandler.GetDirection(angle, listOfAvailableDirections);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SelectDirection_ReturnsADirectionObjectWithAngleValue270_WhenPassedListOfDirectionsObjectAndAngleValue270PresentInListOfDirectionsObject()
        {
            // Arrange
            Direction expected = new Direction() { Angle = 270 };
            double angle = 270;
            List<Direction> listOfAvailableDirections = GetAvailableDirections();

            // Act
            Direction actual = directionHandler.SelectDirection(angle, listOfAvailableDirections);

            // Assert
            Assert.AreEqual(expected.Angle, actual.Angle);
        }

        [Test]
        public void SelectDirection_ReturnsANullDirectionOject_WhenPassedListOfDirectionsObjectAndAngleValue45NotPresentInListOfDirectionsObject()
        {
            // Arrange
            Direction expected = null;
            double angle = 45;
            List<Direction> listOfAvailableDirections = GetAvailableDirections();

            // Act
            Direction actual = directionHandler.SelectDirection(angle, listOfAvailableDirections);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SetOutput_ReturnsAStringValueSouth_WhenPassedDirectionObjectWithNameValueSouthAndADoubleValue270()
        {
            // Arrange
            string expected = "South";
            Direction direction = new Direction() { Name = "South" };
            double angle = 270;

            // Act
            string actual = directionHandler.SetOutput(direction, angle);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SetOutput_ReturnsAStringValue45Degrees_WhenPassedNullDirectionObjectAndADoubleValue45()
        {
            // Arrange
            string expected = "45 Degrees";
            Direction direction = null;
            double angle = 45;

            // Act
            string actual = directionHandler.SetOutput(direction, angle);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
