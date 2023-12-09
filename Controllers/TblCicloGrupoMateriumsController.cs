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
    public class TblCicloGrupoMateriumsController : Controller
    {
        private readonly EscuelaContext _context;

        public TblCicloGrupoMateriumsController(EscuelaContext context)
        {
            _context = context;
        }

        // GET: TblCicloGrupoMateriums
        public async Task<IActionResult> Index()
        {
            var escuelaContext = _context.TblCicloGrupoMateria.Include(t => t.FidCicloNavigation).Include(t => t.FidGrupoNavigation).Include(t => t.FidMateriaNavigation);
            return View(await escuelaContext.ToListAsync());
        }

        // GET: TblCicloGrupoMateriums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TblCicloGrupoMateria == null)
            {
                return NotFound();
            }

            var tblCicloGrupoMaterium = await _context.TblCicloGrupoMateria
                .Include(t => t.FidCicloNavigation)
                .Include(t => t.FidGrupoNavigation)
                .Include(t => t.FidMateriaNavigation)
                .FirstOrDefaultAsync(m => m.IdCicloxGrupoxMateria == id);
            if (tblCicloGrupoMaterium == null)
            {
                return NotFound();
            }

            return View(tblCicloGrupoMaterium);
        }

        // GET: TblCicloGrupoMateriums/Create
        public IActionResult Create()
        {
            ViewData["FidCiclo"] = new SelectList(_context.TblCiclos, "IdCiclo", "IdCiclo");
            ViewData["FidGrupo"] = new SelectList(_context.TblGrupos, "IdGrupo", "IdGrupo");
            ViewData["FidMateria"] = new SelectList(_context.TblMateria, "IdMateria", "IdMateria");
            return View();
        }

        // POST: TblCicloGrupoMateriums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCicloxGrupoxMateria,FidCiclo,FidGrupo,FidMateria")] TblCicloGrupoMaterium tblCicloGrupoMaterium)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblCicloGrupoMaterium);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FidCiclo"] = new SelectList(_context.TblCiclos, "IdCiclo", "IdCiclo", tblCicloGrupoMaterium.FidCiclo);
            ViewData["FidGrupo"] = new SelectList(_context.TblGrupos, "IdGrupo", "IdGrupo", tblCicloGrupoMaterium.FidGrupo);
            ViewData["FidMateria"] = new SelectList(_context.TblMateria, "IdMateria", "IdMateria", tblCicloGrupoMaterium.FidMateria);
            return View(tblCicloGrupoMaterium);
        }

        // GET: TblCicloGrupoMateriums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TblCicloGrupoMateria == null)
            {
                return NotFound();
            }

            var tblCicloGrupoMaterium = await _context.TblCicloGrupoMateria.FindAsync(id);
            if (tblCicloGrupoMaterium == null)
            {
                return NotFound();
            }
            ViewData["FidCiclo"] = new SelectList(_context.TblCiclos, "IdCiclo", "IdCiclo", tblCicloGrupoMaterium.FidCiclo);
            ViewData["FidGrupo"] = new SelectList(_context.TblGrupos, "IdGrupo", "IdGrupo", tblCicloGrupoMaterium.FidGrupo);
            ViewData["FidMateria"] = new SelectList(_context.TblMateria, "IdMateria", "IdMateria", tblCicloGrupoMaterium.FidMateria);
            return View(tblCicloGrupoMaterium);
        }

        // POST: TblCicloGrupoMateriums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCicloxGrupoxMateria,FidCiclo,FidGrupo,FidMateria")] TblCicloGrupoMaterium tblCicloGrupoMaterium)
        {
            if (id != tblCicloGrupoMaterium.IdCicloxGrupoxMateria)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblCicloGrupoMaterium);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblCicloGrupoMateriumExists(tblCicloGrupoMaterium.IdCicloxGrupoxMateria))
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
            ViewData["FidCiclo"] = new SelectList(_context.TblCiclos, "IdCiclo", "IdCiclo", tblCicloGrupoMaterium.FidCiclo);
            ViewData["FidGrupo"] = new SelectList(_context.TblGrupos, "IdGrupo", "IdGrupo", tblCicloGrupoMaterium.FidGrupo);
            ViewData["FidMateria"] = new SelectList(_context.TblMateria, "IdMateria", "IdMateria", tblCicloGrupoMaterium.FidMateria);
            return View(tblCicloGrupoMaterium);
        }

        // GET: TblCicloGrupoMateriums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TblCicloGrupoMateria == null)
            {
                return NotFound();
            }

            var tblCicloGrupoMaterium = await _context.TblCicloGrupoMateria
                .Include(t => t.FidCicloNavigation)
                .Include(t => t.FidGrupoNavigation)
                .Include(t => t.FidMateriaNavigation)
                .FirstOrDefaultAsync(m => m.IdCicloxGrupoxMateria == id);
            if (tblCicloGrupoMaterium == null)
            {
                return NotFound();
            }

            return View(tblCicloGrupoMaterium);
        }

        // POST: TblCicloGrupoMateriums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TblCicloGrupoMateria == null)
            {
                return Problem("Entity set 'EscuelaContext.TblCicloGrupoMateria'  is null.");
            }
            var tblCicloGrupoMaterium = await _context.TblCicloGrupoMateria.FindAsync(id);
            if (tblCicloGrupoMaterium != null)
            {
                _context.TblCicloGrupoMateria.Remove(tblCicloGrupoMaterium);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblCicloGrupoMateriumExists(int id)
        {
          return (_context.TblCicloGrupoMateria?.Any(e => e.IdCicloxGrupoxMateria == id)).GetValueOrDefault();
        }
    }
}
