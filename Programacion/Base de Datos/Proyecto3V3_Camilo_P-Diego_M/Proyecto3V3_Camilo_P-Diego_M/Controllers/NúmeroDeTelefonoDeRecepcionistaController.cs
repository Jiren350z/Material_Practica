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
    public class NúmeroDeTelefonoDeRecepcionistaController : Controller
    {
        private readonly Proyecto_U_3V3Context _context;

        public NúmeroDeTelefonoDeRecepcionistaController(Proyecto_U_3V3Context context)
        {
            _context = context;
        }

        // GET: NúmeroDeTelefonoDeRecepcionista
        public async Task<IActionResult> Index()
        {
            var proyecto_U_3V3Context = _context.NúmeroDeTelefonoDeRecepcionista.Include(n => n.IdnumRecepNavigation);
            return View(await proyecto_U_3V3Context.ToListAsync());
        }

        // GET: NúmeroDeTelefonoDeRecepcionista/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.NúmeroDeTelefonoDeRecepcionista == null)
            {
                return NotFound();
            }

            var númeroDeTelefonoDeRecepcionistum = await _context.NúmeroDeTelefonoDeRecepcionista
                .Include(n => n.IdnumRecepNavigation)
                .FirstOrDefaultAsync(m => m.IdnumRecep == id);
            if (númeroDeTelefonoDeRecepcionistum == null)
            {
                return NotFound();
            }

            return View(númeroDeTelefonoDeRecepcionistum);
        }

        // GET: NúmeroDeTelefonoDeRecepcionista/Create
        public IActionResult Create()
        {
            ViewData["IdnumRecep"] = new SelectList(_context.Recepcionista, "Idrecep", "Idrecep");
            return View();
        }

        // POST: NúmeroDeTelefonoDeRecepcionista/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdnumRecep,NúmeroDeTelefono")] NúmeroDeTelefonoDeRecepcionistum númeroDeTelefonoDeRecepcionistum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(númeroDeTelefonoDeRecepcionistum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdnumRecep"] = new SelectList(_context.Recepcionista, "Idrecep", "Idrecep", númeroDeTelefonoDeRecepcionistum.IdnumRecep);
            return View(númeroDeTelefonoDeRecepcionistum);
        }

        // GET: NúmeroDeTelefonoDeRecepcionista/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.NúmeroDeTelefonoDeRecepcionista == null)
            {
                return NotFound();
            }

            var númeroDeTelefonoDeRecepcionistum = await _context.NúmeroDeTelefonoDeRecepcionista.FindAsync(id);
            if (númeroDeTelefonoDeRecepcionistum == null)
            {
                return NotFound();
            }
            ViewData["IdnumRecep"] = new SelectList(_context.Recepcionista, "Idrecep", "Idrecep", númeroDeTelefonoDeRecepcionistum.IdnumRecep);
            return View(númeroDeTelefonoDeRecepcionistum);
        }

        // POST: NúmeroDeTelefonoDeRecepcionista/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdnumRecep,NúmeroDeTelefono")] NúmeroDeTelefonoDeRecepcionistum númeroDeTelefonoDeRecepcionistum)
        {
            if (id != númeroDeTelefonoDeRecepcionistum.IdnumRecep)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(númeroDeTelefonoDeRecepcionistum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NúmeroDeTelefonoDeRecepcionistumExists(númeroDeTelefonoDeRecepcionistum.IdnumRecep))
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
            ViewData["IdnumRecep"] = new SelectList(_context.Recepcionista, "Idrecep", "Idrecep", númeroDeTelefonoDeRecepcionistum.IdnumRecep);
            return View(númeroDeTelefonoDeRecepcionistum);
        }

        // GET: NúmeroDeTelefonoDeRecepcionista/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.NúmeroDeTelefonoDeRecepcionista == null)
            {
                return NotFound();
            }

            var númeroDeTelefonoDeRecepcionistum = await _context.NúmeroDeTelefonoDeRecepcionista
                .Include(n => n.IdnumRecepNavigation)
                .FirstOrDefaultAsync(m => m.IdnumRecep == id);
            if (númeroDeTelefonoDeRecepcionistum == null)
            {
                return NotFound();
            }

            return View(númeroDeTelefonoDeRecepcionistum);
        }

        // POST: NúmeroDeTelefonoDeRecepcionista/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.NúmeroDeTelefonoDeRecepcionista == null)
            {
                return Problem("Entity set 'Proyecto_U_3V3Context.NúmeroDeTelefonoDeRecepcionista'  is null.");
            }
            var númeroDeTelefonoDeRecepcionistum = await _context.NúmeroDeTelefonoDeRecepcionista.FindAsync(id);
            if (númeroDeTelefonoDeRecepcionistum != null)
            {
                _context.NúmeroDeTelefonoDeRecepcionista.Remove(númeroDeTelefonoDeRecepcionistum);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NúmeroDeTelefonoDeRecepcionistumExists(int id)
        {
          return (_context.NúmeroDeTelefonoDeRecepcionista?.Any(e => e.IdnumRecep == id)).GetValueOrDefault();
        }
    }
}
