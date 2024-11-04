using Hospital_Mangment_System_DAL.DB;
using Hospital_Mangment_System_PL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Hospital_Mangment_System_PL.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDBcontext _context;

        public HomeController(ILogger<HomeController> logger,ApplicationDBcontext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var username = HttpContext.Session.GetString("Username"); // «” —Ã«⁄ «”„ «·„” Œœ„ „‰ Session
            ViewBag.Username = username; //  „—Ì— «”„ «·„” Œœ„ ≈·Ï «·‹ View »«” Œœ«„ ViewBag
            return View();

           
        }

        public IActionResult Privacy()
        {
            return View();
        }


        public IActionResult About()
        {
            return View();
        }
        public IActionResult Service()
        {
            return View();
        }
        public IActionResult Pricing()
        {
            return View();
        }
        public IActionResult BlogGrid()
        {
            return View();
        }
        public IActionResult BlogDetail()
        {
            return View();
        }


        public IActionResult TheTeam()
        {
            return View();
        }
        public IActionResult Testimonial()
        {
            return View();
        }
        public IActionResult Appointment()
        {
            return View();
        }
        public IActionResult Search()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }




    }
}
