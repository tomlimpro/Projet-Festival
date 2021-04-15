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
            return View(await _context.Festival.ToListAsync());
        }

        // GET: MvcFestivals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var festival = await _context.Festival
                .FirstOrDefaultAsync(m => m.FestivalId == id);
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
        public async Task<IActionResult> Create([Bind("FestivalId,Nom_Festival,Lieu")] Festival festival)
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

            var festival = await _context.Festival.FindAsync(id);
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
        public async Task<IActionResult> Edit(int id, [Bind("FestivalId,Nom_Festival,Lieu")] Festival festival)
        {
            if (id != festival.FestivalId)
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
                    if (!FestivalExists(festival.FestivalId))
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

            var festival = await _context.Festival
                .FirstOrDefaultAsync(m => m.FestivalId == id);
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
            var festival = await _context.Festival.FindAsync(id);
            _context.Festival.Remove(festival);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FestivalExists(int id)
        {
            return _context.Festival.Any(e => e.FestivalId == id);
        }
    }
}
