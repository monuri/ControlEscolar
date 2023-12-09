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
    public class TblProfesorsController : Controller
    {
        private readonly EscuelaContext _context;

        public TblProfesorsController(EscuelaContext context)
        {
            _context = context;
        }

        // GET: TblProfesors
        public async Task<IActionResult> Index()
        {
              return _context.TblProfesors != null ? 
                          View(await _context.TblProfesors.ToListAsync()) :
                          Problem("Entity set 'EscuelaContext.TblProfesors'  is null.");
        }

        // GET: TblProfesors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TblProfesors == null)
            {
                return NotFound();
            }

            var tblProfesor = await _context.TblProfesors
                .FirstOrDefaultAsync(m => m.IdProfesor == id);
            if (tblProfesor == null)
            {
                return NotFound();
            }

            return View(tblProfesor);
        }

        // GET: TblProfesors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblProfesors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProfesor,Nombre,Apellidos,Correo,Telefono")] TblProfesor tblProfesor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblProfesor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblProfesor);
        }

        // GET: TblProfesors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TblProfesors == null)
            {
                return NotFound();
            }

            var tblProfesor = await _context.TblProfesors.FindAsync(id);
            if (tblProfesor == null)
            {
                return NotFound();
            }
            return View(tblProfesor);
        }

        // POST: TblProfesors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProfesor,Nombre,Apellidos,Correo,Telefono")] TblProfesor tblProfesor)
        {
            if (id != tblProfesor.IdProfesor)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblProfesor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblProfesorExists(tblProfesor.IdProfesor))
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
            return View(tblProfesor);
        }

        // GET: TblProfesors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TblProfesors == null)
            {
                return NotFound();
            }

            var tblProfesor = await _context.TblProfesors
                .FirstOrDefaultAsync(m => m.IdProfesor == id);
            if (tblProfesor == null)
            {
                return NotFound();
            }

            return View(tblProfesor);
        }

        // POST: TblProfesors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TblProfesors == null)
            {
                return Problem("Entity set 'EscuelaContext.TblProfesors'  is null.");
            }
            var tblProfesor = await _context.TblProfesors.FindAsync(id);
            if (tblProfesor != null)
            {
                _context.TblProfesors.Remove(tblProfesor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblProfesorExists(int id)
        {
          return (_context.TblProfesors?.Any(e => e.IdProfesor == id)).GetValueOrDefault();
        }
    }
}
