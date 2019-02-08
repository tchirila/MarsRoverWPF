using MarsRover.Data;
using MarsRover.Intefaces;
using System.Collections.Generic;
using System.Linq;

namespace MarsRover.Repositories
{
    public class DirectionHandler : IDirectionHandler
    {
        public string GetDirection(double angle, List<Direction> listOfAvailableDirections)
        {
            Direction direction = SelectDirection(angle, listOfAvailableDirections);
            return SetOutput(direction, angle);
        }

        public Direction SelectDirection(double angle, List<Direction> listOfAvailableDirections)
        {
            return listOfAvailableDirections.FirstOrDefault(x => x.Angle == angle);
        }
        
        public string SetOutput(Direction direction, double angle)
        {
            if (direction == null)
            {
                return (angle.ToString() + " Degrees");
            }
            else
            {
                return direction.Name;
            }
        }    
    }
}
