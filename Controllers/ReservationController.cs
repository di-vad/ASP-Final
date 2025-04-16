using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using vehicleManagementSystem.Data;
using vehicleManagementSystem.Models;

namespace vehicleManagementSystem.Controllers
{
    public class ReservationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReservationController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var reservations = _context.Reservations
                .Include(r => r.Vehicle)
                .Include(r => r.Customer);
            return View(await reservations.ToListAsync());
        }

        public IActionResult Create()
        {
            ViewBag.Vehicles = new SelectList(_context.Vehicles.Where(v => v.IsAvailable), "Id", "Model");
            ViewBag.Customers = new SelectList(_context.Customers, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Reservation reservation)
        {
            _context.Reservations.Add(reservation);

            // Mark vehicle as unavailable
            var vehicle = await _context.Vehicles.FindAsync(reservation.VehicleId);
            if (vehicle != null) vehicle.IsAvailable = false;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var reservation = await _context.Reservations.FindAsync(id);
            if (reservation == null) return NotFound();

            ViewBag.Vehicles = new SelectList(_context.Vehicles, "Id", "Model", reservation.VehicleId);
            ViewBag.Customers = new SelectList(_context.Customers, "Id", "Name", reservation.CustomerId);
            return View(reservation);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Reservation reservation)
        {
            if (id != reservation.Id) return NotFound();
            _context.Update(reservation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var reservation = await _context.Reservations
                .Include(r => r.Vehicle)
                .Include(r => r.Customer)
                .FirstOrDefaultAsync(r => r.Id == id);
            return reservation == null ? NotFound() : View(reservation);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reservation = await _context.Reservations.FindAsync(id);
            if (reservation != null)
            {
                var vehicle = await _context.Vehicles.FindAsync(reservation.VehicleId);
                if (vehicle != null) vehicle.IsAvailable = true;

                _context.Reservations.Remove(reservation);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
