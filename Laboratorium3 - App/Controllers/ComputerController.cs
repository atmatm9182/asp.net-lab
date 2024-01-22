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
            var computer = _computerService.FindById(model.Id);
            if (computer is null)
            {
                return NotFound();
            }
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
        var computer = _computerService.FindById(model.Id);
        if (computer is null) 
        {
            return NotFound();
        }
        _computerService.Delete(model.Id);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Details(int id)
    {
        var computer = _computerService.FindById(id);
        if (computer is null) {
            return NotFound();
        }
        return View(computer);
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
