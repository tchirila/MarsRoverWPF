using MarsRover.Data;
using MarsRover.Intefaces;
using System;

namespace MarsRover.Repositories
{
    public class AngleNormalisation : IAngleNormalisation
    {
        public void NormaliseAngle(CurrentPosition position)
        {
            if (position.Angle >= Constants.FULLROTATION)
            {
                position.Angle -= Constants.FULLROTATION 
                         * Math.Truncate(position.Angle / Constants.FULLROTATION);
            }
            else if (position.Angle < 0)
            {
                position.Angle += Constants.FULLROTATION
                         * Math.Ceiling(position.Angle / -Constants.FULLROTATION);
            }
        }       
    }
}
