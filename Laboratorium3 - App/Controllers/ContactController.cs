using Microsoft.AspNetCore.Mvc;
using lab3_App.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Data.Entities;

namespace lab3_App.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IActionResult Index()
        {
            return View(_contactService.FindAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            List<SelectListItem> orgs = CreateSelectListItems();

            return View(new Contact() { OrganizationList = orgs });
        }

        private List<SelectListItem> CreateSelectListItems()
        {
            return _contactService.FindAllOrganizations()
                            .Select(e => new SelectListItem()
                            {
                                Text = e.Name,
                                Value = e.Id.ToString(),
                            }).Append(new SelectListItem() { Text = "Brak",  Value = ""}).ToList();
        }

        [HttpPost]
        public IActionResult Create(Contact model)
        {
            if (ModelState.IsValid)
            {
                _contactService.Add(model);
                return RedirectToAction("Index");
            }
            model.OrganizationList = CreateSelectListItems();
            return View(model);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            return View(_contactService.FindById(id));
        }

        [HttpPost]
        public IActionResult Update(Contact model)
        {
            if (ModelState.IsValid)
            {
                _contactService.Update(model);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_contactService.FindById(id));
        }

        [HttpPost]
        public IActionResult Delete(Contact model)
        {
            _contactService.Delete(model.Id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            return View(_contactService.FindById(id));
        }
    }
}
