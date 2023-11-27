using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sell_movie.Models;

namespace sell_movie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GhesController : ControllerBase
    {
        private readonly web_cinemaContext _context;

        public GhesController(web_cinemaContext context)
        {
            _context = context;
        }

        // GET: api/Ghes
        [HttpGet]
        [Route("Getctdatve")]
        public async Task<ActionResult<IEnumerable<Ghe>>> GetGhes()
        {
          if (_context.Ghes == null)
          {
              return NotFound();
          }
            return await _context.Ghes.ToListAsync();
        }

        // GET: api/Ghes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ghe>> GetGhe(string id)
        {
          if (_context.Ghes == null)
          {
              return NotFound();
          }
            var ghe = await _context.Ghes.FindAsync(id);

            if (ghe == null)
            {
                return NotFound();
            }

            return ghe;
        }

        // PUT: api/Ghes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGhe(string id, Ghe ghe)
        {
            if (id != ghe.MaGhe)
            {
                return BadRequest();
            }

            _context.Entry(ghe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GheExists(id))
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

        // POST: api/Ghes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ghe>> PostGhe([FromForm] Ghe ghe)
        {
          if (_context.Ghes == null)
          {
              return Problem("Entity set 'web_cinemaContext.Ghes'  is null.");
          }
            _context.Ghes.Add(ghe);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (GheExists(ghe.MaGhe))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetGhe", new { id = ghe.MaGhe }, ghe);
        }

        // DELETE: api/Ghes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGhe(string id)
        {
            if (_context.Ghes == null)
            {
                return NotFound();
            }
            var ghe = await _context.Ghes.FindAsync(id);
            if (ghe == null)
            {
                return NotFound();
            }

            _context.Ghes.Remove(ghe);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GheExists(string id)
        {
            return (_context.Ghes?.Any(e => e.MaGhe == id)).GetValueOrDefault();
        }
    }
}
