using Data;
using Microsoft.AspNetCore.Mvc;

namespace lab3_App.Controllers;

[Route("/api/applications")]
[ApiController]
public class SoftwareApplicationApiController : Controller
{
    private readonly AppDbContext _context;

    public SoftwareApplicationApiController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult GetById(int? id)
    {
        if (id == null)
        {
            return Ok(_context.Applications.ToList());
        }

        var app = _context.Applications.Find();
        return app == null ? NotFound() : Ok(app);
    }
}