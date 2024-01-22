using lab3_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace lab3_App.Controllers;

public class ComputerController : Controller
{
    private readonly IComputerService _computerService;
    public ComputerController(IComputerService service)
    {
        _computerService = service;
    }

    [HttpGet]
    public IActionResult Index() => View(_computerService.FindAll());

    [HttpGet]
    public IActionResult Create() => View();

    [HttpPost]
    public IActionResult Create(Computer model)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }

        _computerService.Add(model);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Update(int id)
    {
        return View(_computerService.FindById(id));
    }

    [HttpPost]
    public IActionResult Update(Computer model)
    {
        if (ModelState.IsValid)
        {
            _computerService.Update(model);
            return RedirectToAction("Index");
        }
        return View();
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        return View(_computerService.FindById(id));
    }

    [HttpPost]
    public IActionResult Delete(Computer model)
    {
        _computerService.Delete(model.Id);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Details(int id)
    {
        return View(_computerService.FindById(id));
    }
    
    private List<SelectListItem> CreateSelectListItems()
    {
        return _computerService.FindAllManufacturers()
                        .Select(e => new SelectListItem()
                        {
                            Text = e.Name,
                            Value = e.Id.ToString(),
                        }).Append(new SelectListItem() { Text = "Brak",  Value = ""}).ToList();
    }
}
