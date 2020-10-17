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
    public class SipTblTrabajoRealizadoesController : Controller
    {
        private readonly SIPADEContext _context;

        public SipTblTrabajoRealizadoesController(SIPADEContext context)
        {
            _context = context;
        }

        // GET: SipTblTrabajoRealizadoes
        public async Task<IActionResult> Index()
        {
            var sIPADEContext = _context.SipTblTrabajoRealizado.Include(s => s.SipTblAct).Include(s => s.SipTblEmp);
            return View(await sIPADEContext.ToListAsync());
        }

        // GET: SipTblTrabajoRealizadoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sipTblTrabajoRealizado = await _context.SipTblTrabajoRealizado
                .Include(s => s.SipTblAct)
                .Include(s => s.SipTblEmp)
                .FirstOrDefaultAsync(m => m.SipTblTreId == id);
            if (sipTblTrabajoRealizado == null)
            {
                return NotFound();
            }

            return View(sipTblTrabajoRealizado);
        }

        // GET: SipTblTrabajoRealizadoes/Create
        public IActionResult Create()
        {
            ViewData["SipTblActId"] = new SelectList(_context.SipTblTipoActividad, "SipTblActId", "SipTblActId");
            ViewData["SipTblEmpId"] = new SelectList(_context.SipTblEmpleado, "SipTblEmpId", "SipTblEmpId");
            return View();
        }

        // POST: SipTblTrabajoRealizadoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SipTblTreId,SipTblEmpId,SipTblActId,SipTblTreCantidad,SipTblTreTotal")] SipTblTrabajoRealizado sipTblTrabajoRealizado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sipTblTrabajoRealizado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SipTblActId"] = new SelectList(_context.SipTblTipoActividad, "SipTblActId", "SipTblActId", sipTblTrabajoRealizado.SipTblActId);
            ViewData["SipTblEmpId"] = new SelectList(_context.SipTblEmpleado, "SipTblEmpId", "SipTblEmpId", sipTblTrabajoRealizado.SipTblEmpId);
            return View(sipTblTrabajoRealizado);
        }

        // GET: SipTblTrabajoRealizadoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sipTblTrabajoRealizado = await _context.SipTblTrabajoRealizado.FindAsync(id);
            if (sipTblTrabajoRealizado == null)
            {
                return NotFound();
            }
            ViewData["SipTblActId"] = new SelectList(_context.SipTblTipoActividad, "SipTblActId", "SipTblActId", sipTblTrabajoRealizado.SipTblActId);
            ViewData["SipTblEmpId"] = new SelectList(_context.SipTblEmpleado, "SipTblEmpId", "SipTblEmpId", sipTblTrabajoRealizado.SipTblEmpId);
            return View(sipTblTrabajoRealizado);
        }

        // POST: SipTblTrabajoRealizadoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SipTblTreId,SipTblEmpId,SipTblActId,SipTblTreCantidad,SipTblTreTotal")] SipTblTrabajoRealizado sipTblTrabajoRealizado)
        {
            if (id != sipTblTrabajoRealizado.SipTblTreId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sipTblTrabajoRealizado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SipTblTrabajoRealizadoExists(sipTblTrabajoRealizado.SipTblTreId))
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
            ViewData["SipTblActId"] = new SelectList(_context.SipTblTipoActividad, "SipTblActId", "SipTblActId", sipTblTrabajoRealizado.SipTblActId);
            ViewData["SipTblEmpId"] = new SelectList(_context.SipTblEmpleado, "SipTblEmpId", "SipTblEmpId", sipTblTrabajoRealizado.SipTblEmpId);
            return View(sipTblTrabajoRealizado);
        }

        // GET: SipTblTrabajoRealizadoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sipTblTrabajoRealizado = await _context.SipTblTrabajoRealizado
                .Include(s => s.SipTblAct)
                .Include(s => s.SipTblEmp)
                .FirstOrDefaultAsync(m => m.SipTblTreId == id);
            if (sipTblTrabajoRealizado == null)
            {
                return NotFound();
            }

            return View(sipTblTrabajoRealizado);
        }

        // POST: SipTblTrabajoRealizadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sipTblTrabajoRealizado = await _context.SipTblTrabajoRealizado.FindAsync(id);
            _context.SipTblTrabajoRealizado.Remove(sipTblTrabajoRealizado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SipTblTrabajoRealizadoExists(int id)
        {
            return _context.SipTblTrabajoRealizado.Any(e => e.SipTblTreId == id);
        }
    }
}
