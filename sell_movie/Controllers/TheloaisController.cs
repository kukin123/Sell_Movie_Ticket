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
    public class TheloaisController : ControllerBase
    {
        private readonly web_cinemaContext _context;

        public TheloaisController(web_cinemaContext context)
        {
            _context = context;
        }

        // GET: api/Theloais
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Theloai>>> GetTheloais()
        {
          if (_context.Theloais == null)
          {
              return NotFound();
          }
            return await _context.Theloais.ToListAsync();
        }

        // GET: api/Theloais/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Theloai>> GetTheloai(string id)
        {
          if (_context.Theloais == null)
          {
              return NotFound();
          }
            var theloai = await _context.Theloais.FindAsync(id);

            if (theloai == null)
            {
                return NotFound();
            }

            return theloai;
        }

        // PUT: api/Theloais/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTheloai(string id, Theloai theloai)
        {
            if (id != theloai.MaTl)
            {
                return BadRequest();
            }

            _context.Entry(theloai).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TheloaiExists(id))
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

        // POST: api/Theloais
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Theloai>> PostTheloai([FromForm] Theloai theloai)
        {
          if (_context.Theloais == null)
          {
              return Problem("Entity set 'web_cinemaContext.Theloais'  is null.");
          }
            _context.Theloais.Add(theloai);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TheloaiExists(theloai.MaTl))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTheloai", new { id = theloai.MaTl }, theloai);
        }

        // DELETE: api/Theloais/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTheloai(string id)
        {
            if (_context.Theloais == null)
            {
                return NotFound();
            }
            var theloai = await _context.Theloais.FindAsync(id);
            if (theloai == null)
            {
                return NotFound();
            }

            _context.Theloais.Remove(theloai);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TheloaiExists(string id)
        {
            return (_context.Theloais?.Any(e => e.MaTl == id)).GetValueOrDefault();
        }
    }
}
