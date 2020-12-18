using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/Formandoes]")]
    [ApiController]
    public class FormandoesController : ControllerBase
    {
        private readonly TodoContext _context;

        public FormandoesController(TodoContext context)
        {
            _context = context;
        }

        // GET: api/Formandoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Formando>>> GetFormando()
        {
            return await _context.Formando.ToListAsync();
        }

        // GET: api/Formandoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Formando>> GetFormando(int id)
        {
            var formando = await _context.Formando.FindAsync(id);

            if (formando == null)
            {
                return NotFound();
            }

            return formando;
        }

        // PUT: api/Formandoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFormando(int id, Formando formando)
        {
            if (id != formando.FormandoId)
            {
                return BadRequest();
            }

            _context.Entry(formando).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FormandoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Formandoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Formando>> PostFormando(Formando formando)
        {
            _context.Formando.Add(formando);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFormando), new { id = formando.FormandoId }, formando);
        }

        // DELETE: api/Formandoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFormando(int id)
        {
            var formando = await _context.Formando.FindAsync(id);
            if (formando == null)
            {
                return NotFound();
            }

            _context.Formando.Remove(formando);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FormandoExists(int id)
        {
            return _context.Formando.Any(e => e.FormandoId == id);
        }
    }
}
