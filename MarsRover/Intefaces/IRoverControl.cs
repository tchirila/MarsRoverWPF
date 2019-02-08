using MarsRover.Data;
using System.Collections.Generic;

namespace MarsRover.Intefaces
{
    public interface IRoverControl
    {
        string GetPosition(List<Command> commands, CurrentPosition position, List<Direction> listOfAvailableDirections);
        CommandStates ComputeRoverMovement(List<Command> commands, CurrentPosition position);
        CommandStates ExecuteCommandsDecision(List<Command> commands, CurrentPosition position);        
    }
}
