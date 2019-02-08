using MarsRover.Data;
using MarsRover.Intefaces;

namespace MarsRover.Repositories
{
    public class PositionUpdater : IPositionUpdater
    {
        IAngleNormalisation angle = new AngleNormalisation();

        public bool SetValidPosition(CurrentPosition position)
        {
            if (position.XCoordinate >= Constants.MINCOORD
                && position.XCoordinate < Constants.COORDOVERLIMIT
                && position.YCoordinate >= Constants.MINCOORD
                && position.YCoordinate < Constants.COORDOVERLIMIT)
            {
                angle.NormaliseAngle(position);
                return true;
            }
            else
            {
                if (position.XCoordinate < Constants.MINCOORD)
                {
                    position.XCoordinate = Constants.MINCOORD;
                }

                if (position.XCoordinate >= Constants.COORDOVERLIMIT)
                {
                    position.XCoordinate = Constants.COORDOVERLIMIT - Constants.COORDCORRECTION;
                }

                if (position.YCoordinate < Constants.MINCOORD)
                {
                    position.YCoordinate = Constants.MINCOORD;
                }

                if (position.YCoordinate >= Constants.COORDOVERLIMIT)
                {
                    position.YCoordinate = Constants.COORDOVERLIMIT - Constants.COORDCORRECTION;
                }

                angle.NormaliseAngle(position);
                return false;
            }
        }
    }
}
