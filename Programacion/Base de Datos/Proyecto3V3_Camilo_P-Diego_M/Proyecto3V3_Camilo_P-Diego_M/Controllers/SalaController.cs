using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proyecto3V3_Camilo_P_Diego_M.Models;

namespace Proyecto3V3_Camilo_P_Diego_M.Controllers
{
    [Authorize]
    public class SalaController : Controller
    {
        private readonly Proyecto_U_3V3Context _context;

        public SalaController(Proyecto_U_3V3Context context)
        {
            _context = context;
        }

        // GET: Sala
        public async Task<IActionResult> Index()
        {
              return _context.Salas != null ? 
                          View(await _context.Salas.ToListAsync()) :
                          Problem("Entity set 'Proyecto_U_3V3Context.Salas'  is null.");
        }

        // GET: Sala/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Salas == null)
            {
                return NotFound();
            }

            var sala = await _context.Salas
                .FirstOrDefaultAsync(m => m.Idsala == id);
            if (sala == null)
            {
                return NotFound();
            }

            return View(sala);
        }

        // GET: Sala/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sala/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idsala,Código,Tipo,CapacidadDePacientes,NombreDePaciente,Fecha,HoraDeEntrada,HoraDeSalida,Diagnóstico,Tratamiento")] Sala sala)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sala);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sala);
        }

        // GET: Sala/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Salas == null)
            {
                return NotFound();
            }

            var sala = await _context.Salas.FindAsync(id);
            if (sala == null)
            {
                return NotFound();
            }
            return View(sala);
        }

        // POST: Sala/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idsala,Código,Tipo,CapacidadDePacientes,NombreDePaciente,Fecha,HoraDeEntrada,HoraDeSalida,Diagnóstico,Tratamiento")] Sala sala)
        {
            if (id != sala.Idsala)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sala);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalaExists(sala.Idsala))
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
            return View(sala);
        }

        // GET: Sala/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Salas == null)
            {
                return NotFound();
            }

            var sala = await _context.Salas
                .FirstOrDefaultAsync(m => m.Idsala == id);
            if (sala == null)
            {
                return NotFound();
            }

            return View(sala);
        }

        // POST: Sala/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Salas == null)
            {
                return Problem("Entity set 'Proyecto_U_3V3Context.Salas'  is null.");
            }
            var sala = await _context.Salas.FindAsync(id);
            if (sala != null)
            {
                _context.Salas.Remove(sala);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalaExists(int id)
        {
          return (_context.Salas?.Any(e => e.Idsala == id)).GetValueOrDefault();
        }
    }
}
