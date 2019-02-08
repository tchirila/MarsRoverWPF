using MarsRover.Data;
using MarsRover.Intefaces;
using System;

namespace MarsRover.Repositories
{
    public class CoordinateContribution : ICoordinateContribution
    {
        ICoordinateCorrection correction = new CoordinateCorrection();
        
        public double CalculateXContribution(CurrentPosition position)
        {
            double xCorrection = correction.CalculateXCoordinateCorrection(position);
            return Math.Ceiling(position.XCoordinate + xCorrection);
        }
        
        public double CalculateYContribution(CurrentPosition position)
        {
            double yCorrection = correction.CalculateYCoordinateCorrection(position);
            double yValue = Math.Ceiling(position.YCoordinate + yCorrection);
            return 100 * (yValue - 1);
        }
    }
}
