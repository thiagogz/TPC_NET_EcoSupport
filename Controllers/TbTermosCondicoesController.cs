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

        // GET: TbTermosCondicoes
        public async Task<IActionResult> TermosCondicoes()
        {
            return View(await _context.TermosCondicoes.ToListAsync());
        }

        // GET: TbTermosCondicoes/Details/5
        public async Task<IActionResult> Details(decimal? id)
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

        // GET: TbTermosCondicoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TbTermosCondicoes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdUsuario,Aceitou,DataAceite")] TbTermosCondicoes tbTermosCondicoes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbTermosCondicoes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbTermosCondicoes);
        }

        // GET: TbTermosCondicoes/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbTermosCondicoes = await _context.TermosCondicoes.FindAsync(id);
            if (tbTermosCondicoes == null)
            {
                return NotFound();
            }
            return View(tbTermosCondicoes);
        }

        // POST: TbTermosCondicoes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Id,IdUsuario,Aceitou,DataAceite")] TbTermosCondicoes tbTermosCondicoes)
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

        // GET: TbTermosCondicoes/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
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

        // POST: TbTermosCondicoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
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
