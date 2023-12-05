using lab3_App.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace lab3.Controllers
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
            ViewBag.LastVisit = HttpContext.Items[LastVisitCookie.CookieName];
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}