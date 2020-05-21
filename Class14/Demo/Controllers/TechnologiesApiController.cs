using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Data;
using Demo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Demo.Controllers
{
    [Route("api/Technologies")]
    [ApiController]
    public class TechnologiesApiController : ControllerBase
    {
        private readonly SchoolDbContext _context;

        public TechnologiesApiController(SchoolDbContext context)
        {
            _context = context;
        }

        // GET: api/TechnologiesApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Technology>>> GetTechnologies()
        {
            return await _context.Technologies.ToListAsync();
        }

        // GET: api/TechnologiesApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Technology>> GetTechnology(int id)
        {
            var technology = await _context.Technologies.FindAsync(id);

            if (technology == null)
            {
                return NotFound();
            }

            return technology;
        }

        // PUT: api/TechnologiesApi/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTechnology(int id, Technology technology)
        {
            if (id != technology.Id)
            {
                return BadRequest();
            }

            _context.Entry(technology).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TechnologyExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TechnologiesApi
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Technology>> PostTechnology(Technology technology)
        {
            _context.Technologies.Add(technology);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTechnology", new { id = technology.Id }, technology);
        }

        // DELETE: api/TechnologiesApi/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Technology>> DeleteTechnology(int id)
        {
            var technology = await _context.Technologies.FindAsync(id);
            if (technology == null)
            {
                return NotFound();
            }

            _context.Technologies.Remove(technology);
            await _context.SaveChangesAsync();

            return technology;
        }

        private bool TechnologyExists(int id)
        {
            return _context.Technologies.Any(e => e.Id == id);
        }
    }
}
