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
    public class TblTipoCalificacionsController : Controller
    {
        private readonly EscuelaContext _context;

        public TblTipoCalificacionsController(EscuelaContext context)
        {
            _context = context;
        }

        // GET: TblTipoCalificacions
        public async Task<IActionResult> Index()
        {
              return _context.TblTipoCalificacions != null ? 
                          View(await _context.TblTipoCalificacions.ToListAsync()) :
                          Problem("Entity set 'EscuelaContext.TblTipoCalificacions'  is null.");
        }

        // GET: TblTipoCalificacions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TblTipoCalificacions == null)
            {
                return NotFound();
            }

            var tblTipoCalificacion = await _context.TblTipoCalificacions
                .FirstOrDefaultAsync(m => m.IdTipoCal == id);
            if (tblTipoCalificacion == null)
            {
                return NotFound();
            }

            return View(tblTipoCalificacion);
        }

        // GET: TblTipoCalificacions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblTipoCalificacions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipoCal,DescripcionCal")] TblTipoCalificacion tblTipoCalificacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblTipoCalificacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblTipoCalificacion);
        }

        // GET: TblTipoCalificacions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TblTipoCalificacions == null)
            {
                return NotFound();
            }

            var tblTipoCalificacion = await _context.TblTipoCalificacions.FindAsync(id);
            if (tblTipoCalificacion == null)
            {
                return NotFound();
            }
            return View(tblTipoCalificacion);
        }

        // POST: TblTipoCalificacions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTipoCal,DescripcionCal")] TblTipoCalificacion tblTipoCalificacion)
        {
            if (id != tblTipoCalificacion.IdTipoCal)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblTipoCalificacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblTipoCalificacionExists(tblTipoCalificacion.IdTipoCal))
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
            return View(tblTipoCalificacion);
        }

        // GET: TblTipoCalificacions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TblTipoCalificacions == null)
            {
                return NotFound();
            }

            var tblTipoCalificacion = await _context.TblTipoCalificacions
                .FirstOrDefaultAsync(m => m.IdTipoCal == id);
            if (tblTipoCalificacion == null)
            {
                return NotFound();
            }

            return View(tblTipoCalificacion);
        }

        // POST: TblTipoCalificacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TblTipoCalificacions == null)
            {
                return Problem("Entity set 'EscuelaContext.TblTipoCalificacions'  is null.");
            }
            var tblTipoCalificacion = await _context.TblTipoCalificacions.FindAsync(id);
            if (tblTipoCalificacion != null)
            {
                _context.TblTipoCalificacions.Remove(tblTipoCalificacion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblTipoCalificacionExists(int id)
        {
          return (_context.TblTipoCalificacions?.Any(e => e.IdTipoCal == id)).GetValueOrDefault();
        }
    }
}
