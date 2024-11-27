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
    public class CitaMedicaController : Controller
    {
        private readonly Proyecto_U_3V3Context _context;

        public CitaMedicaController(Proyecto_U_3V3Context context)
        {
            _context = context;
        }

        // GET: CitaMedica
        public async Task<IActionResult> Index()
        {
            var proyecto_U_3V3Context = _context.CitaMedicas.Include(c => c.IddoctorNavigation).Include(c => c.IdpacienteNavigation).Include(c => c.IdrecepcionistaNavigation).Include(c => c.IdsalNavigation);
            return View(await proyecto_U_3V3Context.ToListAsync());
        }

        // GET: CitaMedica/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CitaMedicas == null)
            {
                return NotFound();
            }

            var citaMedica = await _context.CitaMedicas
                .Include(c => c.IddoctorNavigation)
                .Include(c => c.IdpacienteNavigation)
                .Include(c => c.IdrecepcionistaNavigation)
                .Include(c => c.IdsalNavigation)
                .FirstOrDefaultAsync(m => m.IdcitaMed == id);
            if (citaMedica == null)
            {
                return NotFound();
            }

            return View(citaMedica);
        }

        // GET: CitaMedica/Create
        public IActionResult Create()
        {
            ViewData["Iddoctor"] = new SelectList(_context.Doctors, "Iddoc", "Iddoc");
            ViewData["Idpaciente"] = new SelectList(_context.Pacientes, "Idpac", "Idpac");
            ViewData["Idrecepcionista"] = new SelectList(_context.Recepcionista, "Idrecep", "Idrecep");
            ViewData["Idsal"] = new SelectList(_context.Salas, "Idsala", "Idsala");
            return View();
        }

        // POST: CitaMedica/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdcitaMed,Motivo,Pago,DepartamentoMedico,Día,Mes,Año,Idpaciente,Idsal,Idrecepcionista,Iddoctor")] CitaMedica citaMedica)
        {
            if (ModelState.IsValid)
            {
                _context.Add(citaMedica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Iddoctor"] = new SelectList(_context.Doctors, "Iddoc", "Iddoc", citaMedica.Iddoctor);
            ViewData["Idpaciente"] = new SelectList(_context.Pacientes, "Idpac", "Idpac", citaMedica.Idpaciente);
            ViewData["Idrecepcionista"] = new SelectList(_context.Recepcionista, "Idrecep", "Idrecep", citaMedica.Idrecepcionista);
            ViewData["Idsal"] = new SelectList(_context.Salas, "Idsala", "Idsala", citaMedica.Idsal);
            return View(citaMedica);
        }

        // GET: CitaMedica/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CitaMedicas == null)
            {
                return NotFound();
            }

            var citaMedica = await _context.CitaMedicas.FindAsync(id);
            if (citaMedica == null)
            {
                return NotFound();
            }
            ViewData["Iddoctor"] = new SelectList(_context.Doctors, "Iddoc", "Iddoc", citaMedica.Iddoctor);
            ViewData["Idpaciente"] = new SelectList(_context.Pacientes, "Idpac", "Idpac", citaMedica.Idpaciente);
            ViewData["Idrecepcionista"] = new SelectList(_context.Recepcionista, "Idrecep", "Idrecep", citaMedica.Idrecepcionista);
            ViewData["Idsal"] = new SelectList(_context.Salas, "Idsala", "Idsala", citaMedica.Idsal);
            return View(citaMedica);
        }

        // POST: CitaMedica/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdcitaMed,Motivo,Pago,DepartamentoMedico,Día,Mes,Año,Idpaciente,Idsal,Idrecepcionista,Iddoctor")] CitaMedica citaMedica)
        {
            if (id != citaMedica.IdcitaMed)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(citaMedica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CitaMedicaExists(citaMedica.IdcitaMed))
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
            ViewData["Iddoctor"] = new SelectList(_context.Doctors, "Iddoc", "Iddoc", citaMedica.Iddoctor);
            ViewData["Idpaciente"] = new SelectList(_context.Pacientes, "Idpac", "Idpac", citaMedica.Idpaciente);
            ViewData["Idrecepcionista"] = new SelectList(_context.Recepcionista, "Idrecep", "Idrecep", citaMedica.Idrecepcionista);
            ViewData["Idsal"] = new SelectList(_context.Salas, "Idsala", "Idsala", citaMedica.Idsal);
            return View(citaMedica);
        }

        // GET: CitaMedica/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CitaMedicas == null)
            {
                return NotFound();
            }

            var citaMedica = await _context.CitaMedicas
                .Include(c => c.IddoctorNavigation)
                .Include(c => c.IdpacienteNavigation)
                .Include(c => c.IdrecepcionistaNavigation)
                .Include(c => c.IdsalNavigation)
                .FirstOrDefaultAsync(m => m.IdcitaMed == id);
            if (citaMedica == null)
            {
                return NotFound();
            }

            return View(citaMedica);
        }

        // POST: CitaMedica/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CitaMedicas == null)
            {
                return Problem("Entity set 'Proyecto_U_3V3Context.CitaMedicas'  is null.");
            }
            var citaMedica = await _context.CitaMedicas.FindAsync(id);
            if (citaMedica != null)
            {
                _context.CitaMedicas.Remove(citaMedica);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CitaMedicaExists(int id)
        {
          return (_context.CitaMedicas?.Any(e => e.IdcitaMed == id)).GetValueOrDefault();
        }
    }
}
