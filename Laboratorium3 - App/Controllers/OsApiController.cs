using Data;
using Microsoft.AspNetCore.Mvc;

namespace lab3_App.Controllers;

[Route("api/operatingSystems")]
[ApiController]
public class OsApiController : ControllerBase
{
    private readonly AppDbContext _context;

    public OsApiController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult GetOperatingSystemsByName(string? q)
    {
        return Ok(
            q is null ?
            _context.OperatingSystems.ToList() :
            _context.OperatingSystems.Where(org => org.Name.StartsWith(q)).Select(c => new { Name = c.Name, Id = c.Id }).ToList());
    }

    [Route("{id}")]
    public IActionResult GetById(int id)
    {
        var entity = _context.OperatingSystems.Find(id);
        if (entity == null)
        {
            return NotFound();
        }
        return Ok(entity);
    }
}