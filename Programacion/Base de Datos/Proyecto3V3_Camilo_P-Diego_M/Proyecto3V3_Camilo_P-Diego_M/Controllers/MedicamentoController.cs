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
    public class MedicamentoController : Controller
    {
        private readonly Proyecto_U_3V3Context _context;

        public MedicamentoController(Proyecto_U_3V3Context context)
        {
            _context = context;
        }

        // GET: Medicamento
        public async Task<IActionResult> Index()
        {
            var proyecto_U_3V3Context = _context.Medicamentos.Include(m => m.IddoctorNavigation).Include(m => m.IdfarmaciaNavigation);
            return View(await proyecto_U_3V3Context.ToListAsync());
        }

        // GET: Medicamento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Medicamentos == null)
            {
                return NotFound();
            }

            var medicamento = await _context.Medicamentos
                .Include(m => m.IddoctorNavigation)
                .Include(m => m.IdfarmaciaNavigation)
                .FirstOrDefaultAsync(m => m.Idmed == id);
            if (medicamento == null)
            {
                return NotFound();
            }

            return View(medicamento);
        }

        // GET: Medicamento/Create
        public IActionResult Create()
        {
            ViewData["Iddoctor"] = new SelectList(_context.Doctors, "Iddoc", "Iddoc");
            ViewData["Idfarmacia"] = new SelectList(_context.Farmacia, "Idfar", "Idfar");
            return View();
        }

        // POST: Medicamento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idmed,CódigoEnBodega,Nombre,FechaDeCaducidad,InstruccionesDeUso,Integredientes,FórmulaFarmaceutica,Idfarmacia,Iddoctor")] Medicamento medicamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medicamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Iddoctor"] = new SelectList(_context.Doctors, "Iddoc", "Iddoc", medicamento.Iddoctor);
            ViewData["Idfarmacia"] = new SelectList(_context.Farmacia, "Idfar", "Idfar", medicamento.Idfarmacia);
            return View(medicamento);
        }

        // GET: Medicamento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Medicamentos == null)
            {
                return NotFound();
            }

            var medicamento = await _context.Medicamentos.FindAsync(id);
            if (medicamento == null)
            {
                return NotFound();
            }
            ViewData["Iddoctor"] = new SelectList(_context.Doctors, "Iddoc", "Iddoc", medicamento.Iddoctor);
            ViewData["Idfarmacia"] = new SelectList(_context.Farmacia, "Idfar", "Idfar", medicamento.Idfarmacia);
            return View(medicamento);
        }

        // POST: Medicamento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idmed,CódigoEnBodega,Nombre,FechaDeCaducidad,InstruccionesDeUso,Integredientes,FórmulaFarmaceutica,Idfarmacia,Iddoctor")] Medicamento medicamento)
        {
            if (id != medicamento.Idmed)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medicamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicamentoExists(medicamento.Idmed))
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
            ViewData["Iddoctor"] = new SelectList(_context.Doctors, "Iddoc", "Iddoc", medicamento.Iddoctor);
            ViewData["Idfarmacia"] = new SelectList(_context.Farmacia, "Idfar", "Idfar", medicamento.Idfarmacia);
            return View(medicamento);
        }

        // GET: Medicamento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Medicamentos == null)
            {
                return NotFound();
            }

            var medicamento = await _context.Medicamentos
                .Include(m => m.IddoctorNavigation)
                .Include(m => m.IdfarmaciaNavigation)
                .FirstOrDefaultAsync(m => m.Idmed == id);
            if (medicamento == null)
            {
                return NotFound();
            }

            return View(medicamento);
        }

        // POST: Medicamento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Medicamentos == null)
            {
                return Problem("Entity set 'Proyecto_U_3V3Context.Medicamentos'  is null.");
            }
            var medicamento = await _context.Medicamentos.FindAsync(id);
            if (medicamento != null)
            {
                _context.Medicamentos.Remove(medicamento);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicamentoExists(int id)
        {
          return (_context.Medicamentos?.Any(e => e.Idmed == id)).GetValueOrDefault();
        }
    }
}
