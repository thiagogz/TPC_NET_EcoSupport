using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TPC_EcoSupport.Data;
using TPC_EcoSupport.Models;

namespace TPC_EcoSupport.Controllers
{
    public class TbServicosController : Controller
    {
        private readonly DataContext _context;

        public TbServicosController(DataContext context)
        {
            _context = context;
        }

        // GET: TbServicos
        public async Task<IActionResult> Servicos()
        {
            return View(await _context.Servicos.ToListAsync());
        }

        // GET: TbServicos/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbServicos = await _context.Servicos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tbServicos == null)
            {
                return NotFound();
            }

            return View(tbServicos);
        }

        // GET: TbServicos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TbServicos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdEmpresa,DataServico,Descricao,Status")] TbServicos tbServicos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbServicos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbServicos);
        }

        // GET: TbServicos/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbServicos = await _context.Servicos.FindAsync(id);
            if (tbServicos == null)
            {
                return NotFound();
            }
            return View(tbServicos);
        }

        // POST: TbServicos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Id,IdEmpresa,DataServico,Descricao,Status")] TbServicos tbServicos)
        {
            if (id != tbServicos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbServicos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbServicosExists(tbServicos.Id))
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
            return View(tbServicos);
        }

        // GET: TbServicos/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbServicos = await _context.Servicos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tbServicos == null)
            {
                return NotFound();
            }

            return View(tbServicos);
        }

        // POST: TbServicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var tbServicos = await _context.Servicos.FindAsync(id);
            _context.Servicos.Remove(tbServicos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbServicosExists(decimal id)
        {
            return _context.Servicos.Any(e => e.Id == id);
        }
    }
}
