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
    public class OrganisateursController : ControllerBase
    {
        private readonly FestivalAPIContext _context;

        public OrganisateursController(FestivalAPIContext context)
        {
            _context = context;
        }

        // GET: api/Organisateurs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Organisateur>>> GetOrganisateurs()
        {
            return await _context.Organisateurs.ToListAsync();
        }

        // GET: api/Organisateurs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Organisateur>> GetOrganisateur(int id)
        {
            var organisateur = await _context.Organisateurs.FindAsync(id);

            if (organisateur == null)
            {
                return NotFound();
            }

            return organisateur;
        }

        [HttpGet("GetEmailOrganisateur/{Email}")]
        public async Task<ActionResult<Organisateur>> GetEmailOrganisateur(string email)
        {
            var orga = await _context.Organisateurs.FirstOrDefaultAsync(o => o.Email.Equals(email));
            if (orga == null)
            {
                return NotFound();
            }
            return orga;


        }
        [HttpGet("GetLoginOrganisateur/{Email}/{Mot_de_passe}")]
        public async Task<ActionResult<Organisateur>> GetLoginOrganisateur(string email, string mot_de_passe)
        {
            var user = await _context.Organisateurs.FirstOrDefaultAsync(u => u.Email.Equals(email) && u.Mot_de_passe.Equals(mot_de_passe));

            if (user == null)
            {
                return NotFound();
            }



            return user;
        }
        // PUT: api/Organisateurs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrganisateur(int id, Organisateur organisateur)
        {
            if (id != organisateur.OrganisateurID)
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
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Organisateur>> PostOrganisateur(Organisateur organisateur)
        {
            _context.Organisateurs.Add(organisateur);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrganisateur", new { id = organisateur.OrganisateurID }, organisateur);
        }

        // DELETE: api/Organisateurs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Organisateur>> DeleteOrganisateur(int id)
        {
            var organisateur = await _context.Organisateurs.FindAsync(id);
            if (organisateur == null)
            {
                return NotFound();
            }

            _context.Organisateurs.Remove(organisateur);
            await _context.SaveChangesAsync();

            return organisateur;
        }

        private bool OrganisateurExists(int id)
        {
            return _context.Organisateurs.Any(e => e.OrganisateurID == id);
        }
    }
}
