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
    public class MvcScenesController : Controller
    {
        private readonly FestivalAPIContext _context;

        public MvcScenesController(FestivalAPIContext context)
        {
            _context = context;
        }

        // GET: MvcScenes
        public async Task<IActionResult> Index()
        {
            var viewModel = new FestivalData();
            viewModel.Scenes = await _context.Scenes
                .Include(i => i.Artistes)
                .AsNoTracking()
                .ToListAsync();
            return View(viewModel);
        }

        // GET: MvcScenes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scene = await _context.Scenes
                .Include(s => s.Festival)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.SceneID == id);
            if (scene == null)
            {
                return NotFound();
            }

            return View(scene);
        }

        // GET: MvcScenes/Create
        public IActionResult Create()
        {
            PopulateFestivalsDropDownList();
            return View();
        }

        // POST: MvcScenes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SceneId,Nom_Scene,Capacite,Accessibilite,FestivalID")] Scene scene)
        {
            if (ModelState.IsValid)
            {
                _context.Add(scene);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            PopulateFestivalsDropDownList();
            return View(scene);
        }

        // GET: MvcScenes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scene = await _context.Scenes
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.SceneID == id);

            if (scene == null)
            {
                return NotFound();
            }
            PopulateFestivalsDropDownList(scene.FestivalID);
            return View(scene);
        }

        // POST: MvcScenes/Edit/5
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

            var sceneToUpdate = await _context.Scenes
                .FirstOrDefaultAsync(c => c.SceneID == id);

            if (await TryUpdateModelAsync<Scene>(sceneToUpdate,
                "",
                c => c.Capacite, c => c.FestivalID, c => c.Accessibilite))
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
            PopulateFestivalsDropDownList(sceneToUpdate.FestivalID);
            return View(sceneToUpdate);
        }

        private void PopulateFestivalsDropDownList(object selectedFestival = null)
        {
            var festivalsQuery = from d in _context.Festivals
                                 orderby d.Nom_Festival
                                 select d;
            ViewBag.FestivalID = new SelectList(festivalsQuery.AsNoTracking(), "FestivalID", "Nom_Festival", selectedFestival);
        }

        // GET: MvcScenes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scene = await _context.Scenes
                .Include(s => s.Festival)
                .FirstOrDefaultAsync(m => m.SceneID == id);
            if (scene == null)
            {
                return NotFound();
            }

            return View(scene);
        }

        // POST: MvcScenes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var scene = await _context.Scenes.FindAsync(id);
            _context.Scenes.Remove(scene);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SceneExists(int id)
        {
            return _context.Scenes.Any(e => e.SceneID == id);
        }
    }
}
