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
    public class PhimsController : ControllerBase
    {
        private readonly web_cinemaContext _context;

        public PhimsController(web_cinemaContext context)
        {
            _context = context;
        }

        // GET: api/Phims
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Phim>>> GetPhims()
        {
          if (_context.Phims == null)
          {
              return NotFound();
          }
            return await _context.Phims.ToListAsync();
        }

        // GET: api/Phims/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Phim>> GetPhim(string id)
        {
          if (_context.Phims == null)
          {
              return NotFound();
          }
            var phim = await _context.Phims.FindAsync(id);

            if (phim == null)
            {
                return NotFound();
            }

            return phim;
        }

        // PUT: api/Phims/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPhim(string id, Phim phim)
        {
            if (id != phim.MaPhim)
            {
                return BadRequest();
            }

            _context.Entry(phim).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhimExists(id))
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

        // POST: api/Phims
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Phim>> PostPhim([FromForm] Phim phim)
        {
          if (_context.Phims == null)
          {
              return Problem("Entity set 'web_cinemaContext.Phims'  is null.");
          }
            _context.Phims.Add(phim);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PhimExists(phim.MaPhim))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPhim", new { id = phim.MaPhim }, phim);
        }

        // DELETE: api/Phims/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhim(string id)
        {
            if (_context.Phims == null)
            {
                return NotFound();
            }
            var phim = await _context.Phims.FindAsync(id);
            if (phim == null)
            {
                return NotFound();
            }

            _context.Phims.Remove(phim);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PhimExists(string id)
        {
            return (_context.Phims?.Any(e => e.MaPhim == id)).GetValueOrDefault();
        }
    }
}
