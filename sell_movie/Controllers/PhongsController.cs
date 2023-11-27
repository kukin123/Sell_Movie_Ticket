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
    public class PhongsController : ControllerBase
    {
        private readonly web_cinemaContext _context;

        public PhongsController(web_cinemaContext context)
        {
            _context = context;
        }
      
        // GET: api/Phongs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Phong>>> GetPhongs()
        {
          if (_context.Phongs == null)
          {
              return NotFound();
          }
            return await _context.Phongs.ToListAsync();
            
        }

        // GET: api/Phongs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Phong>> GetPhong(string id)
        {
          if (_context.Phongs == null)
          {
              return NotFound();
          }
            var phong = await _context.Phongs.FindAsync(id);

            if (phong == null)
            {
                return NotFound();
            }

            return phong;
        }

        // PUT: api/Phongs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPhong(string id, Phong phong)
        {
            if (id != phong.MaPhong)
            {
                return BadRequest();
            }

            _context.Entry(phong).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhongExists(id))
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

        // POST: api/Phongs
        [HttpPost]
        public async Task<ActionResult<Phong>> PostPhong([FromForm] Phong phong)
        {
            if (_context.Phongs == null)
            {
                return Problem("Entity set 'web_cinemaContext.Phongs' is null.");
            }

            // Thêm phòng
            _context.Phongs.Add(phong);

            // Thêm bàn ghế
            int soLuongGhe = phong.SoChoNgoi;
            int soCot = phong.Socot;
            int soHang = phong.SoHang;

            for (int i = 1; i <= soLuongGhe; i++)
            {
                int cot = (i - 1) % soCot + 1;
                int hang = (i - 1) / soCot + 1;

                Ghe ghe = new Ghe
                {
                    MaGhe = $"{phong.MaPhong}-{i}",
                    TenGhe = $"Ghế {i}",
                    MaPhong = phong.MaPhong,
                    Cot = cot,
                    Hang = hang
                };

                _context.Ghes.Add(ghe);
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PhongExists(phong.MaPhong))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPhong", new { id = phong.MaPhong }, phong);
        }

        // DELETE: api/Phongs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhong(string id)
        {
            if (_context.Phongs == null)
            {
                return NotFound();
            }
            var phong = await _context.Phongs.FindAsync(id);
            if (phong == null)
            {
                return NotFound();
            }

            _context.Phongs.Remove(phong);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PhongExists(string id)
        {
            return (_context.Phongs?.Any(e => e.MaPhong == id)).GetValueOrDefault();
        }
    }
}
