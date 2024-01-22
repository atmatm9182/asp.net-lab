using Data.Entities;
using lab3_App.Models;
using Microsoft.AspNetCore.Mvc;

namespace lab3_App.Controllers;

public class OsController : Controller
{
    private readonly IOperatingSystemService _operatingSystemService;
    public OsController(IOperatingSystemService service)
    {
        _operatingSystemService = service;
    }

    [HttpGet]
    public IActionResult Index() => View(_operatingSystemService.FindAll());

    [HttpGet]
    public IActionResult Create() => View();

    [HttpPost]
    public IActionResult Create(OperatingSystemEntity model)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }

        _operatingSystemService.Add(model);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Update(int id)
    {
        return View(_operatingSystemService.FindById(id));
    }

    [HttpPost]
    public IActionResult Update(OperatingSystemEntity model)
    {
        if (ModelState.IsValid)
        {
            _operatingSystemService.Update(model);
            return RedirectToAction("Index");
        }
        return View();
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        return View(_operatingSystemService.FindById(id));
    }

    [HttpPost]
    public IActionResult Delete(OperatingSystemEntity model)
    {
        _operatingSystemService.Delete(model.Id);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Details(int id)
    {
        return View(_operatingSystemService.FindById(id));
    }
}