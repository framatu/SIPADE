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
    public class SipTblDetallePlanillasController : Controller
    {
        private readonly SIPADEContext _context;

        public SipTblDetallePlanillasController(SIPADEContext context)
        {
            _context = context;
        }

        // GET: SipTblDetallePlanillas
        public async Task<IActionResult> Index()
        {
            var sIPADEContext = _context.SipTblDetallePlanilla.Include(s => s.SipTblEpl).Include(s => s.SipTblTre);
            return View(await sIPADEContext.ToListAsync());
        }

        // GET: SipTblDetallePlanillas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sipTblDetallePlanilla = await _context.SipTblDetallePlanilla
                .Include(s => s.SipTblEpl)
                .Include(s => s.SipTblTre)
                .FirstOrDefaultAsync(m => m.SipTblDplId == id);
            if (sipTblDetallePlanilla == null)
            {
                return NotFound();
            }

            return View(sipTblDetallePlanilla);
        }

        // GET: SipTblDetallePlanillas/Create
        public IActionResult Create()
        {
            ViewData["SipTblEplId"] = new SelectList(_context.SipTblEncabezadoPlanilla, "SipTblEplId", "SipTblEplId");
            ViewData["SipTblTreId"] = new SelectList(_context.SipTblTrabajoRealizado, "SipTblTreId", "SipTblTreId");
            return View();
        }

        // POST: SipTblDetallePlanillas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SipTblDplId,SipTblEplId,SipTblTreId,SipTblDedDeducciones,SipTblDplBonificacion,SipTblDplIgss,SipTblDplIrtra,SipTblDplIsr,SipTblDplOtros")] SipTblDetallePlanilla sipTblDetallePlanilla)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sipTblDetallePlanilla);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SipTblEplId"] = new SelectList(_context.SipTblEncabezadoPlanilla, "SipTblEplId", "SipTblEplId", sipTblDetallePlanilla.SipTblEplId);
            ViewData["SipTblTreId"] = new SelectList(_context.SipTblTrabajoRealizado, "SipTblTreId", "SipTblTreId", sipTblDetallePlanilla.SipTblTreId);
            return View(sipTblDetallePlanilla);
        }

        // GET: SipTblDetallePlanillas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sipTblDetallePlanilla = await _context.SipTblDetallePlanilla.FindAsync(id);
            if (sipTblDetallePlanilla == null)
            {
                return NotFound();
            }
            ViewData["SipTblEplId"] = new SelectList(_context.SipTblEncabezadoPlanilla, "SipTblEplId", "SipTblEplId", sipTblDetallePlanilla.SipTblEplId);
            ViewData["SipTblTreId"] = new SelectList(_context.SipTblTrabajoRealizado, "SipTblTreId", "SipTblTreId", sipTblDetallePlanilla.SipTblTreId);
            return View(sipTblDetallePlanilla);
        }

        // POST: SipTblDetallePlanillas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SipTblDplId,SipTblEplId,SipTblTreId,SipTblDedDeducciones,SipTblDplBonificacion,SipTblDplIgss,SipTblDplIrtra,SipTblDplIsr,SipTblDplOtros")] SipTblDetallePlanilla sipTblDetallePlanilla)
        {
            if (id != sipTblDetallePlanilla.SipTblDplId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sipTblDetallePlanilla);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SipTblDetallePlanillaExists(sipTblDetallePlanilla.SipTblDplId))
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
            ViewData["SipTblEplId"] = new SelectList(_context.SipTblEncabezadoPlanilla, "SipTblEplId", "SipTblEplId", sipTblDetallePlanilla.SipTblEplId);
            ViewData["SipTblTreId"] = new SelectList(_context.SipTblTrabajoRealizado, "SipTblTreId", "SipTblTreId", sipTblDetallePlanilla.SipTblTreId);
            return View(sipTblDetallePlanilla);
        }

        // GET: SipTblDetallePlanillas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sipTblDetallePlanilla = await _context.SipTblDetallePlanilla
                .Include(s => s.SipTblEpl)
                .Include(s => s.SipTblTre)
                .FirstOrDefaultAsync(m => m.SipTblDplId == id);
            if (sipTblDetallePlanilla == null)
            {
                return NotFound();
            }

            return View(sipTblDetallePlanilla);
        }

        // POST: SipTblDetallePlanillas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sipTblDetallePlanilla = await _context.SipTblDetallePlanilla.FindAsync(id);
            _context.SipTblDetallePlanilla.Remove(sipTblDetallePlanilla);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SipTblDetallePlanillaExists(int id)
        {
            return _context.SipTblDetallePlanilla.Any(e => e.SipTblDplId == id);
        }
    }
}
