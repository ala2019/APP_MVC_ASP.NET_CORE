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
    public class InscriptionsController : Controller
    {
        private readonly TP4Context _context;

        public InscriptionsController(TP4Context context)
        {
            _context = context;
        }

        // GET: Inscriptions
        public async Task<IActionResult> Index()
        {
            var tP4Context = _context.Inscription.Include(i => i.Etudiant).Include(i => i.Matiere);
            return View(await tP4Context.ToListAsync());
        }

        // GET: Inscriptions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Inscription == null)
            {
                return NotFound();
            }

            var inscription = await _context.Inscription
                .Include(i => i.Etudiant)
                .Include(i => i.Matiere)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inscription == null)
            {
                return NotFound();
            }

            return View(inscription);
        }

        // GET: Inscriptions/Create
        public IActionResult Create()
        {
            ViewData["EtudiantId"] = new SelectList(_context.Etudiant, "Id", "NomPrenom");
            ViewData["MatiereId"] = new SelectList(_context.Matiére, "Id", "LibMatiere");
            return View();
        }

        // POST: Inscriptions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MatiereId,EtudiantId")] Inscription inscription)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inscription);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EtudiantId"] = new SelectList(_context.Etudiant, "Id", "Nom", inscription.EtudiantId);
            ViewData["MatiereId"] = new SelectList(_context.Matiére, "Id", "LibMatiere", inscription.MatiereId);
            return View(inscription);
        }

        // GET: Inscriptions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Inscription == null)
            {
                return NotFound();
            }

            var inscription = await _context.Inscription.FindAsync(id);
            if (inscription == null)
            {
                return NotFound();
            }
            ViewData["EtudiantId"] = new SelectList(_context.Etudiant, "Id", "Nom", inscription.EtudiantId);
            ViewData["MatiereId"] = new SelectList(_context.Matiére, "Id", "LibMatiere", inscription.MatiereId);
            return View(inscription);
        }

        // POST: Inscriptions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MatiereId,EtudiantId")] Inscription inscription)
        {
            if (id != inscription.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inscription);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InscriptionExists(inscription.Id))
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
            ViewData["EtudiantId"] = new SelectList(_context.Etudiant, "Id", "Nom", inscription.EtudiantId);
            ViewData["MatiereId"] = new SelectList(_context.Matiére, "Id", "LibMatiere", inscription.MatiereId);
            return View(inscription);
        }

        // GET: Inscriptions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Inscription == null)
            {
                return NotFound();
            }

            var inscription = await _context.Inscription
                .Include(i => i.Etudiant)
                .Include(i => i.Matiere)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inscription == null)
            {
                return NotFound();
            }

            return View(inscription);
        }

        // POST: Inscriptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Inscription == null)
            {
                return Problem("Entity set 'TP4Context.Inscription'  is null.");
            }
            var inscription = await _context.Inscription.FindAsync(id);
            if (inscription != null)
            {
                _context.Inscription.Remove(inscription);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InscriptionExists(int id)
        {
          return (_context.Inscription?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
