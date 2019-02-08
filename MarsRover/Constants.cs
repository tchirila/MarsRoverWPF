using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public enum CommandStates { Completed, Stopped, Illegal };

    internal static class Constants
    {
        public const double NOCOORDCORRECTION = 0;
        public const double COORDCORRECTION = 0.1;
        public const double FULLROTATION = 360;
        public const int MAXCOMMANDS = 5;
        public const int MINCOMMANDS = 1;
        public const double MINCOORD = 0;
        public const double COORDOVERLIMIT = 100;
    }
}
