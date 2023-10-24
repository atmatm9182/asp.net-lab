using lab3_App.Models;
using Microsoft.AspNetCore.Mvc;

namespace lab3_App.Controllers;

public class ComputerController : Controller
{
	private static Dictionary<int, Computer> _computers = new();
	private static int _id = 1;

	[HttpGet]
	public IActionResult Index() => View(_computers);

	[HttpGet]
	public IActionResult Create() => View();

	[HttpPost]
	public IActionResult Create(Computer model)
	{
		if (!ModelState.IsValid)
		{
			return View();
		}

		model.Id = _id++;
		_computers[_id - 1] = model;
		return RedirectToAction("Index");
	}

        [HttpGet]
        public IActionResult Update(int id)
        {
            return View(_computers[id]);
        }

        [HttpPost]
        public IActionResult Update(Computer model)
        {
            if (ModelState.IsValid)
            {
                _computers[model.Id] = model;
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_computers[id]);
        }

        [HttpPost]
        public IActionResult Delete(Computer model)
        {
            _computers.Remove(model.Id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            return View(_computers[id]);
        }
        [HttpPost]
        public IActionResult Details(Computer model)
        {
            return RedirectToAction("Index");
        }
}
