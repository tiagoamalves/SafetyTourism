using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SafetyTourism.Data;
using SafetyTourism.Models;

namespace SafetyTourism.Controllers
{
    public class SurtosEpidemiologicoesController : Controller
    {
        private readonly SafetyTourismdb _context;

        public SurtosEpidemiologicoesController(SafetyTourismdb context)
        {
            _context = context;
        }

        // GET: SurtosEpidemiologicoes
        public async Task<IActionResult> Index()
        {
            var safetyTourismdb = _context.SurtosEpidemiologicos.Include(s => s.GravidadeSurto).Include(s => s.GrupoRisco).Include(s => s.Recomendacoe).Include(s => s.Sintoma);
            return View(await safetyTourismdb.ToListAsync());
        }

        // GET: SurtosEpidemiologicoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var surtosEpidemiologico = await _context.SurtosEpidemiologicos
                .Include(s => s.GravidadeSurto)
                .Include(s => s.GrupoRisco)
                .Include(s => s.Recomendacoe)
                .Include(s => s.Sintoma)
                .FirstOrDefaultAsync(m => m.SurtosEpidemiologicoID == id);
            if (surtosEpidemiologico == null)
            {
                return NotFound();
            }

            return View(surtosEpidemiologico);
        }

        // GET: SurtosEpidemiologicoes/Create
        public IActionResult Create()
        {
            ViewData["GravidadeSurtoID"] = new SelectList(_context.GravidadeSurtos, "GravidadeSurtoID", "GravidadeSurtoID");
            ViewData["GrupoRiscoID"] = new SelectList(_context.GrupoRiscos, "GrupoRiscoID", "GrupoRiscoID");
            ViewData["RecomendacoeID"] = new SelectList(_context.Recomendacoes, "RecomendacoeID", "RecomendacoeID");
            ViewData["SintomaID"] = new SelectList(_context.Sintomas, "SintomaID", "SintomaID");
            return View();
        }

        // POST: SurtosEpidemiologicoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SurtosEpidemiologicoID,NomeSurto,GrauContagio,IndiceMortalidade,GravidadeSurtoID,RecomendacoeID,SintomaID,GrupoRiscoID")] SurtosEpidemiologico surtosEpidemiologico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(surtosEpidemiologico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GravidadeSurtoID"] = new SelectList(_context.GravidadeSurtos, "GravidadeSurtoID", "GravidadeSurtoID", surtosEpidemiologico.GravidadeSurtoID);
            ViewData["GrupoRiscoID"] = new SelectList(_context.GrupoRiscos, "GrupoRiscoID", "GrupoRiscoID", surtosEpidemiologico.GrupoRiscoID);
            ViewData["RecomendacoeID"] = new SelectList(_context.Recomendacoes, "RecomendacoeID", "RecomendacoeID", surtosEpidemiologico.RecomendacoeID);
            ViewData["SintomaID"] = new SelectList(_context.Sintomas, "SintomaID", "SintomaID", surtosEpidemiologico.SintomaID);
            return View(surtosEpidemiologico);
        }

        // GET: SurtosEpidemiologicoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var surtosEpidemiologico = await _context.SurtosEpidemiologicos.FindAsync(id);
            if (surtosEpidemiologico == null)
            {
                return NotFound();
            }
            ViewData["GravidadeSurtoID"] = new SelectList(_context.GravidadeSurtos, "GravidadeSurtoID", "GravidadeSurtoID", surtosEpidemiologico.GravidadeSurtoID);
            ViewData["GrupoRiscoID"] = new SelectList(_context.GrupoRiscos, "GrupoRiscoID", "GrupoRiscoID", surtosEpidemiologico.GrupoRiscoID);
            ViewData["RecomendacoeID"] = new SelectList(_context.Recomendacoes, "RecomendacoeID", "RecomendacoeID", surtosEpidemiologico.RecomendacoeID);
            ViewData["SintomaID"] = new SelectList(_context.Sintomas, "SintomaID", "SintomaID", surtosEpidemiologico.SintomaID);
            return View(surtosEpidemiologico);
        }

        // POST: SurtosEpidemiologicoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SurtosEpidemiologicoID,NomeSurto,GrauContagio,IndiceMortalidade,GravidadeSurtoID,RecomendacoeID,SintomaID,GrupoRiscoID")] SurtosEpidemiologico surtosEpidemiologico)
        {
            if (id != surtosEpidemiologico.SurtosEpidemiologicoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(surtosEpidemiologico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SurtosEpidemiologicoExists(surtosEpidemiologico.SurtosEpidemiologicoID))
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
            ViewData["GravidadeSurtoID"] = new SelectList(_context.GravidadeSurtos, "GravidadeSurtoID", "GravidadeSurtoID", surtosEpidemiologico.GravidadeSurtoID);
            ViewData["GrupoRiscoID"] = new SelectList(_context.GrupoRiscos, "GrupoRiscoID", "GrupoRiscoID", surtosEpidemiologico.GrupoRiscoID);
            ViewData["RecomendacoeID"] = new SelectList(_context.Recomendacoes, "RecomendacoeID", "RecomendacoeID", surtosEpidemiologico.RecomendacoeID);
            ViewData["SintomaID"] = new SelectList(_context.Sintomas, "SintomaID", "SintomaID", surtosEpidemiologico.SintomaID);
            return View(surtosEpidemiologico);
        }

        // GET: SurtosEpidemiologicoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var surtosEpidemiologico = await _context.SurtosEpidemiologicos
                .Include(s => s.GravidadeSurto)
                .Include(s => s.GrupoRisco)
                .Include(s => s.Recomendacoe)
                .Include(s => s.Sintoma)
                .FirstOrDefaultAsync(m => m.SurtosEpidemiologicoID == id);
            if (surtosEpidemiologico == null)
            {
                return NotFound();
            }

            return View(surtosEpidemiologico);
        }

        // POST: SurtosEpidemiologicoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var surtosEpidemiologico = await _context.SurtosEpidemiologicos.FindAsync(id);
            _context.SurtosEpidemiologicos.Remove(surtosEpidemiologico);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SurtosEpidemiologicoExists(int id)
        {
            return _context.SurtosEpidemiologicos.Any(e => e.SurtosEpidemiologicoID == id);
        }
    }
}
