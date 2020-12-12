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
    public class DestinoTuristicoesController : Controller
    {
        private readonly SafetyTourism _context;

        public DestinoTuristicoesController(SafetyTourism context)
        {
            _context = context;
        }

        // GET: DestinoTuristicoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.DestinoTuristico.ToListAsync());
        }

        // GET: DestinoTuristicoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var destinoTuristico = await _context.DestinoTuristico
                .FirstOrDefaultAsync(m => m.DestinoTuristicoID == id);
            if (destinoTuristico == null)
            {
                return NotFound();
            }

            return View(destinoTuristico);
        }

        // GET: DestinoTuristicoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DestinoTuristicoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DestinoTuristicoID,NomeDestino,DensidadeDemografica,Pais,Continente")] DestinoTuristico destinoTuristico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(destinoTuristico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(destinoTuristico);
        }

        // GET: DestinoTuristicoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var destinoTuristico = await _context.DestinoTuristico.FindAsync(id);
            if (destinoTuristico == null)
            {
                return NotFound();
            }
            return View(destinoTuristico);
        }

        // POST: DestinoTuristicoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DestinoTuristicoID,NomeDestino,DensidadeDemografica,Pais,Continente")] DestinoTuristico destinoTuristico)
        {
            if (id != destinoTuristico.DestinoTuristicoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(destinoTuristico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DestinoTuristicoExists(destinoTuristico.DestinoTuristicoID))
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
            return View(destinoTuristico);
        }

        // GET: DestinoTuristicoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var destinoTuristico = await _context.DestinoTuristico
                .FirstOrDefaultAsync(m => m.DestinoTuristicoID == id);
            if (destinoTuristico == null)
            {
                return NotFound();
            }

            return View(destinoTuristico);
        }

        // POST: DestinoTuristicoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var destinoTuristico = await _context.DestinoTuristico.FindAsync(id);
            _context.DestinoTuristico.Remove(destinoTuristico);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DestinoTuristicoExists(int id)
        {
            return _context.DestinoTuristico.Any(e => e.DestinoTuristicoID == id);
        }
    }
}
