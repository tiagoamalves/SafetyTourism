using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Abp.Authorization.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Newtonsoft.Json;
using SafetyTourism.Data;
using SafetyTourism.Models;

namespace SafetyTourism.Controllers
{
    [Authorize(Policy = "UserOperatorPolicy")]
    public class DestinoTuristicoesController : Controller
    {
        private readonly SafetyTourismdb _context;
        public bool a = true;
        private readonly IConfiguration _configure;
        private readonly string apiBaseUrl;
        public DestinoTuristicoesController(IConfiguration configuration)
        {
            _configure = configuration;
            apiBaseUrl = _configure.GetValue<string>("WebAPIBaseUrl");
        }
        // Construtor do controller
        /*public DestinoTuristicoesController(SafetyTourismdb context)
        {
            _context = context;
        }*/

        [Authorize(Policy= "UserOperatorPolicy")]
        // GET: DestinoTuristicoes
        public async Task<IActionResult> Index(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;
            var listadestinosTuristicoes = new List<DestinoTuristico>();
            using (HttpClient client = new HttpClient())
            {
                UserInfo user = new UserInfo();
                StringContent contentUser = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                var responseLogin = await client.PostAsync(apiBaseUrl + "/users/login", contentUser);
                UserToken token = await responseLogin.Content.ReadAsAsync<UserToken>();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Token);
                string endpoint = apiBaseUrl + "/Zonas";
                var response = await client.GetAsync(endpoint);
                response.EnsureSuccessStatusCode();
                listadestinosTuristicoes = await response.Content.ReadAsAsync<List<DestinoTuristico>>();
            }
            return View(listadestinosTuristicoes);

            /*ViewData["CurrentFilter"] = searchString;

            var destinoTuristico = from s in _context.DestinoTuristicos select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                destinoTuristico = destinoTuristico.Where(s => s.NomeDestino.Contains(searchString));                                
            }*/

        }

        //cc GET: DestinoTuristicoes/Details/5
        [Authorize(Policy = "UserOperatorPolicy")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var destinoTuristico = await _context.DestinoTuristicos
                  .Include(s => s.SurtosOcurrencias)
                     .ThenInclude(o => o.SurtosEpidemiologico)
                     .ThenInclude(p => p.GravidadeSurto)
                  .Include(q => q.SurtosOcurrencias)
                      .ThenInclude(s => s.SurtosEpidemiologico)
                      .ThenInclude(t => t.GrupoRisco)
                  .Include(k => k.SurtosOcurrencias)
                      .ThenInclude(y => y.SurtosEpidemiologico)
                      .ThenInclude(z => z.Recomendacoe)
                  .Include(s => s.SurtosOcurrencias)
                      .ThenInclude(s => s.SurtosEpidemiologico)
                      .ThenInclude(e => e.Sintoma)

                  .AsNoTracking()
                .FirstOrDefaultAsync(m => m.DestinoTuristicoID == id);


            if (destinoTuristico == null)
            {
                return NotFound();
            }

            return View(destinoTuristico);

        }
        public async Task<IActionResult> ViewReport(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var destinoTuristico = await _context.DestinoTuristicos
                .Include(s => s.SurtosOcurrencias)
                  .ThenInclude(s => s.SurtosEpidemiologico)
                     .ThenInclude(e => e.GravidadeSurto)
                  .Include(s => s.SurtosOcurrencias)
                     .ThenInclude(s => s.SurtosEpidemiologico)
                    .ThenInclude(e => e.GrupoRisco)
                    .Include(s => s.SurtosOcurrencias)
                     .ThenInclude(s => s.SurtosEpidemiologico)
                     .ThenInclude(e => e.Recomendacoe)
                    .Include(s => s.SurtosOcurrencias)
                     .ThenInclude(s => s.SurtosEpidemiologico)
                    .ThenInclude(e => e.Sintoma)
                   



                  .AsNoTracking()
                .FirstOrDefaultAsync(m => m.DestinoTuristicoID == id);
            if (destinoTuristico == null)
            {
                return NotFound();
            }

            return View(destinoTuristico);

        }

        // GET: DestinoTuristicoes/Create
        [Authorize(Policy = "ElevatedRights")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: DestinoTuristicoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "ElevatedRights")]
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
        [Authorize(Policy = "ElevatedRights")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var destinoTuristico = await _context.DestinoTuristicos.FindAsync(id);
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
        [Authorize(Policy = "ElevatedRights")]
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
        [Authorize(Policy = "ElevatedRights")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var destinoTuristico = await _context.DestinoTuristicos
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
        [Authorize(Policy = "ElevatedRights")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var destinoTuristico = await _context.DestinoTuristicos.FindAsync(id);
            _context.DestinoTuristicos.Remove(destinoTuristico);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DestinoTuristicoExists(int id)
        {
            return _context.DestinoTuristicos.Any(e => e.DestinoTuristicoID == id);
        }
    }
}
