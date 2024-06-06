using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TPC_EcoSupport.Data;
using TPC_EcoSupport.Models;

namespace TPC_EcoSupport.Controllers
{
    public class TbExibicoesController : Controller
    {
        private readonly DataContext _context;

        public TbExibicoesController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Exibicoes()
        {
            return View(await _context.Exibicoes.ToListAsync());
        }

        public async Task<IActionResult> GetById(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbExibicoes = await _context.Exibicoes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tbExibicoes == null)
            {
                return NotFound();
            }

            return View(tbExibicoes);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateExibicao([Bind("Id,IdTransacao,Valor,DataExibicao,Descricao")] TbExibicoes tbExibicoes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbExibicoes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbExibicoes);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateExibicao(decimal id, [Bind("Id,IdTransacao,Valor,DataExibicao,Descricao")] TbExibicoes tbExibicoes)
        {
            if (id != tbExibicoes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbExibicoes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbExibicoesExists(tbExibicoes.Id))
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
            return View(tbExibicoes);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteExibicao(decimal id)
        {
            var tbExibicoes = await _context.Exibicoes.FindAsync(id);
            _context.Exibicoes.Remove(tbExibicoes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbExibicoesExists(decimal id)
        {
            return _context.Exibicoes.Any(e => e.Id == id);
        }
    }
}
