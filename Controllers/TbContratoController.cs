using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TPC_EcoSupport.Data;
using TPC_EcoSupport.Models;

namespace TPC_EcoSupport.Controllers
{
    public class TbContratosController : Controller
    {
        private readonly DataContext _context;

        public TbContratosController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Contratos()
        {
            return View(await _context.Contratos.ToListAsync());
        }

        public async Task<IActionResult> GetById(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbContratos = await _context.Contratos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tbContratos == null)
            {
                return NotFound();
            }

            return View(tbContratos);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateContrato([Bind("Id,IdEmpresa,TipoContrato,DataInicio,DataFim,Valor,Status,AssinaturaPendente")] TbContratos tbContratos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbContratos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbContratos);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateContrato(decimal id, [Bind("Id,IdEmpresa,TipoContrato,DataInicio,DataFim,Valor,Status,AssinaturaPendente")] TbContratos tbContratos)
        {
            if (id != tbContratos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbContratos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbContratosExists(tbContratos.Id))
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
            return View(tbContratos);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteContrato(decimal id)
        {
            var tbContratos = await _context.Contratos.FindAsync(id);
            _context.Contratos.Remove(tbContratos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbContratosExists(decimal id)
        {
            return _context.Contratos.Any(e => e.Id == id);
        }
    }
}
