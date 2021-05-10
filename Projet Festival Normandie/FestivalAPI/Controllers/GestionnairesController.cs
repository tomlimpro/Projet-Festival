using System;
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
    public class GestionnairesController : ControllerBase
    {
        private readonly FestivalAPIContext _context;

        public GestionnairesController(FestivalAPIContext context)
        {
            _context = context;
        }

        // GET: api/Gestionnaires
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gestionnaire>>> GetGestionnaire()
        {
            return await _context.Gestionnaire.ToListAsync();
        }

        // GET: api/Gestionnaires/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Gestionnaire>> GetGestionnaire(int id)
        {
            var gestionnaire = await _context.Gestionnaire.FindAsync(id);

            if (gestionnaire == null)
            {
                return NotFound();
            }

            return gestionnaire;
        }

        [HttpGet("GetLoginGestionnaire/{Email}/{Mdp}")]
        public async Task<ActionResult<Gestionnaire>> GetLoginGestionnaire(string email, string mdp)
        {
            var gestionnaire = await _context.Gestionnaire.FirstOrDefaultAsync(u => u.Email.Equals(email) && u.Mdp.Equals(mdp));


            if (gestionnaire == null)
            {
                return NotFound();
            }


            return gestionnaire;
        }
        // PUT: api/Gestionnaires/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGestionnaire(int id, Gestionnaire gestionnaire)
        {
            if (id != gestionnaire.IdGestionnaire)
            {
                return BadRequest();
            }

            _context.Entry(gestionnaire).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GestionnaireExists(id))
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

        // POST: api/Gestionnaires
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Gestionnaire>> PostGestionnaire(Gestionnaire gestionnaire)
        {
            _context.Gestionnaire.Add(gestionnaire);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGestionnaire", new { id = gestionnaire.IdGestionnaire }, gestionnaire);
        }

        // DELETE: api/Gestionnaires/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Gestionnaire>> DeleteGestionnaire(int id)
        {
            var gestionnaire = await _context.Gestionnaire.FindAsync(id);
            if (gestionnaire == null)
            {
                return NotFound();
            }

            _context.Gestionnaire.Remove(gestionnaire);
            await _context.SaveChangesAsync();

            return gestionnaire;
        }

        private bool GestionnaireExists(int id)
        {
            return _context.Gestionnaire.Any(e => e.IdGestionnaire == id);
        }
    }
}
