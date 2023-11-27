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
    public class QuocgiumsController : ControllerBase
    {
        private readonly web_cinemaContext _context;

        public QuocgiumsController(web_cinemaContext context)
        {
            _context = context;
        }

        // GET: api/Quocgiums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Quocgium>>> GetQuocgia()
        {
          if (_context.Quocgia == null)
          {
              return NotFound();
          }
            return await _context.Quocgia.ToListAsync();
        }

        // GET: api/Quocgiums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Quocgium>> GetQuocgium(string id)
        {
          if (_context.Quocgia == null)
          {
              return NotFound();
          }
            var quocgium = await _context.Quocgia.FindAsync(id);

            if (quocgium == null)
            {
                return NotFound();
            }

            return quocgium;
        }

        // PUT: api/Quocgiums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuocgium(string id, Quocgium quocgium)
        {
            if (id != quocgium.MaQuocgia)
            {
                return BadRequest();
            }

            _context.Entry(quocgium).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuocgiumExists(id))
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

        // POST: api/Quocgiums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Quocgium>> PostQuocgium([FromForm] Quocgium quocgium)
        {
          if (_context.Quocgia == null)
          {
              return Problem("Entity set 'web_cinemaContext.Quocgia'  is null.");
          }
            _context.Quocgia.Add(quocgium);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (QuocgiumExists(quocgium.MaQuocgia))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetQuocgium", new { id = quocgium.MaQuocgia }, quocgium);
        }

        // DELETE: api/Quocgiums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuocgium(string id)
        {
            if (_context.Quocgia == null)
            {
                return NotFound();
            }
            var quocgium = await _context.Quocgia.FindAsync(id);
            if (quocgium == null)
            {
                return NotFound();
            }

            _context.Quocgia.Remove(quocgium);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool QuocgiumExists(string id)
        {
            return (_context.Quocgia?.Any(e => e.MaQuocgia == id)).GetValueOrDefault();
        }
    }
}
