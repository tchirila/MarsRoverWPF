using MarsRover.Data;

namespace MarsRover.Intefaces
{
    public interface ICoordinateCorrection
    {
        double CalculateXCoordinateCorrection(CurrentPosition position);
        double CalculateYCoordinateCorrection(CurrentPosition position);
        double CalculateCoordinateCorrection(double difference);
        double CalculateRoundingDifference(double number);
    }
}
