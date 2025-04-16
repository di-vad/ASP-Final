using Microsoft.AspNetCore.Mvc;

namespace vehicleManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
