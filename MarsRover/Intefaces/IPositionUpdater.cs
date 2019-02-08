using MarsRover.Data;

namespace MarsRover.Intefaces
{
    public interface IPositionUpdater
    {
        bool SetValidPosition(CurrentPosition position);
    }
}
