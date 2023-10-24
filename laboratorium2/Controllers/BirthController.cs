using Microsoft.AspNetCore.Mvc;
using laboratorium2.Models;

namespace laboratorium2.Controllers
{
    public class BirthController : Controller
    {
        public IActionResult Form()
        {
            return View();
        }

        public IActionResult Result(Birth model)
        {
            if (!model.IsValid()) { 
                return View("Error");
            }
            return View(model);
        }
    }
}
