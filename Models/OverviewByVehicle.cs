using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace parking_lot.Models
{
    public class OverviewByVehicle
    {
        public string LotName { get; set; }
        public int MotorCycle { get; set; }
        public int Car { get; set; }
        public int Van { get; set; }
    }
}
