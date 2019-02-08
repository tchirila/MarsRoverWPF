using MarsRover.Data;
using System.Collections.Generic;

namespace MarsRover.Intefaces
{
    public interface ILocationHandler
    {
        string GetLocationNumberAsString(CurrentPosition curPos);
    }
}
