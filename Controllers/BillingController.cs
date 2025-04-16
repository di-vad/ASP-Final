using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vehicleManagementSystem.Data;

namespace vehicleManagementSystem.Controllers
{
    public class BillingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BillingController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var bills = _context.Billings
                .Include(b => b.Reservation)
                .ThenInclude(r => r.Customer)
                .Include(b => b.Reservation.Vehicle);

            return View(await bills.ToListAsync());
        }

        public async Task<IActionResult> Details(int id)
        {
            var billing = await _context.Billings
                .Include(b => b.Reservation)
                .ThenInclude(r => r.Customer)
                .Include(b => b.Reservation.Vehicle)
                .FirstOrDefaultAsync(b => b.Id == id);

            return billing == null ? NotFound() : View(billing);
        }
    }
}
