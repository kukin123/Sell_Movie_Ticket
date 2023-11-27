﻿using System;
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
    public class KhachhangsController : ControllerBase
    {
        private readonly web_cinemaContext _context;

        public KhachhangsController(web_cinemaContext context)
        {
            _context = context;
        }

        // GET: api/Khachhangs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Khachhang>>> GetKhachhangs()
        {
          if (_context.Khachhangs == null)
          {
              return NotFound();
          }
            return await _context.Khachhangs.ToListAsync();
        }

        // GET: api/Khachhangs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Khachhang>> GetKhachhang(string id)
        {
          if (_context.Khachhangs == null)
          {
              return NotFound();
          }
            var khachhang = await _context.Khachhangs.FindAsync(id);

            if (khachhang == null)
            {
                return NotFound();
            }

            return khachhang;
        }

        // PUT: api/Khachhangs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKhachhang(string id, Khachhang khachhang)
        {
            if (id != khachhang.Makhachhang)
            {
                return BadRequest();
            }

            _context.Entry(khachhang).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KhachhangExists(id))
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

        // POST: api/Khachhangs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Khachhang>> PostKhachhang([FromForm] Khachhang khachhang)
        {
          if (_context.Khachhangs == null)
          {
              return Problem("Entity set 'web_cinemaContext.Khachhangs'  is null.");
          }
            _context.Khachhangs.Add(khachhang);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (KhachhangExists(khachhang.Makhachhang))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetKhachhang", new { id = khachhang.Makhachhang }, khachhang);
        }

        // DELETE: api/Khachhangs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKhachhang(string id)
        {
            if (_context.Khachhangs == null)
            {
                return NotFound();
            }
            var khachhang = await _context.Khachhangs.FindAsync(id);
            if (khachhang == null)
            {
                return NotFound();
            }

            _context.Khachhangs.Remove(khachhang);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KhachhangExists(string id)
        {
            return (_context.Khachhangs?.Any(e => e.Makhachhang == id)).GetValueOrDefault();
        }
    }
}
