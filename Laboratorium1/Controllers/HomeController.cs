using Laboratorium1.Models;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Diagnostics;
using System.Reflection.Metadata;

namespace Laboratorium1.Controllers
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
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About(string author)
        {
            // var author = Request.Query["author"];
            ViewBag.Author = author;
            return View();
        }

        public IActionResult Calculator(
            [FromQuery(Name = "operator")] string? op, double? x, double? y)
        {
            if (op == null)
            {
                ViewBag.CalculatorErrorMessage = "no operator provided";
                return View("Error");
            }

            var validOperators = new string[] { "add", "sub", "mul", "div" };
            if (!validOperators.Contains(op))
            {
                ViewBag.CalculatorErrorMessage = $"bad operator {op}";
                return View("Error");
            }

            // zbiór operatorów: add, sub, mul, div
            if (x == null || y == null)
            {
                ViewBag.CalculatorErrorMessage = "x or y is null";
                return View("Error");
            }

            ViewBag.Result = op switch
            { 
                "add" => x + y,
                "sub" => x - y,
                "div" => x / y,
                "mul" => x * y,
            };
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}