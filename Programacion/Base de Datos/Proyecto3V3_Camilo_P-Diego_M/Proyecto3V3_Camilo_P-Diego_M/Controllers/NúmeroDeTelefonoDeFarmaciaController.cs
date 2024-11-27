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
    public class NúmeroDeTelefonoDeFarmaciaController : Controller
    {
        private readonly Proyecto_U_3V3Context _context;

        public NúmeroDeTelefonoDeFarmaciaController(Proyecto_U_3V3Context context)
        {
            _context = context;
        }

        // GET: NúmeroDeTelefonoDeFarmacia
        public async Task<IActionResult> Index()
        {
            var proyecto_U_3V3Context = _context.NúmeroDeTelefonoDeFarmacia.Include(n => n.IdnumFarNavigation);
            return View(await proyecto_U_3V3Context.ToListAsync());
        }

        // GET: NúmeroDeTelefonoDeFarmacia/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.NúmeroDeTelefonoDeFarmacia == null)
            {
                return NotFound();
            }

            var númeroDeTelefonoDeFarmacium = await _context.NúmeroDeTelefonoDeFarmacia
                .Include(n => n.IdnumFarNavigation)
                .FirstOrDefaultAsync(m => m.IdnumFar == id);
            if (númeroDeTelefonoDeFarmacium == null)
            {
                return NotFound();
            }

            return View(númeroDeTelefonoDeFarmacium);
        }

        // GET: NúmeroDeTelefonoDeFarmacia/Create
        public IActionResult Create()
        {
            ViewData["IdnumFar"] = new SelectList(_context.Farmacia, "Idfar", "Idfar");
            return View();
        }

        // POST: NúmeroDeTelefonoDeFarmacia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdnumFar,NúmeroDeTelefono")] NúmeroDeTelefonoDeFarmacium númeroDeTelefonoDeFarmacium)
        {
            if (ModelState.IsValid)
            {
                _context.Add(númeroDeTelefonoDeFarmacium);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdnumFar"] = new SelectList(_context.Farmacia, "Idfar", "Idfar", númeroDeTelefonoDeFarmacium.IdnumFar);
            return View(númeroDeTelefonoDeFarmacium);
        }

        // GET: NúmeroDeTelefonoDeFarmacia/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.NúmeroDeTelefonoDeFarmacia == null)
            {
                return NotFound();
            }

            var númeroDeTelefonoDeFarmacium = await _context.NúmeroDeTelefonoDeFarmacia.FindAsync(id);
            if (númeroDeTelefonoDeFarmacium == null)
            {
                return NotFound();
            }
            ViewData["IdnumFar"] = new SelectList(_context.Farmacia, "Idfar", "Idfar", númeroDeTelefonoDeFarmacium.IdnumFar);
            return View(númeroDeTelefonoDeFarmacium);
        }

        // POST: NúmeroDeTelefonoDeFarmacia/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdnumFar,NúmeroDeTelefono")] NúmeroDeTelefonoDeFarmacium númeroDeTelefonoDeFarmacium)
        {
            if (id != númeroDeTelefonoDeFarmacium.IdnumFar)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(númeroDeTelefonoDeFarmacium);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NúmeroDeTelefonoDeFarmaciumExists(númeroDeTelefonoDeFarmacium.IdnumFar))
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
            ViewData["IdnumFar"] = new SelectList(_context.Farmacia, "Idfar", "Idfar", númeroDeTelefonoDeFarmacium.IdnumFar);
            return View(númeroDeTelefonoDeFarmacium);
        }

        // GET: NúmeroDeTelefonoDeFarmacia/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.NúmeroDeTelefonoDeFarmacia == null)
            {
                return NotFound();
            }

            var númeroDeTelefonoDeFarmacium = await _context.NúmeroDeTelefonoDeFarmacia
                .Include(n => n.IdnumFarNavigation)
                .FirstOrDefaultAsync(m => m.IdnumFar == id);
            if (númeroDeTelefonoDeFarmacium == null)
            {
                return NotFound();
            }

            return View(númeroDeTelefonoDeFarmacium);
        }

        // POST: NúmeroDeTelefonoDeFarmacia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.NúmeroDeTelefonoDeFarmacia == null)
            {
                return Problem("Entity set 'Proyecto_U_3V3Context.NúmeroDeTelefonoDeFarmacia'  is null.");
            }
            var númeroDeTelefonoDeFarmacium = await _context.NúmeroDeTelefonoDeFarmacia.FindAsync(id);
            if (númeroDeTelefonoDeFarmacium != null)
            {
                _context.NúmeroDeTelefonoDeFarmacia.Remove(númeroDeTelefonoDeFarmacium);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NúmeroDeTelefonoDeFarmaciumExists(int id)
        {
          return (_context.NúmeroDeTelefonoDeFarmacia?.Any(e => e.IdnumFar == id)).GetValueOrDefault();
        }
    }
}
