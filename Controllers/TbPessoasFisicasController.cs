using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TPC_EcoSupport.Data;
using TPC_EcoSupport.Models;

namespace TPC_EcoSupport.Controllers
{
    public class TbPessoasFisicasController : Controller
    {
        private readonly DataContext _context;

        public TbPessoasFisicasController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> PessoasFisicas()
        {
            return View(await _context.PessoasFisicas.ToListAsync());
        }

        public async Task<IActionResult> DashPessoasFisicas(decimal? id)
        {
            var pessoaFisica = await _context.PessoasFisicas
                .FirstOrDefaultAsync(p => p.Id == id);

            if (pessoaFisica == null)
            {
                return NotFound();
            }

            var client = new HttpClient();
            var responseExibicoes = await client.GetAsync("http://ecosupport-production.up.railway.app/exibicoes");
            var jsonStringExibicoes = await responseExibicoes.Content.ReadAsStringAsync();
            var apiResponseExibicoes = JsonConvert.DeserializeObject<ApiResponse>(jsonStringExibicoes);

            var responseInstituicoes = await client.GetAsync("http://ecosupport-production.up.railway.app/instituicoes");
            var jsonStringInstituicoes = await responseInstituicoes.Content.ReadAsStringAsync();
            var apiResponseInstituicoes = JsonConvert.DeserializeObject<ApiResponse>(jsonStringInstituicoes);


            if (apiResponseExibicoes != null && apiResponseExibicoes.Embedded != null && apiResponseExibicoes.Embedded.ExibicaoList != null &&
        apiResponseInstituicoes != null && apiResponseInstituicoes.Embedded != null && apiResponseInstituicoes.Embedded.InstituicaoList != null)
            {
                ViewBag.ExibicaoList = apiResponseExibicoes.Embedded.ExibicaoList;
                ViewBag.InstituicaoList = apiResponseInstituicoes.Embedded.InstituicaoList;
            }
            else
            {
                ViewBag.ExibicaoList = new List<Exibicao>();
                ViewBag.InstituicaoList = new List<Instituicao>();
            }

            return View(pessoaFisica);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePessoaFisica([Bind("Id,Nome,Cpf,Email,Senha")] TbPessoasFisicas tbPessoasFisicas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbPessoasFisicas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbPessoasFisicas);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdatePessoaFisica(decimal id, [Bind("Id,Nome,Cpf,Email,Senha")] TbPessoasFisicas tbPessoasFisicas)
        {
            if (id != tbPessoasFisicas.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbPessoasFisicas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbPessoasFisicasExists(tbPessoasFisicas.Id))
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
            return View(tbPessoasFisicas);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePessoaFisica(decimal id)
        {
            var tbPessoasFisicas = await _context.PessoasFisicas.FindAsync(id);
            _context.PessoasFisicas.Remove(tbPessoasFisicas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbPessoasFisicasExists(decimal id)
        {
            return _context.PessoasFisicas.Any(e => e.Id == id);
        }
    }
}
