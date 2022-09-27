using Microsoft.AspNetCore.Mvc;
using SimplePage.Models;
using System.Diagnostics;
using System.Numerics;

namespace SimplePage.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.Message = "Hello World!";
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewBag.Message = "This is an ASP.NET Core MVC App";
            return View();
        }

        public IActionResult Numbers()
        {
            return View();
        }

        public IActionResult NumbersToN(int number = 3)
        {
            ViewBag.Message = "Nums 1 to " + number;
            ViewBag.Number = number;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}