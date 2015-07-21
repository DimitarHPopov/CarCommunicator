using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarCommunicator.Common.ServiceData
{
    public class CarInfo
    {
        public int Id { get; set; }
        public string Owner { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Information { get; set; }
        public Position LastKnownPosition { get; set; }
    }
}
