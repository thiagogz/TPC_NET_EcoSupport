using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TPC_EcoSupport.Data;
using TPC_EcoSupport.Models;

namespace TPC_EcoSupport.Controllers
{
    public class TbTransacoesController : Controller
    {
        private readonly DataContext _context;

        public TbTransacoesController(DataContext context)
        {
            _context = context;
        }

        // GET: TbTransacoes
        public async Task<IActionResult> Transacoes()
        {
            return View(await _context.Transacoes.ToListAsync());
        }

        // GET: TbTransacoes/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbTransacoes = await _context.Transacoes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tbTransacoes == null)
            {
                return NotFound();
            }

            return View(tbTransacoes);
        }

        // GET: TbTransacoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TbTransacoes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdContrato,Data,Valor,Descricao")] TbTransacoes tbTransacoes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbTransacoes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbTransacoes);
        }

        // GET: TbTransacoes/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbTransacoes = await _context.Transacoes.FindAsync(id);
            if (tbTransacoes == null)
            {
                return NotFound();
            }
            return View(tbTransacoes);
        }

        // POST: TbTransacoes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Id,IdContrato,Data,Valor,Descricao")] TbTransacoes tbTransacoes)
        {
            if (id != tbTransacoes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbTransacoes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbTransacoesExists(tbTransacoes.Id))
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
            return View(tbTransacoes);
        }

        // GET: TbTransacoes/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbTransacoes = await _context.Transacoes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tbTransacoes == null)
            {
                return NotFound();
            }

            return View(tbTransacoes);
        }

        // POST: TbTransacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var tbTransacoes = await _context.Transacoes.FindAsync(id);
            _context.Transacoes.Remove(tbTransacoes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbTransacoesExists(decimal id)
        {
            return _context.Transacoes.Any(e => e.Id == id);
        }
    }
}
