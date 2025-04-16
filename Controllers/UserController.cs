using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vehicleManagementSystem.Data;
using vehicleManagementSystem.Models;
using System.Security.Cryptography;
using System.Text;

namespace vehicleManagementSystem.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /User/Login
        public IActionResult Login() => View();

        // POST: /User/Login
        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            string hashed = HashPassword(password);

            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == username && u.PasswordHash == hashed);

            if (user != null)
            {
                HttpContext.Session.SetString("Username", user.Username);
                HttpContext.Session.SetString("Role", user.Role ?? "User");

                return RedirectToAction("Dashboard", "User");
            }

            ViewBag.Error = "Invalid credentials.";
            return View();
        }

        // GET: /User/Register
        public IActionResult Register() => View();

        // POST: /User/Register
        [HttpPost]
        public async Task<IActionResult> Register(string username, string password, string confirmPassword)
        {
            if (password != confirmPassword)
            {
                ViewBag.Error = "Passwords do not match.";
                return View();
            }

            var exists = await _context.Users.AnyAsync(u => u.Username == username);
            if (exists)
            {
                ViewBag.Error = "Username already exists.";
                return View();
            }

            var newUser = new User
            {
                Username = username,
                PasswordHash = HashPassword(password),
                Role = "User"
            };

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            return RedirectToAction("Login");
        }

        // GET: /User/Dashboard
        public IActionResult Dashboard()
        {
            if (!HttpContext.Session.TryGetValue("Username", out _))
                return RedirectToAction("Login");

            ViewBag.Username = HttpContext.Session.GetString("Username");
            ViewBag.Role = HttpContext.Session.GetString("Role");
            return View();
        }

        // GET: /User/Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        // Utility: Hash passwords with SHA256 (simple for now)
        private string HashPassword(string password)
        {
            using var sha = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }
}
