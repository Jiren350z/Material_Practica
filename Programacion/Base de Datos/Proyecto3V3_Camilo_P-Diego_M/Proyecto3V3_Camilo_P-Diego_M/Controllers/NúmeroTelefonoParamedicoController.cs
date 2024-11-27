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
    public class NúmeroTelefonoParamedicoController : Controller
    {
        private readonly Proyecto_U_3V3Context _context;

        public NúmeroTelefonoParamedicoController(Proyecto_U_3V3Context context)
        {
            _context = context;
        }

        // GET: NúmeroTelefonoParamedico
        public async Task<IActionResult> Index()
        {
            var proyecto_U_3V3Context = _context.NúmeroTelefonoParamedicos.Include(n => n.IdnumParaNavigation);
            return View(await proyecto_U_3V3Context.ToListAsync());
        }

        // GET: NúmeroTelefonoParamedico/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.NúmeroTelefonoParamedicos == null)
            {
                return NotFound();
            }

            var númeroTelefonoParamedico = await _context.NúmeroTelefonoParamedicos
                .Include(n => n.IdnumParaNavigation)
                .FirstOrDefaultAsync(m => m.IdnumPara == id);
            if (númeroTelefonoParamedico == null)
            {
                return NotFound();
            }

            return View(númeroTelefonoParamedico);
        }

        // GET: NúmeroTelefonoParamedico/Create
        public IActionResult Create()
        {
            ViewData["IdnumPara"] = new SelectList(_context.Paramedicos, "Idpar", "Idpar");
            return View();
        }

        // POST: NúmeroTelefonoParamedico/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdnumPara,NúmeroDeTelefono")] NúmeroTelefonoParamedico númeroTelefonoParamedico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(númeroTelefonoParamedico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdnumPara"] = new SelectList(_context.Paramedicos, "Idpar", "Idpar", númeroTelefonoParamedico.IdnumPara);
            return View(númeroTelefonoParamedico);
        }

        // GET: NúmeroTelefonoParamedico/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.NúmeroTelefonoParamedicos == null)
            {
                return NotFound();
            }

            var númeroTelefonoParamedico = await _context.NúmeroTelefonoParamedicos.FindAsync(id);
            if (númeroTelefonoParamedico == null)
            {
                return NotFound();
            }
            ViewData["IdnumPara"] = new SelectList(_context.Paramedicos, "Idpar", "Idpar", númeroTelefonoParamedico.IdnumPara);
            return View(númeroTelefonoParamedico);
        }

        // POST: NúmeroTelefonoParamedico/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdnumPara,NúmeroDeTelefono")] NúmeroTelefonoParamedico númeroTelefonoParamedico)
        {
            if (id != númeroTelefonoParamedico.IdnumPara)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(númeroTelefonoParamedico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NúmeroTelefonoParamedicoExists(númeroTelefonoParamedico.IdnumPara))
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
            ViewData["IdnumPara"] = new SelectList(_context.Paramedicos, "Idpar", "Idpar", númeroTelefonoParamedico.IdnumPara);
            return View(númeroTelefonoParamedico);
        }

        // GET: NúmeroTelefonoParamedico/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.NúmeroTelefonoParamedicos == null)
            {
                return NotFound();
            }

            var númeroTelefonoParamedico = await _context.NúmeroTelefonoParamedicos
                .Include(n => n.IdnumParaNavigation)
                .FirstOrDefaultAsync(m => m.IdnumPara == id);
            if (númeroTelefonoParamedico == null)
            {
                return NotFound();
            }

            return View(númeroTelefonoParamedico);
        }

        // POST: NúmeroTelefonoParamedico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.NúmeroTelefonoParamedicos == null)
            {
                return Problem("Entity set 'Proyecto_U_3V3Context.NúmeroTelefonoParamedicos'  is null.");
            }
            var númeroTelefonoParamedico = await _context.NúmeroTelefonoParamedicos.FindAsync(id);
            if (númeroTelefonoParamedico != null)
            {
                _context.NúmeroTelefonoParamedicos.Remove(númeroTelefonoParamedico);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NúmeroTelefonoParamedicoExists(int id)
        {
          return (_context.NúmeroTelefonoParamedicos?.Any(e => e.IdnumPara == id)).GetValueOrDefault();
        }
    }
}
