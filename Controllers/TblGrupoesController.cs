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
    public class TblGrupoesController : Controller
    {
        private readonly EscuelaContext _context;

        public TblGrupoesController(EscuelaContext context)
        {
            _context = context;
        }

        // GET: TblGrupoes
        public async Task<IActionResult> Index()
        {
              return _context.TblGrupos != null ? 
                          View(await _context.TblGrupos.ToListAsync()) :
                          Problem("Entity set 'EscuelaContext.TblGrupos'  is null.");
        }

        // GET: TblGrupoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TblGrupos == null)
            {
                return NotFound();
            }

            var tblGrupo = await _context.TblGrupos
                .FirstOrDefaultAsync(m => m.IdGrupo == id);
            if (tblGrupo == null)
            {
                return NotFound();
            }

            return View(tblGrupo);
        }

        // GET: TblGrupoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblGrupoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdGrupo,NombreGrupo,Grado")] TblGrupo tblGrupo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblGrupo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblGrupo);
        }

        // GET: TblGrupoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TblGrupos == null)
            {
                return NotFound();
            }

            var tblGrupo = await _context.TblGrupos.FindAsync(id);
            if (tblGrupo == null)
            {
                return NotFound();
            }
            return View(tblGrupo);
        }

        // POST: TblGrupoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdGrupo,NombreGrupo,Grado")] TblGrupo tblGrupo)
        {
            if (id != tblGrupo.IdGrupo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblGrupo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblGrupoExists(tblGrupo.IdGrupo))
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
            return View(tblGrupo);
        }

        // GET: TblGrupoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TblGrupos == null)
            {
                return NotFound();
            }

            var tblGrupo = await _context.TblGrupos
                .FirstOrDefaultAsync(m => m.IdGrupo == id);
            if (tblGrupo == null)
            {
                return NotFound();
            }

            return View(tblGrupo);
        }

        // POST: TblGrupoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TblGrupos == null)
            {
                return Problem("Entity set 'EscuelaContext.TblGrupos'  is null.");
            }
            var tblGrupo = await _context.TblGrupos.FindAsync(id);
            if (tblGrupo != null)
            {
                _context.TblGrupos.Remove(tblGrupo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblGrupoExists(int id)
        {
          return (_context.TblGrupos?.Any(e => e.IdGrupo == id)).GetValueOrDefault();
        }
    }
}
