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
    public class RecepcionistaController : Controller
    {
        private readonly Proyecto_U_3V3Context _context;

        public RecepcionistaController(Proyecto_U_3V3Context context)
        {
            _context = context;
        }

        // GET: Recepcionista
        public async Task<IActionResult> Index()
        {
              return _context.Recepcionista != null ? 
                          View(await _context.Recepcionista.ToListAsync()) :
                          Problem("Entity set 'Proyecto_U_3V3Context.Recepcionista'  is null.");
        }

        // GET: Recepcionista/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Recepcionista == null)
            {
                return NotFound();
            }

            var recepcionistum = await _context.Recepcionista
                .FirstOrDefaultAsync(m => m.Idrecep == id);
            if (recepcionistum == null)
            {
                return NotFound();
            }

            return View(recepcionistum);
        }

        // GET: Recepcionista/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Recepcionista/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idrecep,Rut,DepartamentoMédico,Horario,PrimerNombre,PrimerApellido,SegundoApellido")] Recepcionistum recepcionistum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recepcionistum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(recepcionistum);
        }

        // GET: Recepcionista/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Recepcionista == null)
            {
                return NotFound();
            }

            var recepcionistum = await _context.Recepcionista.FindAsync(id);
            if (recepcionistum == null)
            {
                return NotFound();
            }
            return View(recepcionistum);
        }

        // POST: Recepcionista/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idrecep,Rut,DepartamentoMédico,Horario,PrimerNombre,PrimerApellido,SegundoApellido")] Recepcionistum recepcionistum)
        {
            if (id != recepcionistum.Idrecep)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recepcionistum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecepcionistumExists(recepcionistum.Idrecep))
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
            return View(recepcionistum);
        }

        // GET: Recepcionista/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Recepcionista == null)
            {
                return NotFound();
            }

            var recepcionistum = await _context.Recepcionista
                .FirstOrDefaultAsync(m => m.Idrecep == id);
            if (recepcionistum == null)
            {
                return NotFound();
            }

            return View(recepcionistum);
        }

        // POST: Recepcionista/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Recepcionista == null)
            {
                return Problem("Entity set 'Proyecto_U_3V3Context.Recepcionista'  is null.");
            }
            var recepcionistum = await _context.Recepcionista.FindAsync(id);
            if (recepcionistum != null)
            {
                _context.Recepcionista.Remove(recepcionistum);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecepcionistumExists(int id)
        {
          return (_context.Recepcionista?.Any(e => e.Idrecep == id)).GetValueOrDefault();
        }
    }
}
