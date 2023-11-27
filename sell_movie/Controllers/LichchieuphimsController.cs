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
    public class LichchieuphimsController : ControllerBase
    {
        private readonly web_cinemaContext _context;

        public LichchieuphimsController(web_cinemaContext context)
        {
            _context = context;
        }

        // GET: api/Lichchieuphims
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lichchieuphim>>> GetLichchieuphims()
        {
          if (_context.Lichchieuphims == null)
          {
              return NotFound();
          }
            return await _context.Lichchieuphims.ToListAsync();
        }

        // GET: api/Lichchieuphims/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Lichchieuphim>> GetLichchieuphim(string id)
        {
          if (_context.Lichchieuphims == null)
          {
              return NotFound();
          }
            var lichchieuphim = await _context.Lichchieuphims.FindAsync(id);

            if (lichchieuphim == null)
            {
                return NotFound();
            }

            return lichchieuphim;
        }

        // PUT: api/Lichchieuphims/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLichchieuphim(string id, Lichchieuphim lichchieuphim)
        {
            if (id != lichchieuphim.MaLichPhim)
            {
                return BadRequest();
            }

            _context.Entry(lichchieuphim).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LichchieuphimExists(id))
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

        // POST: api/Lichchieuphims
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Lichchieuphim>> PostLichchieuphim([FromForm] Lichchieuphim lichchieuphim)
        {
          if (_context.Lichchieuphims == null)
          {
              return Problem("Entity set 'web_cinemaContext.Lichchieuphims'  is null.");
          }
            _context.Lichchieuphims.Add(lichchieuphim);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LichchieuphimExists(lichchieuphim.MaLichPhim))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLichchieuphim", new { id = lichchieuphim.MaLichPhim }, lichchieuphim);
        }

        // DELETE: api/Lichchieuphims/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLichchieuphim(string id)
        {
            if (_context.Lichchieuphims == null)
            {
                return NotFound();
            }
            var lichchieuphim = await _context.Lichchieuphims.FindAsync(id);
            if (lichchieuphim == null)
            {
                return NotFound();
            }

            _context.Lichchieuphims.Remove(lichchieuphim);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LichchieuphimExists(string id)
        {
            return (_context.Lichchieuphims?.Any(e => e.MaLichPhim == id)).GetValueOrDefault();
        }
    }
}
