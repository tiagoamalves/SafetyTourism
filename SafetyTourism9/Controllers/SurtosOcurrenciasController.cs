using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SafetyTourism.Data;
using SafetyTourism.Models;

namespace SafetyTourism.Controllers
{
    [Authorize(Policy = "ElevatedRights")]
    public class SurtosOcurrenciasController : Controller
    {
        private readonly SafetyTourismdb _context;

        public SurtosOcurrenciasController(SafetyTourismdb context)
        {
            _context = context;
        }

        // GET: SurtosOcurrencias
        public async Task<IActionResult> Index()
        {
            var safetyTourismdb = _context.SurtosOcurrencias.Include(s => s.DestinoTuristico).Include(s => s.SurtosEpidemiologico);
            return View(await safetyTourismdb.ToListAsync());
        }

        // GET: SurtosOcurrencias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var surtosOcurrencia = await _context.SurtosOcurrencias
                .Include(s => s.DestinoTuristico)
                .Include(s => s.SurtosEpidemiologico)
                .FirstOrDefaultAsync(m => m.SurtosOcurrenciaID == id);
            if (surtosOcurrencia == null)
            {
                return NotFound();
            }

            return View(surtosOcurrencia);
        }

        // GET: SurtosOcurrencias/Create
        public IActionResult Create()
        {
            ViewData["DestinoTuristicoID"] = new SelectList(_context.DestinoTuristicos, "DestinoTuristicoID", "NomeDestino");
            ViewData["SurtosEpidemiologicoID"] = new SelectList(_context.SurtosEpidemiologicos, "SurtosEpidemiologicoID", "NomeSurto");
            return View();
        }

        // POST: SurtosOcurrencias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SurtosOcurrenciaID,DataInicio,SurtosEpidemiologicoID,DestinoTuristicoID")] SurtosOcurrencia surtosOcurrencia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(surtosOcurrencia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DestinoTuristicoID"] = new SelectList(_context.DestinoTuristicos, "DestinoTuristicoID", "NomeDestino", surtosOcurrencia.DestinoTuristicoID);
            ViewData["SurtosEpidemiologicoID"] = new SelectList(_context.SurtosEpidemiologicos, "SurtosEpidemiologicoID", "NomeSurto", surtosOcurrencia.SurtosEpidemiologicoID);
            return View(surtosOcurrencia);
        }

        // GET: SurtosOcurrencias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var surtosOcurrencia = await _context.SurtosOcurrencias.FindAsync(id);
            if (surtosOcurrencia == null)
            {
                return NotFound();
            }
            ViewData["DestinoTuristicoID"] = new SelectList(_context.DestinoTuristicos, "DestinoTuristicoID", "NomeDestino", surtosOcurrencia.DestinoTuristicoID);
            ViewData["SurtosEpidemiologicoID"] = new SelectList(_context.SurtosEpidemiologicos, "SurtosEpidemiologicoID", "NomeSurto", surtosOcurrencia.SurtosEpidemiologicoID);
            return View(surtosOcurrencia);
        }

        // POST: SurtosOcurrencias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SurtosOcurrenciaID,DataInicio,SurtosEpidemiologicoID,DestinoTuristicoID")] SurtosOcurrencia surtosOcurrencia)
        {
            if (id != surtosOcurrencia.SurtosOcurrenciaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(surtosOcurrencia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SurtosOcurrenciaExists(surtosOcurrencia.SurtosOcurrenciaID))
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
            ViewData["DestinoTuristicoID"] = new SelectList(_context.DestinoTuristicos, "DestinoTuristicoID", "NomeDestino", surtosOcurrencia.DestinoTuristicoID);
            ViewData["SurtosEpidemiologicoID"] = new SelectList(_context.SurtosEpidemiologicos, "SurtosEpidemiologicoID", "NomeSurto", surtosOcurrencia.SurtosEpidemiologicoID);
            return View(surtosOcurrencia);
        }

        // GET: SurtosOcurrencias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var surtosOcurrencia = await _context.SurtosOcurrencias
                .Include(s => s.DestinoTuristico)
                .Include(s => s.SurtosEpidemiologico)
                .FirstOrDefaultAsync(m => m.SurtosOcurrenciaID == id);
            if (surtosOcurrencia == null)
            {
                return NotFound();
            }

            return View(surtosOcurrencia);
        }

        // POST: SurtosOcurrencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var surtosOcurrencia = await _context.SurtosOcurrencias.FindAsync(id);
            _context.SurtosOcurrencias.Remove(surtosOcurrencia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SurtosOcurrenciaExists(int id)
        {
            return _context.SurtosOcurrencias.Any(e => e.SurtosOcurrenciaID == id);
        }
    }
}
