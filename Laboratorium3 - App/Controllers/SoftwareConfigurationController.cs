using lab3_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace lab3_App.Controllers;

public class SoftwareConfigurationController : Controller
{
    private readonly ISoftwareConfigurationService _softwareConfigurationService;
        public SoftwareConfigurationController(ISoftwareConfigurationService service)
        {
            _softwareConfigurationService = service;
        }
    
        [HttpGet]
        public IActionResult Index() => View(_softwareConfigurationService.FindAll());
    
        [HttpGet]
        public IActionResult Create() => View();
    
        [HttpPost]
        public IActionResult Create(SoftwareConfiguration model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
    
            _softwareConfigurationService.Add(model);
            return RedirectToAction("Index");
        }
    
        [HttpGet]
        public IActionResult Update(int id)
        {
            return View(_softwareConfigurationService.FindById(id));
        }
    
        [HttpPost]
        public IActionResult Update(SoftwareConfiguration model)
        {
            if (ModelState.IsValid)
            {
                _softwareConfigurationService.Update(model);
                return RedirectToAction("Index");
            }
            return View();
        }
    
        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_softwareConfigurationService.FindById(id));
        }
    
        [HttpPost]
        public IActionResult Delete(SoftwareConfiguration model)
        {
            _softwareConfigurationService.Delete(model.Id);
            return RedirectToAction("Index");
        }
    
        [HttpGet]
        public IActionResult Details(int id)
        {
            return View(_softwareConfigurationService.FindById(id));
        }
}