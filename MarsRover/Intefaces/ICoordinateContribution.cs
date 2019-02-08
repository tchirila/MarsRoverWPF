using MarsRover.Data;

namespace MarsRover.Intefaces
{
    public interface ICoordinateContribution
    {
        double CalculateXContribution(CurrentPosition position);
        double CalculateYContribution(CurrentPosition position);
    }
}
