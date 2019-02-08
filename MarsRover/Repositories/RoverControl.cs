using MarsRover.Data;
using MarsRover.Intefaces;
using System;
using System.Collections.Generic;

namespace MarsRover.Repositories
{
    public class RoverControl : IRoverControl
    {
        IPositionOutput positionOutput = new PositionOutput();
        IPositionUpdater positionUpdater = new PositionUpdater();

        public string GetPosition(List<Command> commands, CurrentPosition position, List<Direction> listOfAvailableDirections)
        {
            CommandStates commandState = ExecuteCommandsDecision(commands, position);
            return positionOutput.GetPositionOutput(position, listOfAvailableDirections, commandState);
        }

        public CommandStates ExecuteCommandsDecision(List<Command> commands, CurrentPosition position)
        {
            if (commands.Count >= Constants.MINCOMMANDS && commands.Count <= Constants.MAXCOMMANDS)
            {
                return ComputeRoverMovement(commands, position);
            }

            return CommandStates.Illegal;
        }

        public CommandStates ComputeRoverMovement(List<Command> commands, CurrentPosition position)
        {
            for (int i = 0; i < commands.Count; i++)
            {
                position.Angle += commands[i].Direction;
                double xMultiplier = Math.Round(Math.Cos(position.Angle * (Math.PI / 180.0)), 3);
                double yMultiplier = Math.Round(-Math.Sin(position.Angle * (Math.PI / 180.0)), 3);
                position.XCoordinate += commands[i].Distance * xMultiplier;
                position.YCoordinate += commands[i].Distance * yMultiplier;
                bool isPositionValid = positionUpdater.SetValidPosition(position);

                if (!isPositionValid)
                {
                    return CommandStates.Stopped;
                }
            }

            return CommandStates.Completed;
        }
    }
}