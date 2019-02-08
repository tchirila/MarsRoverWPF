using MarsRover.Data;
using MarsRover.Intefaces;
using System;

namespace MarsRover.Repositories
{
    public class LocationHandler : ILocationHandler
    {
        ICoordinateContribution contribution = new CoordinateContribution();

        public string GetLocationNumberAsString(CurrentPosition position)
        {
            double xContribution = contribution.CalculateXContribution(position);
            double yContribution = contribution.CalculateYContribution(position);
            return (yContribution + xContribution).ToString();
        }      
    }
}
