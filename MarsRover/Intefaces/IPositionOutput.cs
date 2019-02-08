using MarsRover.Data;
using System.Collections.Generic;

namespace MarsRover.Intefaces
{
    public interface IPositionOutput
    {
        string GetPositionOutput(CurrentPosition position, List<Direction> listOfAvailableDirections, CommandStates commandState);
    }
}
