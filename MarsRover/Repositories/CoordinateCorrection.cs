using MarsRover.Data;
using MarsRover.Intefaces;
using System;

namespace MarsRover.Repositories
{
    public class CoordinateCorrection : ICoordinateCorrection
    {        
        public double CalculateXCoordinateCorrection(CurrentPosition position)
        {
            double difference = CalculateRoundingDifference(position.XCoordinate);
            return CalculateCoordinateCorrection(difference);
        }
        
        public double CalculateYCoordinateCorrection(CurrentPosition position)
        {
            double difference = CalculateRoundingDifference(position.YCoordinate);
            return CalculateCoordinateCorrection(difference);
        }

        public double CalculateRoundingDifference(double number)
        {
            return number - Math.Ceiling(number);
        }
        
        public double CalculateCoordinateCorrection(double difference)
        {
            if (difference == 0)
            {
                return Constants.NOCOORDCORRECTION + Constants.COORDCORRECTION;
            }
            else
            {
                return Constants.NOCOORDCORRECTION;
            }
        }
    }
}
