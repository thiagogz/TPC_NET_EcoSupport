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

        public async Task<IActionResult> Servicos()
        {
            return View(await _context.Servicos.ToListAsync());
        }

        public async Task<IActionResult> GetById(decimal? id)
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateServico([Bind("Id,IdEmpresa,DataServico,Descricao,Status")] TbServicos tbServicos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbServicos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbServicos);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateServico(decimal id, [Bind("Id,IdEmpresa,DataServico,Descricao,Status")] TbServicos tbServicos)
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

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteServico(decimal id)
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
