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
    public class NúmeroDeTelefonoDePacienteController : Controller
    {
        private readonly Proyecto_U_3V3Context _context;

        public NúmeroDeTelefonoDePacienteController(Proyecto_U_3V3Context context)
        {
            _context = context;
        }

        // GET: NúmeroDeTelefonoDePaciente
        public async Task<IActionResult> Index()
        {
            var proyecto_U_3V3Context = _context.NúmeroDeTelefonoDePacientes.Include(n => n.IdnumPacNavigation);
            return View(await proyecto_U_3V3Context.ToListAsync());
        }

        // GET: NúmeroDeTelefonoDePaciente/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.NúmeroDeTelefonoDePacientes == null)
            {
                return NotFound();
            }

            var númeroDeTelefonoDePaciente = await _context.NúmeroDeTelefonoDePacientes
                .Include(n => n.IdnumPacNavigation)
                .FirstOrDefaultAsync(m => m.IdnumPac == id);
            if (númeroDeTelefonoDePaciente == null)
            {
                return NotFound();
            }

            return View(númeroDeTelefonoDePaciente);
        }

        // GET: NúmeroDeTelefonoDePaciente/Create
        public IActionResult Create()
        {
            ViewData["IdnumPac"] = new SelectList(_context.Pacientes, "Idpac", "Idpac");
            return View();
        }

        // POST: NúmeroDeTelefonoDePaciente/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdnumPac,NúmeroDeTelefono")] NúmeroDeTelefonoDePaciente númeroDeTelefonoDePaciente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(númeroDeTelefonoDePaciente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdnumPac"] = new SelectList(_context.Pacientes, "Idpac", "Idpac", númeroDeTelefonoDePaciente.IdnumPac);
            return View(númeroDeTelefonoDePaciente);
        }

        // GET: NúmeroDeTelefonoDePaciente/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.NúmeroDeTelefonoDePacientes == null)
            {
                return NotFound();
            }

            var númeroDeTelefonoDePaciente = await _context.NúmeroDeTelefonoDePacientes.FindAsync(id);
            if (númeroDeTelefonoDePaciente == null)
            {
                return NotFound();
            }
            ViewData["IdnumPac"] = new SelectList(_context.Pacientes, "Idpac", "Idpac", númeroDeTelefonoDePaciente.IdnumPac);
            return View(númeroDeTelefonoDePaciente);
        }

        // POST: NúmeroDeTelefonoDePaciente/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdnumPac,NúmeroDeTelefono")] NúmeroDeTelefonoDePaciente númeroDeTelefonoDePaciente)
        {
            if (id != númeroDeTelefonoDePaciente.IdnumPac)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(númeroDeTelefonoDePaciente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NúmeroDeTelefonoDePacienteExists(númeroDeTelefonoDePaciente.IdnumPac))
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
            ViewData["IdnumPac"] = new SelectList(_context.Pacientes, "Idpac", "Idpac", númeroDeTelefonoDePaciente.IdnumPac);
            return View(númeroDeTelefonoDePaciente);
        }

        // GET: NúmeroDeTelefonoDePaciente/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.NúmeroDeTelefonoDePacientes == null)
            {
                return NotFound();
            }

            var númeroDeTelefonoDePaciente = await _context.NúmeroDeTelefonoDePacientes
                .Include(n => n.IdnumPacNavigation)
                .FirstOrDefaultAsync(m => m.IdnumPac == id);
            if (númeroDeTelefonoDePaciente == null)
            {
                return NotFound();
            }

            return View(númeroDeTelefonoDePaciente);
        }

        // POST: NúmeroDeTelefonoDePaciente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.NúmeroDeTelefonoDePacientes == null)
            {
                return Problem("Entity set 'Proyecto_U_3V3Context.NúmeroDeTelefonoDePacientes'  is null.");
            }
            var númeroDeTelefonoDePaciente = await _context.NúmeroDeTelefonoDePacientes.FindAsync(id);
            if (númeroDeTelefonoDePaciente != null)
            {
                _context.NúmeroDeTelefonoDePacientes.Remove(númeroDeTelefonoDePaciente);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NúmeroDeTelefonoDePacienteExists(int id)
        {
          return (_context.NúmeroDeTelefonoDePacientes?.Any(e => e.IdnumPac == id)).GetValueOrDefault();
        }
    }
}
