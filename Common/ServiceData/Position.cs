using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarCommunicator.Common.ServiceData
{
    public class Position
    {
        public double Lat { get; set; }
        public double Lng { get; set; }
        public DateTime PositionTime { get; set; }
    }
}
