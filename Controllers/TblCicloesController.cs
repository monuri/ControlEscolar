using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ControlEscolar.Models;

namespace ControlEscolar.Controllers
{
    public class TblCicloesController : Controller
    {
        private readonly EscuelaContext _context;

        public TblCicloesController(EscuelaContext context)
        {
            _context = context;
        }

        // GET: TblCicloes
        public async Task<IActionResult> Index()
        {
              return _context.TblCiclos != null ? 
                          View(await _context.TblCiclos.ToListAsync()) :
                          Problem("Entity set 'EscuelaContext.TblCiclos'  is null.");
        }

        // GET: TblCicloes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TblCiclos == null)
            {
                return NotFound();
            }

            var tblCiclo = await _context.TblCiclos
                .FirstOrDefaultAsync(m => m.IdCiclo == id);
            if (tblCiclo == null)
            {
                return NotFound();
            }

            return View(tblCiclo);
        }

        // GET: TblCicloes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblCicloes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCiclo,NombreCiclo,CveCiclo")] TblCiclo tblCiclo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblCiclo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblCiclo);
        }

        // GET: TblCicloes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TblCiclos == null)
            {
                return NotFound();
            }

            var tblCiclo = await _context.TblCiclos.FindAsync(id);
            if (tblCiclo == null)
            {
                return NotFound();
            }
            return View(tblCiclo);
        }

        // POST: TblCicloes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCiclo,NombreCiclo,CveCiclo")] TblCiclo tblCiclo)
        {
            if (id != tblCiclo.IdCiclo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblCiclo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblCicloExists(tblCiclo.IdCiclo))
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
            return View(tblCiclo);
        }

        // GET: TblCicloes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TblCiclos == null)
            {
                return NotFound();
            }

            var tblCiclo = await _context.TblCiclos
                .FirstOrDefaultAsync(m => m.IdCiclo == id);
            if (tblCiclo == null)
            {
                return NotFound();
            }

            return View(tblCiclo);
        }

        // POST: TblCicloes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TblCiclos == null)
            {
                return Problem("Entity set 'EscuelaContext.TblCiclos'  is null.");
            }
            var tblCiclo = await _context.TblCiclos.FindAsync(id);
            if (tblCiclo != null)
            {
                _context.TblCiclos.Remove(tblCiclo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblCicloExists(int id)
        {
          return (_context.TblCiclos?.Any(e => e.IdCiclo == id)).GetValueOrDefault();
        }
    }
}
