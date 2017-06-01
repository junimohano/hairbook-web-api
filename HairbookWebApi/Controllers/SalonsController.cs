using HairbookWebApi.Database;
using HairbookWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairbookWebApi.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class SalonsController : Controller
    {
        private readonly HairbookContext _context;

        public SalonsController(HairbookContext context)
        {
            _context = context;
        }

        // GET: api/Salons
        [HttpGet]
        public IEnumerable<Salon> GetSalons()
        {
            return _context.Salons;
        }

        // GET: api/Salons/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSalon([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var salon = await _context.Salons.SingleOrDefaultAsync(m => m.SalonId == id);

            if (salon == null)
            {
                return NotFound();
            }

            return Ok(salon);
        }

        // PUT: api/Salons/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalon([FromRoute] int id, [FromBody] Salon salon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != salon.SalonId)
            {
                return BadRequest();
            }

            _context.Entry(salon).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalonExists(id))
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

        // POST: api/Salons
        [HttpPost]
        public async Task<IActionResult> PostSalon([FromBody] Salon salon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Salons.Add(salon);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSalon", new { id = salon.SalonId }, salon);
        }

        // DELETE: api/Salons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSalon([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var salon = await _context.Salons.SingleOrDefaultAsync(m => m.SalonId == id);
            if (salon == null)
            {
                return NotFound();
            }

            _context.Salons.Remove(salon);
            await _context.SaveChangesAsync();

            return Ok(salon);
        }

        private bool SalonExists(int id)
        {
            return _context.Salons.Any(e => e.SalonId == id);
        }
    }
}