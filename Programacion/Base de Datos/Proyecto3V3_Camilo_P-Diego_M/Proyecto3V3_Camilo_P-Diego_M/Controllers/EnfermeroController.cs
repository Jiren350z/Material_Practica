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
    public class EnfermeroController : Controller
    {
        private readonly Proyecto_U_3V3Context _context;

        public EnfermeroController(Proyecto_U_3V3Context context)
        {
            _context = context;
        }

        // GET: Enfermero
        public async Task<IActionResult> Index()
        {
              return _context.Enfermeros != null ? 
                          View(await _context.Enfermeros.ToListAsync()) :
                          Problem("Entity set 'Proyecto_U_3V3Context.Enfermeros'  is null.");
        }

        // GET: Enfermero/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Enfermeros == null)
            {
                return NotFound();
            }

            var enfermero = await _context.Enfermeros
                .FirstOrDefaultAsync(m => m.Idenf == id);
            if (enfermero == null)
            {
                return NotFound();
            }

            return View(enfermero);
        }

        // GET: Enfermero/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Enfermero/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idenf,Nombre,Rut,HorarioDeAtención,NúmeroDeCasa,Calle,Ciudad")] Enfermero enfermero)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enfermero);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(enfermero);
        }

        // GET: Enfermero/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Enfermeros == null)
            {
                return NotFound();
            }

            var enfermero = await _context.Enfermeros.FindAsync(id);
            if (enfermero == null)
            {
                return NotFound();
            }
            return View(enfermero);
        }

        // POST: Enfermero/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idenf,Nombre,Rut,HorarioDeAtención,NúmeroDeCasa,Calle,Ciudad")] Enfermero enfermero)
        {
            if (id != enfermero.Idenf)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enfermero);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnfermeroExists(enfermero.Idenf))
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
            return View(enfermero);
        }

        // GET: Enfermero/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Enfermeros == null)
            {
                return NotFound();
            }

            var enfermero = await _context.Enfermeros
                .FirstOrDefaultAsync(m => m.Idenf == id);
            if (enfermero == null)
            {
                return NotFound();
            }

            return View(enfermero);
        }

        // POST: Enfermero/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Enfermeros == null)
            {
                return Problem("Entity set 'Proyecto_U_3V3Context.Enfermeros'  is null.");
            }
            var enfermero = await _context.Enfermeros.FindAsync(id);
            if (enfermero != null)
            {
                _context.Enfermeros.Remove(enfermero);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnfermeroExists(int id)
        {
          return (_context.Enfermeros?.Any(e => e.Idenf == id)).GetValueOrDefault();
        }
    }
}
