using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIFestival.Data;
using APIFestival.Models;

namespace APIFestival.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganisateursController : ControllerBase
    {
        private readonly APIFestivalContext _context;

        public OrganisateursController(APIFestivalContext context)
        {
            _context = context;
        }

        // GET: api/Organisateurs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Organisateur>>> GetOrganisateur()
        {
            return await _context.Organisateur.ToListAsync();
        }

        // GET: api/Organisateurs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Organisateur>> GetOrganisateur(int id)
        {
            var organisateur = await _context.Organisateur.FindAsync(id);

            if (organisateur == null)
            {
                return NotFound();
            }

            return organisateur;
        }

        // PUT: api/Organisateurs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrganisateur(int id, Organisateur organisateur)
        {
            if (id != organisateur.IdUser)
            {
                return BadRequest();
            }

            _context.Entry(organisateur).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrganisateurExists(id))
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

        // POST: api/Organisateurs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Organisateur>> PostOrganisateur(Organisateur organisateur)
        {
            _context.Organisateur.Add(organisateur);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrganisateur", new { id = organisateur.IdUser }, organisateur);
        }

        // DELETE: api/Organisateurs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrganisateur(int id)
        {
            var organisateur = await _context.Organisateur.FindAsync(id);
            if (organisateur == null)
            {
                return NotFound();
            }

            _context.Organisateur.Remove(organisateur);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrganisateurExists(int id)
        {
            return _context.Organisateur.Any(e => e.IdUser == id);
        }
    }
}
