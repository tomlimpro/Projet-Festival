using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FestivalAPI.Data;
using FestivalAPI.Models;

namespace FestivalWEB.Controllers
{
    public class MvcHebergementsController : Controller
    {
        private readonly FestivalAPIContext _context;

        public MvcHebergementsController(FestivalAPIContext context)
        {
            _context = context;
        }

        // GET: MvcHebergements
        public async Task<IActionResult> Index()
        {
            var festivalAPIContext = _context.Hebergements.Include(h => h.Festival);
            return View(await festivalAPIContext.ToListAsync());
        }

        // GET: MvcHebergements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hebergement = await _context.Hebergements
                .Include(h => h.Festival)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.HebergementID == id);
            if (hebergement == null)
            {
                return NotFound();
            }

            return View(hebergement);
        }

        // GET: MvcHebergements/Create
        public IActionResult Create()
        {
            PopulateFestivalsDropDownList();
            return View();
        }

        // POST: MvcHebergements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HebergementID,TypeHebergement,LienHebergement,FestivalID")] Hebergement hebergement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hebergement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            PopulateFestivalsDropDownList();
            return View(hebergement);
        }

        // GET: MvcHebergements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hebergement = await _context.Hebergements
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.HebergementID == id);

            if (hebergement == null)
            {
                return NotFound();
            }
            PopulateFestivalsDropDownList(hebergement.FestivalID);
            return View(hebergement);
        }

        // POST: MvcHebergements/Edit/5
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

            var hebergementToUpdate = await _context.Hebergements
                .FirstOrDefaultAsync(c => c.HebergementID == id);

            if (await TryUpdateModelAsync<Hebergement>(hebergementToUpdate,
                "",
                c => c.TypeHebergement, c => c.FestivalID, c => c.LienHebergement))
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
            PopulateFestivalsDropDownList(hebergementToUpdate.FestivalID);
            return View(hebergementToUpdate);
        }
        private void PopulateFestivalsDropDownList(object selectedFestival = null)
        {
            var festivalsQuery = from d in _context.Festivals
                                 orderby d.Nom_Festival
                                 select d;
            ViewBag.FestivalID = new SelectList(festivalsQuery.AsNoTracking(), "FestivalID", "Nom_Festival", selectedFestival);
        }
        // GET: MvcHebergements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hebergement = await _context.Hebergements
                .Include(h => h.Festival)
                .FirstOrDefaultAsync(m => m.HebergementID == id);
            if (hebergement == null)
            {
                return NotFound();
            }

            return View(hebergement);
        }

        // POST: MvcHebergements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hebergement = await _context.Hebergements.FindAsync(id);
            _context.Hebergements.Remove(hebergement);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HebergementExists(int id)
        {
            return _context.Hebergements.Any(e => e.HebergementID == id);
        }
    }
}
