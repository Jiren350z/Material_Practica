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
    public class NúmeroDeTelefonoEnfermeroController : Controller
    {
        private readonly Proyecto_U_3V3Context _context;

        public NúmeroDeTelefonoEnfermeroController(Proyecto_U_3V3Context context)
        {
            _context = context;
        }

        // GET: NúmeroDeTelefonoEnfermero
        public async Task<IActionResult> Index()
        {
            var proyecto_U_3V3Context = _context.NúmeroDeTelefonoEnfermeros.Include(n => n.IdnumEnfNavigation);
            return View(await proyecto_U_3V3Context.ToListAsync());
        }

        // GET: NúmeroDeTelefonoEnfermero/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.NúmeroDeTelefonoEnfermeros == null)
            {
                return NotFound();
            }

            var númeroDeTelefonoEnfermero = await _context.NúmeroDeTelefonoEnfermeros
                .Include(n => n.IdnumEnfNavigation)
                .FirstOrDefaultAsync(m => m.IdnumEnf == id);
            if (númeroDeTelefonoEnfermero == null)
            {
                return NotFound();
            }

            return View(númeroDeTelefonoEnfermero);
        }

        // GET: NúmeroDeTelefonoEnfermero/Create
        public IActionResult Create()
        {
            ViewData["IdnumEnf"] = new SelectList(_context.Enfermeros, "Idenf", "Idenf");
            return View();
        }

        // POST: NúmeroDeTelefonoEnfermero/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdnumEnf,NúmeroDeTelefono")] NúmeroDeTelefonoEnfermero númeroDeTelefonoEnfermero)
        {
            if (ModelState.IsValid)
            {
                _context.Add(númeroDeTelefonoEnfermero);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdnumEnf"] = new SelectList(_context.Enfermeros, "Idenf", "Idenf", númeroDeTelefonoEnfermero.IdnumEnf);
            return View(númeroDeTelefonoEnfermero);
        }

        // GET: NúmeroDeTelefonoEnfermero/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.NúmeroDeTelefonoEnfermeros == null)
            {
                return NotFound();
            }

            var númeroDeTelefonoEnfermero = await _context.NúmeroDeTelefonoEnfermeros.FindAsync(id);
            if (númeroDeTelefonoEnfermero == null)
            {
                return NotFound();
            }
            ViewData["IdnumEnf"] = new SelectList(_context.Enfermeros, "Idenf", "Idenf", númeroDeTelefonoEnfermero.IdnumEnf);
            return View(númeroDeTelefonoEnfermero);
        }

        // POST: NúmeroDeTelefonoEnfermero/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdnumEnf,NúmeroDeTelefono")] NúmeroDeTelefonoEnfermero númeroDeTelefonoEnfermero)
        {
            if (id != númeroDeTelefonoEnfermero.IdnumEnf)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(númeroDeTelefonoEnfermero);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NúmeroDeTelefonoEnfermeroExists(númeroDeTelefonoEnfermero.IdnumEnf))
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
            ViewData["IdnumEnf"] = new SelectList(_context.Enfermeros, "Idenf", "Idenf", númeroDeTelefonoEnfermero.IdnumEnf);
            return View(númeroDeTelefonoEnfermero);
        }

        // GET: NúmeroDeTelefonoEnfermero/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.NúmeroDeTelefonoEnfermeros == null)
            {
                return NotFound();
            }

            var númeroDeTelefonoEnfermero = await _context.NúmeroDeTelefonoEnfermeros
                .Include(n => n.IdnumEnfNavigation)
                .FirstOrDefaultAsync(m => m.IdnumEnf == id);
            if (númeroDeTelefonoEnfermero == null)
            {
                return NotFound();
            }

            return View(númeroDeTelefonoEnfermero);
        }

        // POST: NúmeroDeTelefonoEnfermero/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.NúmeroDeTelefonoEnfermeros == null)
            {
                return Problem("Entity set 'Proyecto_U_3V3Context.NúmeroDeTelefonoEnfermeros'  is null.");
            }
            var númeroDeTelefonoEnfermero = await _context.NúmeroDeTelefonoEnfermeros.FindAsync(id);
            if (númeroDeTelefonoEnfermero != null)
            {
                _context.NúmeroDeTelefonoEnfermeros.Remove(númeroDeTelefonoEnfermero);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NúmeroDeTelefonoEnfermeroExists(int id)
        {
          return (_context.NúmeroDeTelefonoEnfermeros?.Any(e => e.IdnumEnf == id)).GetValueOrDefault();
        }
    }
}
