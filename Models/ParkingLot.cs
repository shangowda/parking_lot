using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace parking_lot.Models
{
    public partial class ParkingLot
    {
        public int Id { get; set; }

        [Required]
        [Remote(action: "IsLotNameExist", controller: "ParkingLot", ErrorMessage = "Lot name already exists")]        
        public string Name { get; set; }
    }
}
