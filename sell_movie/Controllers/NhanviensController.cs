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
    public class NhanviensController : ControllerBase
    {
        private readonly web_cinemaContext _context;

        public NhanviensController(web_cinemaContext context)
        {
            _context = context;
        }

        // GET: api/Nhanviens
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Nhanvien>>> GetNhanviens()
        {
          if (_context.Nhanviens == null)
          {
              return NotFound();
          }
            return await _context.Nhanviens.ToListAsync();
        }

        // GET: api/Nhanviens/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Nhanvien>> GetNhanvien(string id)
        {
          if (_context.Nhanviens == null)
          {
              return NotFound();
          }
            var nhanvien = await _context.Nhanviens.FindAsync(id);

            if (nhanvien == null)
            {
                return NotFound();
            }

            return nhanvien;
        }

        // PUT: api/Nhanviens/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNhanvien(string id, Nhanvien nhanvien)
        {
            if (id != nhanvien.MaNhanVien)
            {
                return BadRequest();
            }

            _context.Entry(nhanvien).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NhanvienExists(id))
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

        // POST: api/Nhanviens
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Nhanvien>> PostNhanvien([FromForm] Nhanvien nhanvien)
        {
          if (_context.Nhanviens == null)
          {
              return Problem("Entity set 'web_cinemaContext.Nhanviens'  is null.");
          }
            _context.Nhanviens.Add(nhanvien);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (NhanvienExists(nhanvien.MaNhanVien))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetNhanvien", new { id = nhanvien.MaNhanVien }, nhanvien);
        }

        // DELETE: api/Nhanviens/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNhanvien(string id)
        {
            if (_context.Nhanviens == null)
            {
                return NotFound();
            }
            var nhanvien = await _context.Nhanviens.FindAsync(id);
            if (nhanvien == null)
            {
                return NotFound();
            }

            _context.Nhanviens.Remove(nhanvien);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NhanvienExists(string id)
        {
            return (_context.Nhanviens?.Any(e => e.MaNhanVien == id)).GetValueOrDefault();
        }
    }
}
