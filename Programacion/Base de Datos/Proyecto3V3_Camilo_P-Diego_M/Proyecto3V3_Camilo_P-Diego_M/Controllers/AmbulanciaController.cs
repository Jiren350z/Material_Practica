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
    public class AmbulanciaController : Controller
    {
        private readonly Proyecto_U_3V3Context _context;

        public AmbulanciaController(Proyecto_U_3V3Context context)
        {
            _context = context;
        }

        // GET: Ambulancia
        public async Task<IActionResult> Index()
        {
              return _context.Ambulancia != null ? 
                          View(await _context.Ambulancia.ToListAsync()) :
                          Problem("Entity set 'Proyecto_U_3V3Context.Ambulancia'  is null.");
        }

        // GET: Ambulancia/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Ambulancia == null)
            {
                return NotFound();
            }

            var ambulancium = await _context.Ambulancia
                .FirstOrDefaultAsync(m => m.Idamb == id);
            if (ambulancium == null)
            {
                return NotFound();
            }

            return View(ambulancium);
        }

        // GET: Ambulancia/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ambulancia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idamb,Patente,Marca,Modelo,UbicaciónActual,Disponibilidad,HoraDeLlamada,DíaDeLlamada,MesDeLlamada,AñoDeLlamada")] Ambulancium ambulancium)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ambulancium);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ambulancium);
        }

        // GET: Ambulancia/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Ambulancia == null)
            {
                return NotFound();
            }

            var ambulancium = await _context.Ambulancia.FindAsync(id);
            if (ambulancium == null)
            {
                return NotFound();
            }
            return View(ambulancium);
        }

        // POST: Ambulancia/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idamb,Patente,Marca,Modelo,UbicaciónActual,Disponibilidad,HoraDeLlamada,DíaDeLlamada,MesDeLlamada,AñoDeLlamada")] Ambulancium ambulancium)
        {
            if (id != ambulancium.Idamb)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ambulancium);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AmbulanciumExists(ambulancium.Idamb))
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
            return View(ambulancium);
        }

        // GET: Ambulancia/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Ambulancia == null)
            {
                return NotFound();
            }

            var ambulancium = await _context.Ambulancia
                .FirstOrDefaultAsync(m => m.Idamb == id);
            if (ambulancium == null)
            {
                return NotFound();
            }

            return View(ambulancium);
        }

        // POST: Ambulancia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Ambulancia == null)
            {
                return Problem("Entity set 'Proyecto_U_3V3Context.Ambulancia'  is null.");
            }
            var ambulancium = await _context.Ambulancia.FindAsync(id);
            if (ambulancium != null)
            {
                _context.Ambulancia.Remove(ambulancium);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AmbulanciumExists(int id)
        {
          return (_context.Ambulancia?.Any(e => e.Idamb == id)).GetValueOrDefault();
        }
    }
}
