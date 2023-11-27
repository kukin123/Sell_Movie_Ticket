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
    public class GiavesController : ControllerBase
    {
        private readonly web_cinemaContext _context;

        public GiavesController(web_cinemaContext context)
        {
            _context = context;
        }

        // GET: api/Giaves
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Giave>>> GetGiaves()
        {
          if (_context.Giaves == null)
          {
              return NotFound();
          }
            return await _context.Giaves.ToListAsync();
        }

        // GET: api/Giaves/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Giave>> GetGiave(string id)
        {
          if (_context.Giaves == null)
          {
              return NotFound();
          }
            var giave = await _context.Giaves.FindAsync(id);

            if (giave == null)
            {
                return NotFound();
            }

            return giave;
        }

        // PUT: api/Giaves/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGiave(string id, Giave giave)
        {
            if (id != giave.MaGiaVe)
            {
                return BadRequest();
            }

            _context.Entry(giave).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GiaveExists(id))
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

        // POST: api/Giaves
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Giave>> PostGiave([FromForm] Giave giave)
        {
          if (_context.Giaves == null)
          {
              return Problem("Entity set 'web_cinemaContext.Giaves'  is null.");
          }
            _context.Giaves.Add(giave);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (GiaveExists(giave.MaGiaVe))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetGiave", new { id = giave.MaGiaVe }, giave);
        }

        // DELETE: api/Giaves/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGiave(string id)
        {
            if (_context.Giaves == null)
            {
                return NotFound();
            }
            var giave = await _context.Giaves.FindAsync(id);
            if (giave == null)
            {
                return NotFound();
            }

            _context.Giaves.Remove(giave);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GiaveExists(string id)
        {
            return (_context.Giaves?.Any(e => e.MaGiaVe == id)).GetValueOrDefault();
        }
    }
}
