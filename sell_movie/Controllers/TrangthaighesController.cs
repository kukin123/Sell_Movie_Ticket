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
    public class TrangthaighesController : ControllerBase
    {
        private readonly web_cinemaContext _context;

        public TrangthaighesController(web_cinemaContext context)
        {
            _context = context;
        }

        // GET: api/Trangthaighes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Trangthaighe>>> GetTrangthaighes()
        {
          if (_context.Trangthaighes == null)
          {
              return NotFound();
          }
            return await _context.Trangthaighes.ToListAsync();
        }

        // GET: api/Trangthaighes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Trangthaighe>> GetTrangthaighe(string id)
        {
          if (_context.Trangthaighes == null)
          {
              return NotFound();
          }
            var trangthaighe = await _context.Trangthaighes.FindAsync(id);

            if (trangthaighe == null)
            {
                return NotFound();
            }

            return trangthaighe;
        }

        // PUT: api/Trangthaighes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrangthaighe(string id, Trangthaighe trangthaighe)
        {
            if (id != trangthaighe.Maghe)
            {
                return BadRequest();
            }

            _context.Entry(trangthaighe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrangthaigheExists(id))
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

        // POST: api/Trangthaighes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Trangthaighe>> PostTrangthaighe([FromForm] Trangthaighe trangthaighe)
        {
          if (_context.Trangthaighes == null)
          {
              return Problem("Entity set 'web_cinemaContext.Trangthaighes'  is null.");
          }
            _context.Trangthaighes.Add(trangthaighe);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TrangthaigheExists(trangthaighe.Maghe))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTrangthaighe", new { id = trangthaighe.Maghe }, trangthaighe);
        }

        // DELETE: api/Trangthaighes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrangthaighe(string id)
        {
            if (_context.Trangthaighes == null)
            {
                return NotFound();
            }
            var trangthaighe = await _context.Trangthaighes.FindAsync(id);
            if (trangthaighe == null)
            {
                return NotFound();
            }

            _context.Trangthaighes.Remove(trangthaighe);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TrangthaigheExists(string id)
        {
            return (_context.Trangthaighes?.Any(e => e.Maghe == id)).GetValueOrDefault();
        }
    }
}
