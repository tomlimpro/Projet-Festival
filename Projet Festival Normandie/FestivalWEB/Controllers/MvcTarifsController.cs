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
    public class MvcTarifsController : Controller
    {
        private readonly FestivalAPIContext _context;

        public MvcTarifsController(FestivalAPIContext context)
        {
            _context = context;
        }

        // GET: MvcTarifs
        public async Task<IActionResult> Index()
        {
            var festivalAPIContext = _context.Tarifs.Include(t => t.Festival);
            return View(await festivalAPIContext.ToListAsync());
        }

        // GET: MvcTarifs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarif = await _context.Tarifs
                .Include(t => t.Festival)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.TarifID == id);
            if (tarif == null)
            {
                return NotFound();
            }

            return View(tarif);
        }

        // GET: MvcTarifs/Create
        public IActionResult Create()
        {
            PopulateFestivalsDropDownList();
            return View();
        }

        // POST: MvcTarifs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TarifID,NomTarif,PrixTarif,FestivalID")] Tarif tarif)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tarif);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            PopulateFestivalsDropDownList();
            return View(tarif);
        }

        // GET: MvcTarifs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarif = await _context.Tarifs
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.TarifID == id);

            if (tarif == null)
            {
                return NotFound();
            }
            PopulateFestivalsDropDownList(tarif.FestivalID);
            return View(tarif);
        }

        // POST: MvcTarifs/Edit/5
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

            var tarifToUpdate = await _context.Tarifs
                .FirstOrDefaultAsync(c => c.TarifID == id);

            if (await TryUpdateModelAsync<Tarif>(tarifToUpdate,
                "",
                c => c.NomTarif, c => c.PrixTarif, c => c.FestivalID))
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
            PopulateFestivalsDropDownList(tarifToUpdate.FestivalID);
            return View(tarifToUpdate);
        }

        private void PopulateFestivalsDropDownList(object selectedFestival = null)
        {
            var festivalsQuery = from d in _context.Festivals
                                 orderby d.Nom_Festival
                                 select d;
            ViewBag.FestivalID = new SelectList(festivalsQuery.AsNoTracking(), "FestivalID", "Nom_Festival", selectedFestival);
        }

        // GET: MvcTarifs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarif = await _context.Tarifs
                .Include(t => t.Festival)
                .FirstOrDefaultAsync(m => m.TarifID == id);
            if (tarif == null)
            {
                return NotFound();
            }

            return View(tarif);
        }

        // POST: MvcTarifs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tarif = await _context.Tarifs.FindAsync(id);
            _context.Tarifs.Remove(tarif);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TarifExists(int id)
        {
            return _context.Tarifs.Any(e => e.TarifID == id);
        }
    }
}
