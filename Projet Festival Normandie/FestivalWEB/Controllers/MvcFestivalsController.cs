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
    public class MvcFestivalsController : Controller
    {
        private readonly FestivalAPIContext _context;

        public MvcFestivalsController(FestivalAPIContext context)
        {
            _context = context;
        }

        // GET: MvcFestivals
        public async Task<IActionResult> Index()
        {
            var viewModel = new FestivalData();
            viewModel.Festi = await _context.Festivals
                .Include(i => i.Organisateur)
                .Include(i => i.Tarif)
                .Include(i => i.Hebergement)
                .Include(i => i.Scene)
                    .ThenInclude(i => i.Artistes)
                .AsNoTracking()
                .ToListAsync();
            return View(viewModel);
        }
        
    // GET: MvcFestivals/Details/5
    public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var festival = await _context.Festivals
                .FirstOrDefaultAsync(m => m.FestivalID == id);
            if (festival == null)
            {
                return NotFound();
            }

            return View(festival);
        }

        // GET: MvcFestivals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MvcFestivals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FestivalID,Nom_Festival,Ville,Description,Logo,DateDebut,DateFin")] Festival festival)
        {
            if (ModelState.IsValid)
            {
                _context.Add(festival);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(festival);
        }

        // GET: MvcFestivals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var festival = await _context.Festivals.FindAsync(id);
            if (festival == null)
            {
                return NotFound();
            }
            return View(festival);
        }

        // POST: MvcFestivals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FestivalID,Nom_Festival,Ville,Description,Logo,DateDebut,DateFin")] Festival festival)
        {
            if (id != festival.FestivalID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(festival);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FestivalExists(festival.FestivalID))
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
            return View(festival);
        }

        // GET: MvcFestivals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var festival = await _context.Festivals
                .FirstOrDefaultAsync(m => m.FestivalID == id);
            if (festival == null)
            {
                return NotFound();
            }

            return View(festival);
        }

        // POST: MvcFestivals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var festival = await _context.Festivals.FindAsync(id);
            _context.Festivals.Remove(festival);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FestivalExists(int id)
        {
            return _context.Festivals.Any(e => e.FestivalID == id);
        }
    }
}
