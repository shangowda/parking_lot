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
        //private readonly ILogger<HomeController> _logger;
        
        private readonly parking_lotContext _context;

        public HomeController(parking_lotContext context)
        {
            _context = context;
        }
       
        /**
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        **/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        /**
         * Detail view of parking space
         */
        public IActionResult ParkingSpace()
        {
            return View();
        }

        /**
         * Overview of vehicles parked by lot/vehicle type
         */
        public IActionResult ParkingOverview()
        {
            var spaceOverview = _context.ParkingOverview.FromSqlRaw($"space_overview").ToList();
            return View(spaceOverview);
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
         * Total sopts ramianing ex:motorcycle=10,car=5,van=5
         */
        public IActionResult SpotsRemaining()
        {
            return View();
        }

        /**
         * Type of open space available in each category EX: motorcycle = 10,car = 5, van=1
         */
        public IActionResult SpaceAvailable()
        {
            return View();
        }


        public IActionResult IsFull()
        {
            return View();
        }
    }
}
