using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using parking_lot.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using parking_lot.Data;

namespace parking_lot.Controllers
{
    public class HomeController : Controller
    {
             
        private readonly parking_lotContext _context;


        public HomeController(parking_lotContext context)
        {
            _context = context;
        }
       
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        /**
         * Detail view of every parking space
         */
        public async Task<IActionResult> ParkingSpace()
        {
            return View(await _context.ParkingSpaces.ToListAsync());
        }

        /**
         * Overview of vehicles parked by lot/vehicle type
         */
        public List<ParkingOverview> ParkingOverview()
        {
            List<ParkingOverview> po = _context.ParkingOverview.FromSqlRaw($"space_overview").ToList();
            return po;
        }

        /**
         * Overview of vehicles parked by lot/vehicle type
         */
        public IActionResult OverviewByVehicle()
        {            
            var overview = _context.OverviewByVehicle.FromSqlRaw($"overview_by_vehicle").ToList();
            return View(overview);
        }

        /**
 * Total sopts ramianing ex:motorcycle=10,car=5,large=5
 */
        [HttpGet]
        public int SpotsRemainingBySpaceType(string type)        {
            
            var po = _context.ParkingOverview.FromSqlRaw($"space_overview");
            var count = 0;
            type = IsNullOrEmpty(type) ? "car" : type;
            foreach (var item in po)
            {
                if (item.SpaceType == type)
                    count+=item.Open;
            }
            return count;
        }


        /**
         * Type of open space available in each category EX: motorcycle = 10,car = 5, van=1
         */
        public IActionResult SpaceAvailable()
        {
            return View();
        }

        /**
         * Method which counts all the empty spaces and returns 0 if parking lot is not full and 1 if it is full
         */
        [HttpGet]
        public bool IsFull()
        {
            var po = _context.ParkingSpaces.ToList();
            foreach(var item in po)
            {
                if (item.IsFull > 0)
                    return false;
            }
            return true;
        }


        private bool IsNullOrEmpty(string type)
        {
            throw new NotImplementedException();
        }
        /**
         * Overview of vehicles parked by lot/vehicle type
         
        public IActionResult HowManyTotalSpots()
        {
            //return _context.ParkingSpaces.FromSqlRaw("SELECT Count(id) FROM Dbo.parking_space");
        }
        */
    }
}
