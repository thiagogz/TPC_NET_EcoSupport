using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TPC_EcoSupport.Data;
using TPC_EcoSupport.Models;

namespace TPC_EcoSupport.Controllers
{
    public class TbTermosCondicoesController : Controller
    {
        private readonly DataContext _context;

        public TbTermosCondicoesController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> TermosCondicoes()
        {
            return View(await _context.TermosCondicoes.ToListAsync());
        }

        public async Task<IActionResult> GetById(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbTermosCondicoes = await _context.TermosCondicoes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tbTermosCondicoes == null)
            {
                return NotFound();
            }

            return View(tbTermosCondicoes);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTermoCondicao([Bind("Id,IdUsuario,Aceitou,DataAceite")] TbTermosCondicoes tbTermosCondicoes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbTermosCondicoes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbTermosCondicoes);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateTermoCondicao(decimal id, [Bind("Id,IdUsuario,Aceitou,DataAceite")] TbTermosCondicoes tbTermosCondicoes)
        {
            if (id != tbTermosCondicoes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbTermosCondicoes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbTermosCondicoesExists(tbTermosCondicoes.Id))
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
            return View(tbTermosCondicoes);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteTermoCondicao(decimal id)
        {
            var tbTermosCondicoes = await _context.TermosCondicoes.FindAsync(id);
            _context.TermosCondicoes.Remove(tbTermosCondicoes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbTermosCondicoesExists(decimal id)
        {
            return _context.TermosCondicoes.Any(e => e.Id == id);
        }
    }
}
