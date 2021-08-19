using System;
using System.Collections.Generic;

#nullable disable

namespace parking_lot.Models
{
    public partial class ParkingLotSpaceType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Weight { get; set; }
    }
}
