using lab3_App.Models;
using Microsoft.AspNetCore.Mvc;

namespace lab3_App.Controllers;

public class ManufacturerController : Controller
{
     private readonly IManufacturerService _manufacturerService;
        public ManufacturerController(IManufacturerService service)
        {
            _manufacturerService = service;
        }
    
        [HttpGet]
        public IActionResult Index() => View(_manufacturerService.FindAll());
    
        [HttpGet]
        public IActionResult Create() => View();
    
        [HttpPost]
        public IActionResult Create(Manufacturer model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
    
            _manufacturerService.Add(model);
            return RedirectToAction("Index");
        }
    
        [HttpGet]
        public IActionResult Update(int id)
        {
            return View(_manufacturerService.FindById(id));
        }
    
        [HttpPost]
        public IActionResult Update(Manufacturer model)
        {
            if (ModelState.IsValid)
            {
                _manufacturerService.Update(model);
                return RedirectToAction("Index");
            }
            return View();
        }
    
        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_manufacturerService.FindById(id));
        }
    
        [HttpPost]
        public IActionResult Delete(Manufacturer model)
        {
            _manufacturerService.Delete(model.Id);
            return RedirectToAction("Index");
        }
    
        [HttpGet]
        public IActionResult Details(int id)
        {
            return View(_manufacturerService.FindById(id));
        }
}