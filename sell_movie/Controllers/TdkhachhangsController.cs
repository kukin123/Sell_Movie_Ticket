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
    public class TdkhachhangsController : ControllerBase
    {
        private readonly web_cinemaContext _context;

        public TdkhachhangsController(web_cinemaContext context)
        {
            _context = context;
        }

        // GET: api/Tdkhachhangs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tdkhachhang>>> GetTdkhachhangs()
        {
          if (_context.Tdkhachhangs == null)
          {
              return NotFound();
          }
            return await _context.Tdkhachhangs.ToListAsync();
        }

        // GET: api/Tdkhachhangs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tdkhachhang>> GetTdkhachhang(string id)
        {
          if (_context.Tdkhachhangs == null)
          {
              return NotFound();
          }
            var tdkhachhang = await _context.Tdkhachhangs.FindAsync(id);

            if (tdkhachhang == null)
            {
                return NotFound();
            }

            return tdkhachhang;
        }

        // PUT: api/Tdkhachhangs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTdkhachhang(string id, Tdkhachhang tdkhachhang)
        {
            if (id != tdkhachhang.Makhachhang)
            {
                return BadRequest();
            }

            _context.Entry(tdkhachhang).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TdkhachhangExists(id))
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

        // POST: api/Tdkhachhangs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tdkhachhang>> PostTdkhachhang([FromForm] Tdkhachhang tdkhachhang)
        {
          if (_context.Tdkhachhangs == null)
          {
              return Problem("Entity set 'web_cinemaContext.Tdkhachhangs'  is null.");
          }
            _context.Tdkhachhangs.Add(tdkhachhang);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TdkhachhangExists(tdkhachhang.Makhachhang))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTdkhachhang", new { id = tdkhachhang.Makhachhang }, tdkhachhang);
        }

        // DELETE: api/Tdkhachhangs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTdkhachhang(string id)
        {
            if (_context.Tdkhachhangs == null)
            {
                return NotFound();
            }
            var tdkhachhang = await _context.Tdkhachhangs.FindAsync(id);
            if (tdkhachhang == null)
            {
                return NotFound();
            }

            _context.Tdkhachhangs.Remove(tdkhachhang);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TdkhachhangExists(string id)
        {
            return (_context.Tdkhachhangs?.Any(e => e.Makhachhang == id)).GetValueOrDefault();
        }
    }
}
