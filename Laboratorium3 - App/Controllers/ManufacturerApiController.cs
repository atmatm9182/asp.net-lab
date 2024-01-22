using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace lab3_App.Controllers
{
    [Route("api/manufacturers")]
    [ApiController]
    public class ManufacturerApiController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ManufacturerApiController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult GetManufacturersByName(string? q)
        {
            return Ok(
                q is null ?
                _context.Manufacturers.ToList() :
                _context.Manufacturers.Where(m => m.Name.StartsWith(q)).Select(c => new { Name = c.Name, Id = c.Id }).ToList());
        }

        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            var entity = _context.Manufacturers.Find(id);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }
    }
}
