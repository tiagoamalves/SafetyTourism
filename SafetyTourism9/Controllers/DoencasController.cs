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
    public class DoencasController : Controller
    {
        private readonly SafetyTourismdb _context;

        public DoencasController(SafetyTourismdb context)
        {
            _context = context;
        }

        // GET: Doencas
        [Authorize(Policy = "ElevatedRights")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Doencas.ToListAsync());
        }

        // GET: Doencas/Details/5
        [Authorize(Policy = "ElevatedRights")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doenca = await _context.Doencas
                .FirstOrDefaultAsync(m => m.DoencaID == id);
            if (doenca == null)
            {
                return NotFound();
            }
            
            return View(doenca);
        }

        // GET: Doencas/Create
        [Authorize(Policy = "ElevatedRights")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Doencas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "ElevatedRights")]
        public async Task<IActionResult> Create([Bind("DoencaID,NomeDoenca")] Doenca doenca)
        {
            if (ModelState.IsValid)
            {
                _context.Add(doenca);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(doenca);
        }

        // GET: Doencas/Edit/5
        [Authorize(Policy = "ElevatedRights")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doenca = await _context.Doencas.FindAsync(id);
            if (doenca == null)
            {
                return NotFound();
            }
            return View(doenca);
        }

        // POST: Doencas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "ElevatedRights")]
        public async Task<IActionResult> Edit(int id, [Bind("DoencaID,NomeDoenca")] Doenca doenca)
        {
            if (id != doenca.DoencaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doenca);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoencaExists(doenca.DoencaID))
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
            return View(doenca);
        }

        // GET: Doencas/Delete/5
        [Authorize(Policy = "ElevatedRights")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doenca = await _context.Doencas
                .FirstOrDefaultAsync(m => m.DoencaID == id);
            if (doenca == null)
            {
                return NotFound();
            }

            return View(doenca);
        }

        // POST: Doencas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "ElevatedRights")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var doenca = await _context.Doencas.FindAsync(id);
            _context.Doencas.Remove(doenca);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoencaExists(int id)
        {
            return _context.Doencas.Any(e => e.DoencaID == id);
        }
    }
}
