using System;
using System.Collections.Generic;

#nullable disable

namespace parking_lot.Models
{
    public partial class ParkingSpace
    {
        public int Id { get; set; }
        public int? Lot { get; set; }
        public int? SpaceType { get; set; }
        public int? RightSpace { get; set; }
        public int? LeftSpace { get; set; }
        public int? IsFull { get; set; }
        public int? Vehicle { get; set; }
    }
}
