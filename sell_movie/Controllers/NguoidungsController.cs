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
    public class NguoidungsController : ControllerBase
    {
        private readonly web_cinemaContext _context;

        public NguoidungsController(web_cinemaContext context)
        {
            _context = context;
        }

        // GET: api/Nguoidungs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Nguoidung>>> GetNguoidungs()
        {
          if (_context.Nguoidungs == null)
          {
              return NotFound();
          }
            return await _context.Nguoidungs.ToListAsync();
        }

        // GET: api/Nguoidungs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Nguoidung>> GetNguoidung(string id)
        {
          if (_context.Nguoidungs == null)
          {
              return NotFound();
          }
            var nguoidung = await _context.Nguoidungs.FindAsync(id);

            if (nguoidung == null)
            {
                return NotFound();
            }

            return nguoidung;
        }

        // PUT: api/Nguoidungs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNguoidung(string id, Nguoidung nguoidung)
        {
            if (id != nguoidung.Username)
            {
                return BadRequest();
            }

            _context.Entry(nguoidung).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NguoidungExists(id))
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

        // POST: api/Nguoidungs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Nguoidung>> PostNguoidung([FromForm] Nguoidung nguoidung)
        {
          if (_context.Nguoidungs == null)
          {
              return Problem("Entity set 'web_cinemaContext.Nguoidungs'  is null.");
          }
            _context.Nguoidungs.Add(nguoidung);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (NguoidungExists(nguoidung.Username))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetNguoidung", new { id = nguoidung.Username }, nguoidung);
        }

        // DELETE: api/Nguoidungs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNguoidung(string id)
        {
            if (_context.Nguoidungs == null)
            {
                return NotFound();
            }
            var nguoidung = await _context.Nguoidungs.FindAsync(id);
            if (nguoidung == null)
            {
                return NotFound();
            }

            _context.Nguoidungs.Remove(nguoidung);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NguoidungExists(string id)
        {
            return (_context.Nguoidungs?.Any(e => e.Username == id)).GetValueOrDefault();
        }
    }
}
