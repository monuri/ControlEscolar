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
    public class TblMateriumsController : Controller
    {
        private readonly EscuelaContext _context;

        public TblMateriumsController(EscuelaContext context)
        {
            _context = context;
        }

        // GET: TblMateriums
        public async Task<IActionResult> Index()
        {
              return _context.TblMateria != null ? 
                          View(await _context.TblMateria.ToListAsync()) :
                          Problem("Entity set 'EscuelaContext.TblMateria'  is null.");
        }

        // GET: TblMateriums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TblMateria == null)
            {
                return NotFound();
            }

            var tblMaterium = await _context.TblMateria
                .FirstOrDefaultAsync(m => m.IdMateria == id);
            if (tblMaterium == null)
            {
                return NotFound();
            }

            return View(tblMaterium);
        }

        // GET: TblMateriums/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblMateriums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMateria,NombreMateria")] TblMaterium tblMaterium)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblMaterium);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblMaterium);
        }

        // GET: TblMateriums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TblMateria == null)
            {
                return NotFound();
            }

            var tblMaterium = await _context.TblMateria.FindAsync(id);
            if (tblMaterium == null)
            {
                return NotFound();
            }
            return View(tblMaterium);
        }

        // POST: TblMateriums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMateria,NombreMateria")] TblMaterium tblMaterium)
        {
            if (id != tblMaterium.IdMateria)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblMaterium);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblMateriumExists(tblMaterium.IdMateria))
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
            return View(tblMaterium);
        }

        // GET: TblMateriums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TblMateria == null)
            {
                return NotFound();
            }

            var tblMaterium = await _context.TblMateria
                .FirstOrDefaultAsync(m => m.IdMateria == id);
            if (tblMaterium == null)
            {
                return NotFound();
            }

            return View(tblMaterium);
        }

        // POST: TblMateriums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TblMateria == null)
            {
                return Problem("Entity set 'EscuelaContext.TblMateria'  is null.");
            }
            var tblMaterium = await _context.TblMateria.FindAsync(id);
            if (tblMaterium != null)
            {
                _context.TblMateria.Remove(tblMaterium);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblMateriumExists(int id)
        {
          return (_context.TblMateria?.Any(e => e.IdMateria == id)).GetValueOrDefault();
        }
    }
}
