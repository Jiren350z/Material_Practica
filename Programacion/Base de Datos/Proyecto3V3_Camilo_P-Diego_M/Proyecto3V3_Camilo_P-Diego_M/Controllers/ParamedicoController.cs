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
    public class ParamedicoController : Controller
    {
        private readonly Proyecto_U_3V3Context _context;

        public ParamedicoController(Proyecto_U_3V3Context context)
        {
            _context = context;
        }

        // GET: Paramedico
        public async Task<IActionResult> Index()
        {
              return _context.Paramedicos != null ? 
                          View(await _context.Paramedicos.ToListAsync()) :
                          Problem("Entity set 'Proyecto_U_3V3Context.Paramedicos'  is null.");
        }

        // GET: Paramedico/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Paramedicos == null)
            {
                return NotFound();
            }

            var paramedico = await _context.Paramedicos
                .FirstOrDefaultAsync(m => m.Idpar == id);
            if (paramedico == null)
            {
                return NotFound();
            }

            return View(paramedico);
        }

        // GET: Paramedico/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Paramedico/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idpar,Nombre,Rut,HorarioDeAtención,Certificación,NúmeroDeCasa,Calle,Ciudad")] Paramedico paramedico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paramedico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(paramedico);
        }

        // GET: Paramedico/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Paramedicos == null)
            {
                return NotFound();
            }

            var paramedico = await _context.Paramedicos.FindAsync(id);
            if (paramedico == null)
            {
                return NotFound();
            }
            return View(paramedico);
        }

        // POST: Paramedico/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idpar,Nombre,Rut,HorarioDeAtención,Certificación,NúmeroDeCasa,Calle,Ciudad")] Paramedico paramedico)
        {
            if (id != paramedico.Idpar)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paramedico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParamedicoExists(paramedico.Idpar))
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
            return View(paramedico);
        }

        // GET: Paramedico/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Paramedicos == null)
            {
                return NotFound();
            }

            var paramedico = await _context.Paramedicos
                .FirstOrDefaultAsync(m => m.Idpar == id);
            if (paramedico == null)
            {
                return NotFound();
            }

            return View(paramedico);
        }

        // POST: Paramedico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Paramedicos == null)
            {
                return Problem("Entity set 'Proyecto_U_3V3Context.Paramedicos'  is null.");
            }
            var paramedico = await _context.Paramedicos.FindAsync(id);
            if (paramedico != null)
            {
                _context.Paramedicos.Remove(paramedico);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParamedicoExists(int id)
        {
          return (_context.Paramedicos?.Any(e => e.Idpar == id)).GetValueOrDefault();
        }
    }
}
