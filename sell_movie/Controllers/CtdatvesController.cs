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
    public class CtdatvesController : ControllerBase
    {
        private readonly web_cinemaContext _context;

        public CtdatvesController(web_cinemaContext context)
        {
            _context = context;
        }

        // GET: api/Ctdatves
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ctdatve>>> GetCtdatves()
        {
          if (_context.Ctdatves == null)
          {
              return NotFound();
          }
            return await _context.Ctdatves.ToListAsync();
        }

        // GET: api/Ctdatves/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ctdatve>> GetCtdatve(int id)
        {
          if (_context.Ctdatves == null)
          {
              return NotFound();
          }
            var ctdatve = await _context.Ctdatves.FindAsync(id);

            if (ctdatve == null)
            {
                return NotFound();
            }

            return ctdatve;
        }

        // PUT: api/Ctdatves/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCtdatve(int id, Ctdatve ctdatve)
        {
            if (id != ctdatve.MaDatVe)
            {
                return BadRequest();
            }

            _context.Entry(ctdatve).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CtdatveExists(id))
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

        // POST: api/Ctdatves
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ctdatve>> PostCtdatve([FromForm] Ctdatve ctdatve)
        {
          if (_context.Ctdatves == null)
          {
              return Problem("Entity set 'web_cinemaContext.Ctdatves'  is null.");
          }
            _context.Ctdatves.Add(ctdatve);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CtdatveExists(ctdatve.MaDatVe))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCtdatve", new { id = ctdatve.MaDatVe }, ctdatve);
        }

        // DELETE: api/Ctdatves/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCtdatve(int id)
        {
            if (_context.Ctdatves == null)
            {
                return NotFound();
            }
            var ctdatve = await _context.Ctdatves.FindAsync(id);
            if (ctdatve == null)
            {
                return NotFound();
            }

            _context.Ctdatves.Remove(ctdatve);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CtdatveExists(int id)
        {
            return (_context.Ctdatves?.Any(e => e.MaDatVe == id)).GetValueOrDefault();
        }
    }
}
