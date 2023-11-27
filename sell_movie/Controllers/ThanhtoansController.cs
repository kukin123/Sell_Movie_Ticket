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
    public class ThanhtoansController : ControllerBase
    {
        private readonly web_cinemaContext _context;

        public ThanhtoansController(web_cinemaContext context)
        {
            _context = context;
        }

        // GET: api/Thanhtoans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Thanhtoan>>> GetThanhtoans()
        {
          if (_context.Thanhtoans == null)
          {
              return NotFound();
          }
            return await _context.Thanhtoans.ToListAsync();
        }

        // GET: api/Thanhtoans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Thanhtoan>> GetThanhtoan(string id)
        {
          if (_context.Thanhtoans == null)
          {
              return NotFound();
          }
            var thanhtoan = await _context.Thanhtoans.FindAsync(id);

            if (thanhtoan == null)
            {
                return NotFound();
            }

            return thanhtoan;
        }

        // PUT: api/Thanhtoans/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutThanhtoan(string id, Thanhtoan thanhtoan)
        {
            if (id != thanhtoan.MaThanhToan)
            {
                return BadRequest();
            }

            _context.Entry(thanhtoan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ThanhtoanExists(id))
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

        // POST: api/Thanhtoans
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Thanhtoan>> PostThanhtoan([FromForm] Thanhtoan thanhtoan)
        {
          if (_context.Thanhtoans == null)
          {
              return Problem("Entity set 'web_cinemaContext.Thanhtoans'  is null.");
          }
            _context.Thanhtoans.Add(thanhtoan);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ThanhtoanExists(thanhtoan.MaThanhToan))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetThanhtoan", new { id = thanhtoan.MaThanhToan }, thanhtoan);
        }

        // DELETE: api/Thanhtoans/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteThanhtoan(string id)
        {
            if (_context.Thanhtoans == null)
            {
                return NotFound();
            }
            var thanhtoan = await _context.Thanhtoans.FindAsync(id);
            if (thanhtoan == null)
            {
                return NotFound();
            }

            _context.Thanhtoans.Remove(thanhtoan);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ThanhtoanExists(string id)
        {
            return (_context.Thanhtoans?.Any(e => e.MaThanhToan == id)).GetValueOrDefault();
        }
    }
}
