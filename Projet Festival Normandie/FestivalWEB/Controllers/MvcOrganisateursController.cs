using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FestivalAPI.Data;
using FestivalAPI.Models;
using FestivalWEB.ViewModels;
using wpfFestival.ControllersAPI;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace FestivalWEB.Controllers
{
    public class MvcOrganisateursController : Controller
    {
        private readonly FestivalAPIContext _context;

        public MvcOrganisateursController(FestivalAPIContext context)
        {
            _context = context;
        }

        // GET: MvcOrganisateurs
        public async Task<IActionResult> Index()
        {
            
            var festivalAPIContext = _context.Organisateurs.Include(o => o.Festival);
            return View(await festivalAPIContext.ToListAsync());
        }
      
        


        // GET: MvcOrganisateurs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organisateur = await _context.Organisateurs
                .Include(o => o.Festival)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.OrganisateurID == id);
            if (organisateur == null)
            {
                return NotFound();
            }

            return View(organisateur);
        }

        // GET: MvcOrganisateurs/Create
        public IActionResult Create()
        {
            PopulateFestivalsDropDownList();
            return View();
        }

        

        // POST: MvcOrganisateurs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrganisateurID,Nom,Prenom,Mot_de_passe,Email,FestivalID")] Organisateur organisateur)
        {
            if (ModelState.IsValid)
            {
                _context.Add(organisateur);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            PopulateFestivalsDropDownList();
            return View(organisateur);
        }

        // GET: MvcOrganisateurs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organisateur = await _context.Organisateurs
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.OrganisateurID == id);

            if (organisateur == null)
            {
                return NotFound();
            }
            PopulateFestivalsDropDownList(organisateur.FestivalID);
            return View(organisateur);
        }

        // POST: MvcOrganisateurs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organisateurToUpdate = await _context.Organisateurs
                .FirstOrDefaultAsync(c => c.OrganisateurID == id);

            if (await TryUpdateModelAsync<Organisateur>(organisateurToUpdate,
                "",
                c => c.Nom,c => c.Prenom, c => c.Email, c => c.Mot_de_passe , c => c.FestivalID ))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException /* ex */)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
            }
            PopulateFestivalsDropDownList(organisateurToUpdate.FestivalID);
            return View(organisateurToUpdate);
        }
        private void PopulateFestivalsDropDownList(object selectedFestival = null)
        {
            var festivalsQuery = from d in _context.Festivals
                                 orderby d.Nom_Festival
                                 select d;
            ViewBag.FestivalID = new SelectList(festivalsQuery.AsNoTracking(), "FestivalID", "Nom_Festival", selectedFestival);
        }
        // GET: MvcOrganisateurs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organisateur = await _context.Organisateurs
                .Include(o => o.Festival)
                .FirstOrDefaultAsync(m => m.OrganisateurID == id);
            if (organisateur == null)
            {
                return NotFound();
            }

            return View(organisateur);
        }

        // POST: MvcOrganisateurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var organisateur = await _context.Organisateurs.FindAsync(id);
            _context.Organisateurs.Remove(organisateur);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrganisateurExists(int id)
        {
            return _context.Organisateurs.Any(e => e.OrganisateurID == id);
        }

        public bool CheckLogin()
        {
            if (HttpContext.Session.GetString("Email") != null) return true;
            return false;
        }
    }
}
