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
    public class LichchieuxController : ControllerBase
    {
        private readonly web_cinemaContext _context;

        public LichchieuxController(web_cinemaContext context)
        {
            _context = context;
        }

        // GET: api/Lichchieux
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lichchieu>>> GetLichchieus()
        {
          if (_context.Lichchieus == null)
          {
              return NotFound();
          }
            return await _context.Lichchieus.ToListAsync();
        }

        // GET: api/Lichchieux/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Lichchieu>> GetLichchieu(string id)
        {
          if (_context.Lichchieus == null)
          {
              return NotFound();
          }
            var lichchieu = await _context.Lichchieus.FindAsync(id);

            if (lichchieu == null)
            {
                return NotFound();
            }

            return lichchieu;
        }

        // PUT: api/Lichchieux/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLichchieu(string id, Lichchieu lichchieu)
        {
            if (id != lichchieu.MaLichChieu)
            {
                return BadRequest();
            }

            _context.Entry(lichchieu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LichchieuExists(id))
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

        // POST: api/Lichchieux
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Lichchieu>> PostLichchieu([FromForm] Lichchieu lichchieu)
        {
          if (_context.Lichchieus == null)
          {
              return Problem("Entity set 'web_cinemaContext.Lichchieus'  is null.");
          }
            _context.Lichchieus.Add(lichchieu);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LichchieuExists(lichchieu.MaLichChieu))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLichchieu", new { id = lichchieu.MaLichChieu }, lichchieu);
        }

        // DELETE: api/Lichchieux/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLichchieu(string id)
        {
            if (_context.Lichchieus == null)
            {
                return NotFound();
            }
            var lichchieu = await _context.Lichchieus.FindAsync(id);
            if (lichchieu == null)
            {
                return NotFound();
            }

            _context.Lichchieus.Remove(lichchieu);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LichchieuExists(string id)
        {
            return (_context.Lichchieus?.Any(e => e.MaLichChieu == id)).GetValueOrDefault();
        }
    }
}
