using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SafetyTourismPaulo.Data;
using SafetyTourismPaulo.Models;

namespace SafetyTourismPaulo.Controllers
{
    public class SurtosEpidemiologicoesController : Controller
    {
        private readonly SafetyTourism _context;

        public SurtosEpidemiologicoesController(SafetyTourism context)
        {
            _context = context;
        }

        // GET: SurtosEpidemiologicoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.SurtosEpidemiologico.ToListAsync());
        }

        // GET: SurtosEpidemiologicoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var surtosEpidemiologico = await _context.SurtosEpidemiologico
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
            return View(surtosEpidemiologico);
        }

        // GET: SurtosEpidemiologicoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var surtosEpidemiologico = await _context.SurtosEpidemiologico.FindAsync(id);
            if (surtosEpidemiologico == null)
            {
                return NotFound();
            }
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
            return View(surtosEpidemiologico);
        }

        // GET: SurtosEpidemiologicoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var surtosEpidemiologico = await _context.SurtosEpidemiologico
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
            var surtosEpidemiologico = await _context.SurtosEpidemiologico.FindAsync(id);
            _context.SurtosEpidemiologico.Remove(surtosEpidemiologico);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SurtosEpidemiologicoExists(int id)
        {
            return _context.SurtosEpidemiologico.Any(e => e.SurtosEpidemiologicoID == id);
        }
    }
}
