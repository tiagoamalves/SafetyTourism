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
    public class RecomendacoesController : Controller
    {
        private readonly SafetyTourismdb _context;

        public RecomendacoesController(SafetyTourismdb context)
        {
            _context = context;
        }

        // GET: Recomendacoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Recomendacoes.ToListAsync());
        }

        // GET: Recomendacoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recomendacoe = await _context.Recomendacoes
                .FirstOrDefaultAsync(m => m.RecomendacoeID == id);
            if (recomendacoe == null)
            {
                return NotFound();
            }

            return View(recomendacoe);
        }

        // GET: Recomendacoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Recomendacoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RecomendacoeID,DescricaoBreve,DataRegisto,Relatorio")] Recomendacoe recomendacoe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recomendacoe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(recomendacoe);
        }

        // GET: Recomendacoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recomendacoe = await _context.Recomendacoes.FindAsync(id);
            if (recomendacoe == null)
            {
                return NotFound();
            }
            return View(recomendacoe);
        }

        // POST: Recomendacoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RecomendacoeID,DataRegisto,DescricaoBreve,Relatorio")] Recomendacoe recomendacoe)
        {
            if (id != recomendacoe.RecomendacoeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recomendacoe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecomendacoeExists(recomendacoe.RecomendacoeID))
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
            return View(recomendacoe);
        }

        // GET: Recomendacoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recomendacoe = await _context.Recomendacoes
                .FirstOrDefaultAsync(m => m.RecomendacoeID == id);
            if (recomendacoe == null)
            {
                return NotFound();
            }

            return View(recomendacoe);
        }

        // POST: Recomendacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recomendacoe = await _context.Recomendacoes.FindAsync(id);
            _context.Recomendacoes.Remove(recomendacoe);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecomendacoeExists(int id)
        {
            return _context.Recomendacoes.Any(e => e.RecomendacoeID == id);
        }
    }
}
