﻿using System;
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
    public class MvcArtistesController : Controller
    {
        private readonly FestivalAPIContext _context;

        public MvcArtistesController(FestivalAPIContext context)
        {
            _context = context;
        }

        // GET: MvcArtistes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Artiste.ToListAsync());
        }

        // GET: MvcArtistes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artiste = await _context.Artiste
                .FirstOrDefaultAsync(m => m.ArtisteId == id);
            if (artiste == null)
            {
                return NotFound();
            }

            return View(artiste);
        }

        // GET: MvcArtistes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MvcArtistes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ArtisteId,Nom_Artiste,Style_Artiste,Descriptif_Artiste,Pays_Artiste,ExtraitMusical_Artiste")] Artiste artiste)
        {
            if (ModelState.IsValid)
            {
                _context.Add(artiste);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(artiste);
        }

        // GET: MvcArtistes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artiste = await _context.Artiste.FindAsync(id);
            if (artiste == null)
            {
                return NotFound();
            }
            return View(artiste);
        }

        // POST: MvcArtistes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ArtisteId,Nom_Artiste,Style_Artiste,Descriptif_Artiste,Pays_Artiste,ExtraitMusical_Artiste")] Artiste artiste)
        {
            if (id != artiste.ArtisteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(artiste);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArtisteExists(artiste.ArtisteId))
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
            return View(artiste);
        }

        // GET: MvcArtistes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artiste = await _context.Artiste
                .FirstOrDefaultAsync(m => m.ArtisteId == id);
            if (artiste == null)
            {
                return NotFound();
            }

            return View(artiste);
        }

        // POST: MvcArtistes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var artiste = await _context.Artiste.FindAsync(id);
            _context.Artiste.Remove(artiste);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArtisteExists(int id)
        {
            return _context.Artiste.Any(e => e.ArtisteId == id);
        }
    }
}