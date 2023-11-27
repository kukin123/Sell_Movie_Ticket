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
    public class TtdatvesController : ControllerBase
    {
        private readonly web_cinemaContext _context;

        public TtdatvesController(web_cinemaContext context)
        {
            _context = context;
        }

        // GET: api/Ttdatves
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ttdatve>>> GetTtdatves()
        {
          if (_context.Ttdatves == null)
          {
              return NotFound();
          }
            return await _context.Ttdatves.ToListAsync();
        }

        // GET: api/Ttdatves/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ttdatve>> GetTtdatve(int id)
        {
          if (_context.Ttdatves == null)
          {
              return NotFound();
          }
            var ttdatve = await _context.Ttdatves.FindAsync(id);

            if (ttdatve == null)
            {
                return NotFound();
            }

            return ttdatve;
        }

        // PUT: api/Ttdatves/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTtdatve(int id, Ttdatve ttdatve)
        {
            if (id != ttdatve.MaDatVe)
            {
                return BadRequest();
            }

            _context.Entry(ttdatve).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TtdatveExists(id))
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

        // POST: api/Ttdatves
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ttdatve>> PostTtdatve([FromForm] Ttdatve ttdatve)
        {
          if (_context.Ttdatves == null)
          {
              return Problem("Entity set 'web_cinemaContext.Ttdatves'  is null.");
          }
            _context.Ttdatves.Add(ttdatve);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TtdatveExists(ttdatve.MaDatVe))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTtdatve", new { id = ttdatve.MaDatVe }, ttdatve);
        }

        // DELETE: api/Ttdatves/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTtdatve(int id)
        {
            if (_context.Ttdatves == null)
            {
                return NotFound();
            }
            var ttdatve = await _context.Ttdatves.FindAsync(id);
            if (ttdatve == null)
            {
                return NotFound();
            }

            _context.Ttdatves.Remove(ttdatve);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TtdatveExists(int id)
        {
            return (_context.Ttdatves?.Any(e => e.MaDatVe == id)).GetValueOrDefault();
        }
    }
}
