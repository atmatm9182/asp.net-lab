using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace lab3_App.Controllers
{
    [Route("api/organizations")]
    [ApiController]
    public class OrganizationApiController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OrganizationApiController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult GetOrganizationsByName(string? q)
        {
            return Ok(
                q is null ?
                _context.Organizations.ToList() :
                _context.Organizations.Where(org => org.Name.StartsWith(q)).Select(c => new { Name = c.Name, Id = c.Id }).ToList());
        }

        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            var entity = _context.Organizations.Find(id);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }
    }
}
