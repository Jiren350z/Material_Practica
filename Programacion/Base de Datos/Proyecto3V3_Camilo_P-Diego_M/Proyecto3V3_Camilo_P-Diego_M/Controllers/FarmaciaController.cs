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
    public class FarmaciaController : Controller
    {
        private readonly Proyecto_U_3V3Context _context;

        public FarmaciaController(Proyecto_U_3V3Context context)
        {
            _context = context;
        }

        // GET: Farmacia
        public async Task<IActionResult> Index()
        {
              return _context.Farmacia != null ? 
                          View(await _context.Farmacia.ToListAsync()) :
                          Problem("Entity set 'Proyecto_U_3V3Context.Farmacia'  is null.");
        }

        // GET: Farmacia/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Farmacia == null)
            {
                return NotFound();
            }

            var farmacium = await _context.Farmacia
                .FirstOrDefaultAsync(m => m.Idfar == id);
            if (farmacium == null)
            {
                return NotFound();
            }

            return View(farmacium);
        }

        // GET: Farmacia/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Farmacia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idfar,HorarioDeAtencion,Ubicacion,CapacidadDeStock,ListaDeMedicamentos")] Farmacium farmacium)
        {
            if (ModelState.IsValid)
            {
                _context.Add(farmacium);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(farmacium);
        }

        // GET: Farmacia/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Farmacia == null)
            {
                return NotFound();
            }

            var farmacium = await _context.Farmacia.FindAsync(id);
            if (farmacium == null)
            {
                return NotFound();
            }
            return View(farmacium);
        }

        // POST: Farmacia/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idfar,HorarioDeAtencion,Ubicacion,CapacidadDeStock,ListaDeMedicamentos")] Farmacium farmacium)
        {
            if (id != farmacium.Idfar)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(farmacium);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FarmaciumExists(farmacium.Idfar))
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
            return View(farmacium);
        }

        // GET: Farmacia/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Farmacia == null)
            {
                return NotFound();
            }

            var farmacium = await _context.Farmacia
                .FirstOrDefaultAsync(m => m.Idfar == id);
            if (farmacium == null)
            {
                return NotFound();
            }

            return View(farmacium);
        }

        // POST: Farmacia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Farmacia == null)
            {
                return Problem("Entity set 'Proyecto_U_3V3Context.Farmacia'  is null.");
            }
            var farmacium = await _context.Farmacia.FindAsync(id);
            if (farmacium != null)
            {
                _context.Farmacia.Remove(farmacium);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FarmaciumExists(int id)
        {
          return (_context.Farmacia?.Any(e => e.Idfar == id)).GetValueOrDefault();
        }
    }
}
