﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FestivalAPI.Data;
using FestivalAPI.Models;

namespace FestivalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FestivaliersController : ControllerBase
    {
        private readonly FestivalAPIContext _context;

        public FestivaliersController(FestivalAPIContext context)
        {
            _context = context;
        }

        // GET: api/Festivaliers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Festivalier>>> GetFestivalier()
        {
            return await _context.Festivalier.ToListAsync();
        }

        // GET: api/Festivaliers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Festivalier>> GetFestivalier(int id)
        {
            var festivalier = await _context.Festivalier.FindAsync(id);

            if (festivalier == null)
            {
                return NotFound();
            }

            return festivalier;
        }

        // PUT: api/Festivaliers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFestivalier(int id, Festivalier festivalier)
        {
            if (id != festivalier.IdUser)
            {
                return BadRequest();
            }

            _context.Entry(festivalier).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FestivalierExists(id))
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

        // POST: api/Festivaliers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Festivalier>> PostFestivalier(Festivalier festivalier)
        {
            _context.Festivalier.Add(festivalier);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFestivalier", new { id = festivalier.IdUser }, festivalier);
        }

        // DELETE: api/Festivaliers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Festivalier>> DeleteFestivalier(int id)
        {
            var festivalier = await _context.Festivalier.FindAsync(id);
            if (festivalier == null)
            {
                return NotFound();
            }

            _context.Festivalier.Remove(festivalier);
            await _context.SaveChangesAsync();

            return festivalier;
        }

        private bool FestivalierExists(int id)
        {
            return _context.Festivalier.Any(e => e.IdUser == id);
        }
    }
}
