using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using APIFestival.Models;
using WebFestival.Data;

namespace WebFestival.Controllers
{
    public class OrganisateursController : Controller
    {
        private readonly WebFestivalContext _context;

        public OrganisateursController(WebFestivalContext context)
        {
            _context = context;
        }

        // GET: Organisateurs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Organisateur.ToListAsync());
        }

        // GET: Organisateurs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organisateur = await _context.Organisateur
                .FirstOrDefaultAsync(m => m.IdUser == id);
            if (organisateur == null)
            {
                return NotFound();
            }

            return View(organisateur);
        }

        // GET: Organisateurs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Organisateurs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUser,Nom,Prenom,Mot_de_passe,Email")] Organisateur organisateur)
        {
            if (ModelState.IsValid)
            {
                _context.Add(organisateur);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(organisateur);
        }

        // GET: Organisateurs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organisateur = await _context.Organisateur.FindAsync(id);
            if (organisateur == null)
            {
                return NotFound();
            }
            return View(organisateur);
        }

        // POST: Organisateurs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdUser,Nom,Prenom,Mot_de_passe,Email")] Organisateur organisateur)
        {
            if (id != organisateur.IdUser)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(organisateur);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrganisateurExists(organisateur.IdUser))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(organisateur);
        }

        // GET: Organisateurs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organisateur = await _context.Organisateur
                .FirstOrDefaultAsync(m => m.IdUser == id);
            if (organisateur == null)
            {
                return NotFound();
            }

            return View(organisateur);
        }

        // POST: Organisateurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var organisateur = await _context.Organisateur.FindAsync(id);
            _context.Organisateur.Remove(organisateur);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrganisateurExists(int id)
        {
            return _context.Organisateur.Any(e => e.IdUser == id);
        }
    }
}
