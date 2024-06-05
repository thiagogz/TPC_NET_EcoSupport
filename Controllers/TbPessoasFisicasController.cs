using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        // GET: TbPessoasFisicas
        public async Task<IActionResult> PessoasFisicas()
        {
            return View(await _context.PessoasFisicas.ToListAsync());
        }

        // GET: TbPessoasFisicas/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbPessoasFisicas = await _context.PessoasFisicas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tbPessoasFisicas == null)
            {
                return NotFound();
            }

            return View(tbPessoasFisicas);
        }

        // GET: TbPessoasFisicas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TbPessoasFisicas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Cpf,Email,Senha")] TbPessoasFisicas tbPessoasFisicas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbPessoasFisicas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbPessoasFisicas);
        }

        // GET: TbPessoasFisicas/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbPessoasFisicas = await _context.PessoasFisicas.FindAsync(id);
            if (tbPessoasFisicas == null)
            {
                return NotFound();
            }
            return View(tbPessoasFisicas);
        }

        // POST: TbPessoasFisicas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Id,Nome,Cpf,Email,Senha")] TbPessoasFisicas tbPessoasFisicas)
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

        // GET: TbPessoasFisicas/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbPessoasFisicas = await _context.PessoasFisicas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tbPessoasFisicas == null)
            {
                return NotFound();
            }

            return View(tbPessoasFisicas);
        }

        // POST: TbPessoasFisicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
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
