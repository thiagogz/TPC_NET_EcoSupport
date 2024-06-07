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

            // Query the database for the exhibitions (exibicoes) related to the institution's transactions
            var exibicoesList = await _context.Exibicoes
                .Include(e => e.Transacao)
                .ThenInclude(t => t.Contrato)
                .Where(e => e.Transacao.Contrato.Empresa.Id == id)
                .ToListAsync();

            ViewBag.ExibicaoList = exibicoesList;

            // Assuming there is only one transaction and one contract per exhibition list
            var transacao = exibicoesList.Select(e => e.Transacao).FirstOrDefault();
            var contrato = exibicoesList.Select(e => e.Transacao.Contrato).FirstOrDefault();

            ViewBag.Transacao = transacao;
            ViewBag.Contrato = contrato;

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
