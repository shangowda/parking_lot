using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace parking_lot.Models
{
    public class ParkingOverview
    {
       
        public string LotName { get; set; }
        public string SpaceType { get; set; }
        public int Total { get; set; }
        public int Taken { get; set; }
        public int Open { get; set; }
    }
}
