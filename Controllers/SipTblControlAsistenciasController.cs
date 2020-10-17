using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SIPADE.Models;

namespace SIPADE.Controllers
{
    public class SipTblControlAsistenciasController : Controller
    {
        private readonly SIPADEContext _context;

        public SipTblControlAsistenciasController(SIPADEContext context)
        {
            _context = context;
        }

        // GET: SipTblControlAsistencias
        public async Task<IActionResult> Index()
        {
            var sIPADEContext = _context.SipTblControlAsistencia.Include(s => s.SipTblEmp);
            return View(await sIPADEContext.ToListAsync());
        }

        // GET: SipTblControlAsistencias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sipTblControlAsistencia = await _context.SipTblControlAsistencia
                .Include(s => s.SipTblEmp)
                .FirstOrDefaultAsync(m => m.SipTblCasId == id);
            if (sipTblControlAsistencia == null)
            {
                return NotFound();
            }

            return View(sipTblControlAsistencia);
        }

        // GET: SipTblControlAsistencias/Create
        public IActionResult Create()
        {
            ViewData["SipTblEmpId"] = new SelectList(_context.SipTblEmpleado, "SipTblEmpId", "SipTblEmpId");
            return View();
        }

        // POST: SipTblControlAsistencias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SipTblCasId,SipTblEmpId,SipTblCasFechaHoraEntrada,SipTblCasFechaHoraSalida")] SipTblControlAsistencia sipTblControlAsistencia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sipTblControlAsistencia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SipTblEmpId"] = new SelectList(_context.SipTblEmpleado, "SipTblEmpId", "SipTblEmpId", sipTblControlAsistencia.SipTblEmpId);
            return View(sipTblControlAsistencia);
        }

        // GET: SipTblControlAsistencias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sipTblControlAsistencia = await _context.SipTblControlAsistencia.FindAsync(id);
            if (sipTblControlAsistencia == null)
            {
                return NotFound();
            }
            ViewData["SipTblEmpId"] = new SelectList(_context.SipTblEmpleado, "SipTblEmpId", "SipTblEmpId", sipTblControlAsistencia.SipTblEmpId);
            return View(sipTblControlAsistencia);
        }

        // POST: SipTblControlAsistencias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SipTblCasId,SipTblEmpId,SipTblCasFechaHoraEntrada,SipTblCasFechaHoraSalida")] SipTblControlAsistencia sipTblControlAsistencia)
        {
            if (id != sipTblControlAsistencia.SipTblCasId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sipTblControlAsistencia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SipTblControlAsistenciaExists(sipTblControlAsistencia.SipTblCasId))
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
            ViewData["SipTblEmpId"] = new SelectList(_context.SipTblEmpleado, "SipTblEmpId", "SipTblEmpId", sipTblControlAsistencia.SipTblEmpId);
            return View(sipTblControlAsistencia);
        }

        // GET: SipTblControlAsistencias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sipTblControlAsistencia = await _context.SipTblControlAsistencia
                .Include(s => s.SipTblEmp)
                .FirstOrDefaultAsync(m => m.SipTblCasId == id);
            if (sipTblControlAsistencia == null)
            {
                return NotFound();
            }

            return View(sipTblControlAsistencia);
        }

        // POST: SipTblControlAsistencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sipTblControlAsistencia = await _context.SipTblControlAsistencia.FindAsync(id);
            _context.SipTblControlAsistencia.Remove(sipTblControlAsistencia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SipTblControlAsistenciaExists(int id)
        {
            return _context.SipTblControlAsistencia.Any(e => e.SipTblCasId == id);
        }
    }
}
