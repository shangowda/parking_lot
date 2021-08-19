using System;
using System.Collections.Generic;

#nullable disable

namespace parking_lot.Models
{
    public partial class Vehicle
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
    }
}
