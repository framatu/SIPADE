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
    public class SipTblTipoActividadsController : Controller
    {
        private readonly SIPADEContext _context;

        public SipTblTipoActividadsController(SIPADEContext context)
        {
            _context = context;
        }

        // GET: SipTblTipoActividads
        public async Task<IActionResult> Index()
        {
            return View(await _context.SipTblTipoActividad.ToListAsync());
        }

        // GET: SipTblTipoActividads/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sipTblTipoActividad = await _context.SipTblTipoActividad
                .FirstOrDefaultAsync(m => m.SipTblActId == id);
            if (sipTblTipoActividad == null)
            {
                return NotFound();
            }

            return View(sipTblTipoActividad);
        }

        // GET: SipTblTipoActividads/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SipTblTipoActividads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SipTblActId,SipTblActNombre,SipTblActCostoact")] SipTblTipoActividad sipTblTipoActividad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sipTblTipoActividad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sipTblTipoActividad);
        }

        // GET: SipTblTipoActividads/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sipTblTipoActividad = await _context.SipTblTipoActividad.FindAsync(id);
            if (sipTblTipoActividad == null)
            {
                return NotFound();
            }
            return View(sipTblTipoActividad);
        }

        // POST: SipTblTipoActividads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SipTblActId,SipTblActNombre,SipTblActCostoact")] SipTblTipoActividad sipTblTipoActividad)
        {
            if (id != sipTblTipoActividad.SipTblActId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sipTblTipoActividad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SipTblTipoActividadExists(sipTblTipoActividad.SipTblActId))
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
            return View(sipTblTipoActividad);
        }

        // GET: SipTblTipoActividads/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sipTblTipoActividad = await _context.SipTblTipoActividad
                .FirstOrDefaultAsync(m => m.SipTblActId == id);
            if (sipTblTipoActividad == null)
            {
                return NotFound();
            }

            return View(sipTblTipoActividad);
        }

        // POST: SipTblTipoActividads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sipTblTipoActividad = await _context.SipTblTipoActividad.FindAsync(id);
            _context.SipTblTipoActividad.Remove(sipTblTipoActividad);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SipTblTipoActividadExists(int id)
        {
            return _context.SipTblTipoActividad.Any(e => e.SipTblActId == id);
        }
    }
}
