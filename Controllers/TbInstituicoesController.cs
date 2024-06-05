using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        // GET: TbInstituicoes
        public async Task<IActionResult> Instituicoes()
        {
            return View(await _context.Instituicoes.ToListAsync());
        }

        // GET: TbInstituicoes/Details/5
        public async Task<IActionResult> Details(decimal? id)
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

            return View(tbInstituicoes);
        }

        // GET: TbInstituicoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TbInstituicoes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Cnpj,Email,Telefone,Endereco")] TbInstituicoes tbInstituicoes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbInstituicoes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbInstituicoes);
        }

        // GET: TbInstituicoes/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbInstituicoes = await _context.Instituicoes.FindAsync(id);
            if (tbInstituicoes == null)
            {
                return NotFound();
            }
            return View(tbInstituicoes);
        }

        // POST: TbInstituicoes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Id,Nome,Cnpj,Email,Telefone,Endereco")] TbInstituicoes tbInstituicoes)
        {
            if (id != tbInstituicoes.Id)
            {
                return NotFound();
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
                        return NotFound();
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

        // GET: TbInstituicoes/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
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

            return View(tbInstituicoes);
        }

        // POST: TbInstituicoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
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
