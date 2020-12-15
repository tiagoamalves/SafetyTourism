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
    public class GravidadeSurtoesController : Controller
    {
        private readonly SafetyTourismdb _context;

        public GravidadeSurtoesController(SafetyTourismdb context)
        {
            _context = context;
        }

        // GET: GravidadeSurtoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.GravidadeSurtos.ToListAsync());
        }

        // GET: GravidadeSurtoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gravidadeSurto = await _context.GravidadeSurtos
                .FirstOrDefaultAsync(m => m.GravidadeSurtoID == id);
            if (gravidadeSurto == null)
            {
                return NotFound();
            }

            return View(gravidadeSurto);
        }

        // GET: GravidadeSurtoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GravidadeSurtoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GravidadeSurtoID,DataRegisto,NivelGravidade")] GravidadeSurto gravidadeSurto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gravidadeSurto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gravidadeSurto);
        }

        // GET: GravidadeSurtoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gravidadeSurto = await _context.GravidadeSurtos.FindAsync(id);
            if (gravidadeSurto == null)
            {
                return NotFound();
            }
            return View(gravidadeSurto);
        }

        // POST: GravidadeSurtoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GravidadeSurtoID,DataRegisto,NivelGravidade")] GravidadeSurto gravidadeSurto)
        {
            if (id != gravidadeSurto.GravidadeSurtoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gravidadeSurto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GravidadeSurtoExists(gravidadeSurto.GravidadeSurtoID))
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
            return View(gravidadeSurto);
        }

        // GET: GravidadeSurtoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gravidadeSurto = await _context.GravidadeSurtos
                .FirstOrDefaultAsync(m => m.GravidadeSurtoID == id);
            if (gravidadeSurto == null)
            {
                return NotFound();
            }

            return View(gravidadeSurto);
        }

        // POST: GravidadeSurtoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gravidadeSurto = await _context.GravidadeSurtos.FindAsync(id);
            _context.GravidadeSurtos.Remove(gravidadeSurto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GravidadeSurtoExists(int id)
        {
            return _context.GravidadeSurtos.Any(e => e.GravidadeSurtoID == id);
        }
    }
}
