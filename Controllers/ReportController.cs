using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vehicleManagementSystem.Data;
using vehicleManagementSystem.Models;

namespace vehicleManagementSystem.Controllers
{
    public class ReportController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReportController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(ReportCriteria criteria)
        {
            var query = _context.Reservations
                .Include(r => r.Vehicle)
                .Include(r => r.Customer)
                .AsQueryable();

            if (criteria.StartDate.HasValue)
                query = query.Where(r => r.StartDate >= criteria.StartDate);

            if (criteria.EndDate.HasValue)
                query = query.Where(r => r.EndDate <= criteria.EndDate);

            if (!string.IsNullOrEmpty(criteria.VehicleType))
                query = query.Where(r => r.Vehicle.VehicleType.Contains(criteria.VehicleType));

            if (!string.IsNullOrEmpty(criteria.CustomerName))
                query = query.Where(r => r.Customer.Name.Contains(criteria.CustomerName));

            if (!string.IsNullOrEmpty(criteria.CustomerEmail))
                query = query.Where(r => r.Customer.Email.Contains(criteria.CustomerEmail));

            ViewBag.Criteria = criteria;
            return View(await query.ToListAsync());
        }
    }
}
