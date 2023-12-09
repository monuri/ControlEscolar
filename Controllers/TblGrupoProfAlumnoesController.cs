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
    public class TblGrupoProfAlumnoesController : Controller
    {
        private readonly EscuelaContext _context;

        public TblGrupoProfAlumnoesController(EscuelaContext context)
        {
            _context = context;
        }

        // GET: TblGrupoProfAlumnoes
        public async Task<IActionResult> Index()
        {
            var escuelaContext = _context.TblGrupoProfAlumnos.Include(t => t.FidAlumnoNavigation).Include(t => t.FidGrupoNavigation).Include(t => t.FidProfesorNavigation);
            return View(await escuelaContext.ToListAsync());
        }

        // GET: TblGrupoProfAlumnoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TblGrupoProfAlumnos == null)
            {
                return NotFound();
            }

            var tblGrupoProfAlumno = await _context.TblGrupoProfAlumnos
                .Include(t => t.FidAlumnoNavigation)
                .Include(t => t.FidGrupoNavigation)
                .Include(t => t.FidProfesorNavigation)
                .FirstOrDefaultAsync(m => m.IdGrupoProfAlumno == id);
            if (tblGrupoProfAlumno == null)
            {
                return NotFound();
            }

            return View(tblGrupoProfAlumno);
        }

        // GET: TblGrupoProfAlumnoes/Create
        public IActionResult Create()
        {
            ViewData["FidAlumno"] = new SelectList(_context.TblAlumnos, "IdAlumno", "IdAlumno");
            ViewData["FidGrupo"] = new SelectList(_context.TblGrupos, "IdGrupo", "IdGrupo");
            ViewData["FidProfesor"] = new SelectList(_context.TblProfesors, "IdProfesor", "IdProfesor");
            return View();
        }

        // POST: TblGrupoProfAlumnoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdGrupoProfAlumno,FidGrupo,FidProfesor,FidAlumno")] TblGrupoProfAlumno tblGrupoProfAlumno)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblGrupoProfAlumno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FidAlumno"] = new SelectList(_context.TblAlumnos, "IdAlumno", "IdAlumno", tblGrupoProfAlumno.FidAlumno);
            ViewData["FidGrupo"] = new SelectList(_context.TblGrupos, "IdGrupo", "IdGrupo", tblGrupoProfAlumno.FidGrupo);
            ViewData["FidProfesor"] = new SelectList(_context.TblProfesors, "IdProfesor", "IdProfesor", tblGrupoProfAlumno.FidProfesor);
            return View(tblGrupoProfAlumno);
        }

        // GET: TblGrupoProfAlumnoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TblGrupoProfAlumnos == null)
            {
                return NotFound();
            }

            var tblGrupoProfAlumno = await _context.TblGrupoProfAlumnos.FindAsync(id);
            if (tblGrupoProfAlumno == null)
            {
                return NotFound();
            }
            ViewData["FidAlumno"] = new SelectList(_context.TblAlumnos, "IdAlumno", "IdAlumno", tblGrupoProfAlumno.FidAlumno);
            ViewData["FidGrupo"] = new SelectList(_context.TblGrupos, "IdGrupo", "IdGrupo", tblGrupoProfAlumno.FidGrupo);
            ViewData["FidProfesor"] = new SelectList(_context.TblProfesors, "IdProfesor", "IdProfesor", tblGrupoProfAlumno.FidProfesor);
            return View(tblGrupoProfAlumno);
        }

        // POST: TblGrupoProfAlumnoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdGrupoProfAlumno,FidGrupo,FidProfesor,FidAlumno")] TblGrupoProfAlumno tblGrupoProfAlumno)
        {
            if (id != tblGrupoProfAlumno.IdGrupoProfAlumno)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblGrupoProfAlumno);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblGrupoProfAlumnoExists(tblGrupoProfAlumno.IdGrupoProfAlumno))
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
            ViewData["FidAlumno"] = new SelectList(_context.TblAlumnos, "IdAlumno", "IdAlumno", tblGrupoProfAlumno.FidAlumno);
            ViewData["FidGrupo"] = new SelectList(_context.TblGrupos, "IdGrupo", "IdGrupo", tblGrupoProfAlumno.FidGrupo);
            ViewData["FidProfesor"] = new SelectList(_context.TblProfesors, "IdProfesor", "IdProfesor", tblGrupoProfAlumno.FidProfesor);
            return View(tblGrupoProfAlumno);
        }

        // GET: TblGrupoProfAlumnoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TblGrupoProfAlumnos == null)
            {
                return NotFound();
            }

            var tblGrupoProfAlumno = await _context.TblGrupoProfAlumnos
                .Include(t => t.FidAlumnoNavigation)
                .Include(t => t.FidGrupoNavigation)
                .Include(t => t.FidProfesorNavigation)
                .FirstOrDefaultAsync(m => m.IdGrupoProfAlumno == id);
            if (tblGrupoProfAlumno == null)
            {
                return NotFound();
            }

            return View(tblGrupoProfAlumno);
        }

        // POST: TblGrupoProfAlumnoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TblGrupoProfAlumnos == null)
            {
                return Problem("Entity set 'EscuelaContext.TblGrupoProfAlumnos'  is null.");
            }
            var tblGrupoProfAlumno = await _context.TblGrupoProfAlumnos.FindAsync(id);
            if (tblGrupoProfAlumno != null)
            {
                _context.TblGrupoProfAlumnos.Remove(tblGrupoProfAlumno);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblGrupoProfAlumnoExists(int id)
        {
          return (_context.TblGrupoProfAlumnos?.Any(e => e.IdGrupoProfAlumno == id)).GetValueOrDefault();
        }
    }
}
