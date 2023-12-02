using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TP4.Data;
using TP4.Models;

namespace TP4.Controllers
{
    public class MatieresController : Controller
    {
        private readonly TP4Context _context;

        public MatieresController(TP4Context context)
        {
            _context = context;
        }

        // GET: Matieres
        public async Task<IActionResult> Index()
        {

            // LINK SQL 
            var res = from m in _context.Matiére
                      select m;
              return res != null ? 
                          View(await res.ToListAsync()) :
                          Problem("Entity set 'TP4Context.Matiére'  is null.");
            // LINK FONCTIONNEL 
            var res1 = _context.Matiére.Where(x => x.Id == 1).OrderByDescending(x => x.LibMatiere);
        }

        // GET: Matieres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Matiére == null)
            {
                return NotFound();
            }

            var matiere = await _context.Matiére
                .FirstOrDefaultAsync(m => m.Id == id);
            if (matiere == null)
            {
                return NotFound();
            }

            return View(matiere);
        }

        // GET: Matieres/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Matieres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LibMatiere")] Matiere matiere)
        {
            if (ModelState.IsValid)
            {
                _context.Add(matiere);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(matiere);
        }

        // GET: Matieres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Matiére == null)
            {
                return NotFound();
            }

            var matiere = await _context.Matiére.FindAsync(id);
            if (matiere == null)
            {
                return NotFound();
            }
            return View(matiere);
        }

        // POST: Matieres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LibMatiere")] Matiere matiere)
        {
            if (id != matiere.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(matiere);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MatiereExists(matiere.Id))
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
            return View(matiere);
        }

        // GET: Matieres/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Matiére == null)
            {
                return NotFound();
            }

            var matiere = await _context.Matiére
                .FirstOrDefaultAsync(m => m.Id == id);
            if (matiere == null)
            {
                return NotFound();
            }

            return View(matiere);
        }

        // POST: Matieres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Matiére == null)
            {
                return Problem("Entity set 'TP4Context.Matiére'  is null.");
            }
            var matiere = await _context.Matiére.FindAsync(id);
            if (matiere != null)
            {
                _context.Matiére.Remove(matiere);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MatiereExists(int id)
        {
          return (_context.Matiére?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
