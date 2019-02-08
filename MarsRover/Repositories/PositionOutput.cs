using MarsRover.Data;
using MarsRover.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Repositories
{
    public class PositionOutput : IPositionOutput
    {
        IDirectionHandler directionHandler = new DirectionHandler();
        ILocationHandler locationHandler = new LocationHandler();

        public string GetPositionOutput(CurrentPosition position, List<Direction> listOfAvailableDirections, CommandStates commandState)
        {
            string finalLocation = locationHandler.GetLocationNumberAsString(position);
            string finalDirection = directionHandler.GetDirection(position.Angle, listOfAvailableDirections);

            if (commandState == CommandStates.Stopped)
            {
                string warning = "Cannot move outside perimeter. Rover stopped at ";
                return warning + finalLocation + " " + finalDirection;
            }

            return finalLocation + " " + finalDirection;
        }  
    }
}
