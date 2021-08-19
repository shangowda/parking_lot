using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using parking_lot.Data;
using parking_lot.Models;

namespace parking_lot.Controllers
{
    public class ParkingLotsController : Controller
    {
        private readonly parking_lotContext _context;

        public ParkingLotsController(parking_lotContext context)
        {
            _context = context;
        }

        // GET: ParkingLots
        public async Task<IActionResult> Index()
        {
            return View(await _context.ParkingLots.ToListAsync());
        }

        // GET: ParkingLots/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkingLot = await _context.ParkingLots
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parkingLot == null)
            {
                return NotFound();
            }

            return View(parkingLot);
        }

        // GET: ParkingLots/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ParkingLots/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] ParkingLot parkingLot)
        {
            if (LotNameExists(parkingLot.Name) == true)
            {
                ModelState.AddModelError("Name", "Lot name already exists");
            }
            if (ModelState.IsValid)
            {
                _context.Add(parkingLot);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(parkingLot);
        }

        // GET: ParkingLots/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkingLot = await _context.ParkingLots.FindAsync(id);
            if (parkingLot == null)
            {
                return NotFound();
            }
            return View(parkingLot);
        }

        // POST: ParkingLots/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] ParkingLot parkingLot)
        {
            if (id != parkingLot.Id)
            {
                return NotFound();
            }
            //Verify if parking lot name is unique
            if (LotNameExists(parkingLot.Name) == true)
            {
                ModelState.AddModelError("Name", "Lot name already exists");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parkingLot);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParkingLotExists(parkingLot.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(parkingLot);
        }

        // GET: ParkingLots/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkingLot = await _context.ParkingLots
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parkingLot == null)
            {
                return NotFound();
            }

            return View(parkingLot);
        }

        // POST: ParkingLots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var parkingLot = await _context.ParkingLots.FindAsync(id);
            _context.ParkingLots.Remove(parkingLot);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // Action method for client side validation of unique lot name
        [AcceptVerbs("Get", "Post")]
        public IActionResult IsLotNameExist(string name)
        {            
            if (LotNameExists(name) == true)
            {
                return Json($"A Lot named {name} already exists.");
            }

            return Json(true);
        }

        private bool ParkingLotExists(int id)
        {
            return _context.ParkingLots.Any(e => e.Id == id);
        }

        private bool LotNameExists(string name)
        {
            return _context.ParkingLots.Any(e => e.Name == name);
        }
    }
}
