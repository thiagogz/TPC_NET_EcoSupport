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

        // GET: TbContratos
        public async Task<IActionResult> Contratos()
        {
            return View(await _context.Contratos.ToListAsync());
        }

        // GET: TbContratos/Details/5
        public async Task<IActionResult> Details(decimal? id)
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

        // GET: TbContratos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TbContratos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdEmpresa,TipoContrato,DataInicio,DataFim,Valor,Status,AssinaturaPendente")] TbContratos tbContratos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbContratos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbContratos);
        }

        // GET: TbContratos/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbContratos = await _context.Contratos.FindAsync(id);
            if (tbContratos == null)
            {
                return NotFound();
            }
            return View(tbContratos);
        }

        // POST: TbContratos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Id,IdEmpresa,TipoContrato,DataInicio,DataFim,Valor,Status,AssinaturaPendente")] TbContratos tbContratos)
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

        // GET: TbContratos/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
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

        // POST: TbContratos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
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
