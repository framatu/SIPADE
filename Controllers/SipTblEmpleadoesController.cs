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
    public class SipTblEmpleadoesController : Controller
    {
        private readonly SIPADEContext _context;

        public SipTblEmpleadoesController(SIPADEContext context)
        {
            _context = context;
        }

        // GET: SipTblEmpleadoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.SipTblEmpleado.ToListAsync());
        }

        // GET: SipTblEmpleadoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sipTblEmpleado = await _context.SipTblEmpleado
                .FirstOrDefaultAsync(m => m.SipTblEmpId == id);
            if (sipTblEmpleado == null)
            {
                return NotFound();
            }

            return View(sipTblEmpleado);
        }

        // GET: SipTblEmpleadoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SipTblEmpleadoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SipTblEmpId,SipTblEmpNombres,SipTblEmpApellidos,SipTblEmpNit,SipTblEmpDpi,SipTblEmpTel,SipTblEmpDireccion,SipTblEmpNumigss,SipTblEmpNumirtra")] SipTblEmpleado sipTblEmpleado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sipTblEmpleado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sipTblEmpleado);
        }

        // GET: SipTblEmpleadoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sipTblEmpleado = await _context.SipTblEmpleado.FindAsync(id);
            if (sipTblEmpleado == null)
            {
                return NotFound();
            }
            return View(sipTblEmpleado);
        }

        // POST: SipTblEmpleadoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SipTblEmpId,SipTblEmpNombres,SipTblEmpApellidos,SipTblEmpNit,SipTblEmpDpi,SipTblEmpTel,SipTblEmpDireccion,SipTblEmpNumigss,SipTblEmpNumirtra")] SipTblEmpleado sipTblEmpleado)
        {
            if (id != sipTblEmpleado.SipTblEmpId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sipTblEmpleado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SipTblEmpleadoExists(sipTblEmpleado.SipTblEmpId))
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
            return View(sipTblEmpleado);
        }

        // GET: SipTblEmpleadoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sipTblEmpleado = await _context.SipTblEmpleado
                .FirstOrDefaultAsync(m => m.SipTblEmpId == id);
            if (sipTblEmpleado == null)
            {
                return NotFound();
            }

            return View(sipTblEmpleado);
        }

        // POST: SipTblEmpleadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sipTblEmpleado = await _context.SipTblEmpleado.FindAsync(id);
            _context.SipTblEmpleado.Remove(sipTblEmpleado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SipTblEmpleadoExists(int id)
        {
            return _context.SipTblEmpleado.Any(e => e.SipTblEmpId == id);
        }
    }
}
