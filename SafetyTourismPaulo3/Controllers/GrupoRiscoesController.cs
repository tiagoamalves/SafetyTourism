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
    public class GrupoRiscoesController : Controller
    {
        private readonly SafetyTourismdb _context;

        public GrupoRiscoesController(SafetyTourismdb context)
        {
            _context = context;
        }

        // GET: GrupoRiscoes
        public async Task<IActionResult> Index()
        {
            var safetyTourismdb = _context.GrupoRiscos.Include(g => g.Doenca);
            return View(await safetyTourismdb.ToListAsync());
        }

        // GET: GrupoRiscoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grupoRisco = await _context.GrupoRiscos
                .Include(g => g.Doenca)
                .FirstOrDefaultAsync(m => m.GrupoRiscoID == id);
            if (grupoRisco == null)
            {
                return NotFound();
            }

            return View(grupoRisco);
        }

        // GET: GrupoRiscoes/Create
        public IActionResult Create()
        {
            ViewData["DoencaID"] = new SelectList(_context.Doencas, "DoencaID", "DoencaID");
            return View();
        }

        // POST: GrupoRiscoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GrupoRiscoID,FaixaEtaria,Sexo,Etnia,DoencaID")] GrupoRisco grupoRisco)
        {
            if (ModelState.IsValid)
            {
                _context.Add(grupoRisco);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DoencaID"] = new SelectList(_context.Doencas, "DoencaID", "DoencaID", grupoRisco.DoencaID);
            return View(grupoRisco);
        }

        // GET: GrupoRiscoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grupoRisco = await _context.GrupoRiscos.FindAsync(id);
            if (grupoRisco == null)
            {
                return NotFound();
            }
            ViewData["DoencaID"] = new SelectList(_context.Doencas, "DoencaID", "DoencaID", grupoRisco.DoencaID);
            return View(grupoRisco);
        }

        // POST: GrupoRiscoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GrupoRiscoID,FaixaEtaria,Sexo,Etnia,DoencaID")] GrupoRisco grupoRisco)
        {
            if (id != grupoRisco.GrupoRiscoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(grupoRisco);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GrupoRiscoExists(grupoRisco.GrupoRiscoID))
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
            ViewData["DoencaID"] = new SelectList(_context.Doencas, "DoencaID", "DoencaID", grupoRisco.DoencaID);
            return View(grupoRisco);
        }

        // GET: GrupoRiscoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grupoRisco = await _context.GrupoRiscos
                .Include(g => g.Doenca)
                .FirstOrDefaultAsync(m => m.GrupoRiscoID == id);
            if (grupoRisco == null)
            {
                return NotFound();
            }

            return View(grupoRisco);
        }

        // POST: GrupoRiscoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var grupoRisco = await _context.GrupoRiscos.FindAsync(id);
            _context.GrupoRiscos.Remove(grupoRisco);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GrupoRiscoExists(int id)
        {
            return _context.GrupoRiscos.Any(e => e.GrupoRiscoID == id);
        }
    }
}
