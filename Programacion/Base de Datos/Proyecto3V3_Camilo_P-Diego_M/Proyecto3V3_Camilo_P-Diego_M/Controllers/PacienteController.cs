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
    public class PacienteController : Controller
    {
        private readonly Proyecto_U_3V3Context _context;

        public PacienteController(Proyecto_U_3V3Context context)
        {
            _context = context;
        }

        // GET: Paciente
        public async Task<IActionResult> Index()
        {
            var proyecto_U_3V3Context = _context.Pacientes.Include(p => p.IdambulNavigation).Include(p => p.Sala);
            return View(await proyecto_U_3V3Context.ToListAsync());
        }

        // GET: Paciente/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pacientes == null)
            {
                return NotFound();
            }

            var paciente = await _context.Pacientes
                .Include(p => p.IdambulNavigation)
                .Include(p => p.Sala)
                .FirstOrDefaultAsync(m => m.Idpac == id);
            if (paciente == null)
            {
                return NotFound();
            }

            return View(paciente);
        }

        // GET: Paciente/Create
        public IActionResult Create()
        {
            ViewData["Idambul"] = new SelectList(_context.Ambulancia, "Idamb", "Idamb");
            ViewData["SalaId"] = new SelectList(_context.Salas, "Idsala", "Idsala");
            return View();
        }

        // POST: Paciente/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idpac,Rut,Nombre,Pago,Problema,HistoriaClínica,NúmeroDeCasa,Calle,Ciudad,SalaId,Idambul")] Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paciente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idambul"] = new SelectList(_context.Ambulancia, "Idamb", "Idamb", paciente.Idambul);
            ViewData["SalaId"] = new SelectList(_context.Salas, "Idsala", "Idsala", paciente.SalaId);
            return View(paciente);
        }

        // GET: Paciente/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pacientes == null)
            {
                return NotFound();
            }

            var paciente = await _context.Pacientes.FindAsync(id);
            if (paciente == null)
            {
                return NotFound();
            }
            ViewData["Idambul"] = new SelectList(_context.Ambulancia, "Idamb", "Idamb", paciente.Idambul);
            ViewData["SalaId"] = new SelectList(_context.Salas, "Idsala", "Idsala", paciente.SalaId);
            return View(paciente);
        }

        // POST: Paciente/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idpac,Rut,Nombre,Pago,Problema,HistoriaClínica,NúmeroDeCasa,Calle,Ciudad,SalaId,Idambul")] Paciente paciente)
        {
            if (id != paciente.Idpac)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paciente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PacienteExists(paciente.Idpac))
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
            ViewData["Idambul"] = new SelectList(_context.Ambulancia, "Idamb", "Idamb", paciente.Idambul);
            ViewData["SalaId"] = new SelectList(_context.Salas, "Idsala", "Idsala", paciente.SalaId);
            return View(paciente);
        }

        // GET: Paciente/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pacientes == null)
            {
                return NotFound();
            }

            var paciente = await _context.Pacientes
                .Include(p => p.IdambulNavigation)
                .Include(p => p.Sala)
                .FirstOrDefaultAsync(m => m.Idpac == id);
            if (paciente == null)
            {
                return NotFound();
            }

            return View(paciente);
        }

        // POST: Paciente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pacientes == null)
            {
                return Problem("Entity set 'Proyecto_U_3V3Context.Pacientes'  is null.");
            }
            var paciente = await _context.Pacientes.FindAsync(id);
            if (paciente != null)
            {
                _context.Pacientes.Remove(paciente);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PacienteExists(int id)
        {
          return (_context.Pacientes?.Any(e => e.Idpac == id)).GetValueOrDefault();
        }
    }
}
