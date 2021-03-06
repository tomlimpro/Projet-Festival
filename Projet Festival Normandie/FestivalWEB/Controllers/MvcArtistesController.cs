using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;

using FestivalAPI.Models;
using FestivalAPI.Data;
using FestivalWEB.ViewModels;
using System.IO;

namespace FestivalWEB.Controllers
{
    public class MvcArtistesController : Controller
    {
        private readonly FestivalAPIContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public MvcArtistesController(FestivalAPIContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            webHostEnvironment = hostEnvironment;
        }

        // GET: MvcArtistes
        public async Task<IActionResult> Index()
        {
            var festivalAPIContext = _context.Artistes.Include(a => a.Scene);
            return View(await festivalAPIContext.ToListAsync());
        }

        public async Task<IActionResult> PageArtiste()
        {
            var festivalAPIContext = _context.Artistes.Include(a => a.Scene);
            return View(await festivalAPIContext.ToListAsync());
        }

        // GET: MvcArtistes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artiste = await _context.Artistes
                .Include(a => a.Scene)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ArtisteID == id);
            if (artiste == null)
            {
                return NotFound();
            }

            return View(artiste);
        }

        // GET: MvcArtistes/Create
        public IActionResult Create()
        {
            PopulateScenesDropDownList();
            return View();
        }
        
        /*
        // POST: MvcArtistes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ArtisteID,Nom_Artiste,Style_Artiste,Descriptif_Artiste,Pays_Artiste,ExtraitMusical_Artiste,UrlImage ,SceneID")] Artiste artiste)
        {
            if (ModelState.IsValid)
            {
                _context.Add(artiste);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            PopulateScenesDropDownList();
            return View(artiste);
        }
        */

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ArtisteViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = UploadedFile(model);
                Artiste artiste = new Artiste
                {

                    ArtisteID = model.ArtisteID,
                    Nom_Artiste = model.Nom_Artiste,
                    Style_Artiste = model.Style_Artiste,
                    Descriptif_Artiste = model.Descriptif_Artiste,
                    Pays_Artiste = model.Pays_Artiste,
                    ExtraitMusical_Artiste = model.ExtraitMusical_Artiste,
                    UrlImage = uniqueFileName,
                    SceneID = model.SceneID
                };
                _context.Add(artiste);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        private string UploadedFile(ArtisteViewModel model)
        {
            string uniqueFileName = null;
            if(model.UrlImage != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.UrlImage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.UrlImage.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        // GET: MvcArtistes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artiste = await _context.Artistes
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ArtisteID == id);

            if (artiste == null)
            {
                return NotFound();
            }
            PopulateScenesDropDownList(artiste.SceneID);
            return View(artiste);
        }

        // POST: MvcArtistes/Edit/5
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

            var artisteToUpdate = await _context.Artistes
                .FirstOrDefaultAsync(c => c.ArtisteID == id);

            if (await TryUpdateModelAsync<Artiste>(artisteToUpdate,
                "",
                c => c.Nom_Artiste, c => c.Style_Artiste, c => c.Descriptif_Artiste, c => c.Pays_Artiste, c => c.ExtraitMusical_Artiste,c => c.UrlImage, c => c.SceneID))
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
            PopulateScenesDropDownList(artisteToUpdate.SceneID);
            return View(artisteToUpdate);
        }
        private void PopulateScenesDropDownList(object selectedScene = null)
        {
            var scenesQuery = from d in _context.Scenes
                              orderby d.Nom_Scene
                              select d;
            ViewBag.SceneID = new SelectList(scenesQuery.AsNoTracking(), "SceneID", "Nom_Scene", selectedScene);
        }
        // GET: MvcArtistes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var artiste = await _context.Artistes
                .Include(a => a.Scene)
                .FirstOrDefaultAsync(m => m.ArtisteID == id);
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
            var artiste = await _context.Artistes.FindAsync(id);
            _context.Artistes.Remove(artiste);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        

        private bool ArtisteExists(int id)
        {
            return _context.Artistes.Any(e => e.ArtisteID == id);
        }
    }
}
