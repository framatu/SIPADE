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
    public class SipTblEncabezadoPlanillasController : Controller
    {
        private readonly SIPADEContext _context;

        public SipTblEncabezadoPlanillasController(SIPADEContext context)
        {
            _context = context;
        }

        // GET: SipTblEncabezadoPlanillas
        public async Task<IActionResult> Index()
        {
            return View(await _context.SipTblEncabezadoPlanilla.ToListAsync());
        }

        // GET: SipTblEncabezadoPlanillas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sipTblEncabezadoPlanilla = await _context.SipTblEncabezadoPlanilla
                .FirstOrDefaultAsync(m => m.SipTblEplId == id);
            if (sipTblEncabezadoPlanilla == null)
            {
                return NotFound();
            }

            return View(sipTblEncabezadoPlanilla);
        }

        // GET: SipTblEncabezadoPlanillas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SipTblEncabezadoPlanillas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SipTblEplId,SipTblEplFechahora,SipTblEplFechainicio,SipTblEplFechafin")] SipTblEncabezadoPlanilla sipTblEncabezadoPlanilla)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sipTblEncabezadoPlanilla);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sipTblEncabezadoPlanilla);
        }

        // GET: SipTblEncabezadoPlanillas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sipTblEncabezadoPlanilla = await _context.SipTblEncabezadoPlanilla.FindAsync(id);
            if (sipTblEncabezadoPlanilla == null)
            {
                return NotFound();
            }
            return View(sipTblEncabezadoPlanilla);
        }

        // POST: SipTblEncabezadoPlanillas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SipTblEplId,SipTblEplFechahora,SipTblEplFechainicio,SipTblEplFechafin")] SipTblEncabezadoPlanilla sipTblEncabezadoPlanilla)
        {
            if (id != sipTblEncabezadoPlanilla.SipTblEplId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sipTblEncabezadoPlanilla);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SipTblEncabezadoPlanillaExists(sipTblEncabezadoPlanilla.SipTblEplId))
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
            return View(sipTblEncabezadoPlanilla);
        }

        // GET: SipTblEncabezadoPlanillas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sipTblEncabezadoPlanilla = await _context.SipTblEncabezadoPlanilla
                .FirstOrDefaultAsync(m => m.SipTblEplId == id);
            if (sipTblEncabezadoPlanilla == null)
            {
                return NotFound();
            }

            return View(sipTblEncabezadoPlanilla);
        }

        // POST: SipTblEncabezadoPlanillas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sipTblEncabezadoPlanilla = await _context.SipTblEncabezadoPlanilla.FindAsync(id);
            _context.SipTblEncabezadoPlanilla.Remove(sipTblEncabezadoPlanilla);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SipTblEncabezadoPlanillaExists(int id)
        {
            return _context.SipTblEncabezadoPlanilla.Any(e => e.SipTblEplId == id);
        }
    }
}
