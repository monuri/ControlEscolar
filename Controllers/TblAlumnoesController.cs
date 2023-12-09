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
    public class TblAlumnoesController : Controller
    {
        private readonly EscuelaContext _context;

        public TblAlumnoesController(EscuelaContext context)
        {
            _context = context;
        }

        // GET: TblAlumnoes
        public async Task<IActionResult> Index()
        {
              return _context.TblAlumnos != null ? 
                          View(await _context.TblAlumnos.ToListAsync()) :
                          Problem("Entity set 'EscuelaContext.TblAlumnos'  is null.");
        }

        // GET: TblAlumnoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TblAlumnos == null)
            {
                return NotFound();
            }

            var tblAlumno = await _context.TblAlumnos
                .FirstOrDefaultAsync(m => m.IdAlumno == id);
            if (tblAlumno == null)
            {
                return NotFound();
            }

            return View(tblAlumno);
        }

        // GET: TblAlumnoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblAlumnoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAlumno,Nombre,Apellidos,Correo,Telefono")] TblAlumno tblAlumno)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblAlumno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblAlumno);
        }

        // GET: TblAlumnoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TblAlumnos == null)
            {
                return NotFound();
            }

            var tblAlumno = await _context.TblAlumnos.FindAsync(id);
            if (tblAlumno == null)
            {
                return NotFound();
            }
            return View(tblAlumno);
        }

        // POST: TblAlumnoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAlumno,Nombre,Apellidos,Correo,Telefono")] TblAlumno tblAlumno)
        {
            if (id != tblAlumno.IdAlumno)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblAlumno);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblAlumnoExists(tblAlumno.IdAlumno))
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
            return View(tblAlumno);
        }

        // GET: TblAlumnoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TblAlumnos == null)
            {
                return NotFound();
            }

            var tblAlumno = await _context.TblAlumnos
                .FirstOrDefaultAsync(m => m.IdAlumno == id);
            if (tblAlumno == null)
            {
                return NotFound();
            }

            return View(tblAlumno);
        }

        // POST: TblAlumnoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TblAlumnos == null)
            {
                return Problem("Entity set 'EscuelaContext.TblAlumnos'  is null.");
            }
            var tblAlumno = await _context.TblAlumnos.FindAsync(id);
            if (tblAlumno != null)
            {
                _context.TblAlumnos.Remove(tblAlumno);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblAlumnoExists(int id)
        {
          return (_context.TblAlumnos?.Any(e => e.IdAlumno == id)).GetValueOrDefault();
        }
    }
}
