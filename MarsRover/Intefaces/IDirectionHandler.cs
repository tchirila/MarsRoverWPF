using MarsRover.Data;
using System.Collections.Generic;

namespace MarsRover.Intefaces
{
    public interface IDirectionHandler
    {
        string GetDirection(double angle, List<Direction> listOfAvailableDirections);
        Direction SelectDirection(double angle, List<Direction> listOfAvailableDirections);
        string SetOutput(Direction direction, double angle);
    }
}
