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
    public class ReportingController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        private readonly parking_lotContext _context;

        public ReportingController(parking_lotContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

       

        private bool LotNameExists(string name)
        {
            return _context.ParkingLots.Any(e => e.Name == name);
        }
    }
}
