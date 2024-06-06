using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Linq;
using TPC_EcoSupport.Data;
using TPC_EcoSupport.Models;

namespace TPC_EcoSupport.Controllers
{
    public class TbInstituicoesController : Controller
    {
        private readonly DataContext _context;

        public TbInstituicoesController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Instituicoes()
        {
            return View(await _context.Instituicoes.ToListAsync());
        }

        public async Task<IActionResult> DashInstituicoes(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbInstituicoes = await _context.Instituicoes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tbInstituicoes == null)
            {
                return NotFound();
            }

            var client = new HttpClient();
            var response = await client.GetAsync("http://ecosupport-production.up.railway.app/exibicoes");
            var jsonString = await response.Content.ReadAsStringAsync();
            var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(jsonString);

            if (apiResponse != null && apiResponse.Embedded != null && apiResponse.Embedded.ExibicaoList != null)
            {
                ViewBag.ExibicaoList = apiResponse.Embedded.ExibicaoList
                    .Where(e => e.Transacao.Contrato.Empresa.Id == id)
                    .ToList();
                ViewBag.Transacao = apiResponse.Embedded.ExibicaoList
                    .Where(e => e.Transacao.Contrato.Empresa.Id == id)
                    .Select(e => e.Transacao)
                    .FirstOrDefault();
                ViewBag.Contrato = apiResponse.Embedded.ExibicaoList
                    .Where(e => e.Transacao.Contrato.Empresa.Id == id)
                    .Select(e => e.Transacao.Contrato)
                    .FirstOrDefault();
            }
            else
            {
                ViewBag.ExibicaoList = new List<Exibicao>();
                ViewBag.Transacao = null;
                ViewBag.Contrato = null;
            }

            return View(tbInstituicoes);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CriarInstituicao([Bind("Id,Nome,Cnpj,Email,Telefone,Endereco")] TbInstituicoes tbInstituicoes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbInstituicoes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbInstituicoes);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateInstituicao(decimal id, [Bind("Id,Nome,Cnpj,Email,Telefone,Endereco")] TbInstituicoes tbInstituicoes)
        {
            if (id != tbInstituicoes.Id)
            {
                return BadRequest("ID não encontrado.");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbInstituicoes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbInstituicoesExists(tbInstituicoes.Id))
                    {
                        return BadRequest("Instituição não existente.");
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tbInstituicoes);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteInstituicao(decimal id)
        {
            var tbInstituicoes = await _context.Instituicoes.FindAsync(id);
            _context.Instituicoes.Remove(tbInstituicoes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbInstituicoesExists(decimal id)
        {
            return _context.Instituicoes.Any(e => e.Id == id);
        }
    }
}
