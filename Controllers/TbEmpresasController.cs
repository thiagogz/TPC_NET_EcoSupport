using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TPC_EcoSupport.Data;
using TPC_EcoSupport.Models;

namespace TPC_EcoSupport.Controllers
{
    public class TbEmpresasController : Controller
    {
        private readonly DataContext _context;

        public TbEmpresasController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Empresas()
        {
            return View(await _context.Empresas.ToListAsync());
        }

        public async Task<IActionResult> DashEmpresas(decimal id)
        {
            var empresa = await _context.Empresas
                .Include(e => e.Usuarios)
                .Include(e => e.Contratos)
                .Include(e => e.Servicos)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (empresa == null)
            {
                return NotFound();
            }

            // Consultar as exibições diretamente do banco de dados
            var exibicaoList = await _context.Exibicoes
                .Include(e => e.Transacao)
                .ThenInclude(t => t.Contrato)
                .Where(e => e.Transacao.Contrato.Empresa.Id == id)
                .ToListAsync();

            ViewBag.ExibicaoList = exibicaoList;

            // Obter a primeira transação e contrato, se houver
            var transacao = exibicaoList.Select(e => e.Transacao).FirstOrDefault();
            var contrato = exibicaoList.Select(e => e.Transacao.Contrato).FirstOrDefault();

            ViewBag.Transacao = transacao;
            ViewBag.Contrato = contrato;

            return View(empresa);
        }


        public async Task<IActionResult> GetById(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbEmpresas = await _context.Empresas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tbEmpresas == null)
            {
                return NotFound();
            }

            return View(tbEmpresas);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateEmpresa([Bind("Id,Nome,Cnpj,Email,Telefone,Endereco")] TbEmpresas tbEmpresas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbEmpresas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbEmpresas);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateEmpresa(decimal id, [Bind("Id,Nome,Cnpj,Email,Telefone,Endereco")] TbEmpresas tbEmpresas)
        {
            if (id != tbEmpresas.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbEmpresas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbEmpresasExists(tbEmpresas.Id))
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
            return View(tbEmpresas);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteEmpresa(decimal id)
        {
            var tbEmpresas = await _context.Empresas.FindAsync(id);
            _context.Empresas.Remove(tbEmpresas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbEmpresasExists(decimal id)
        {
            return _context.Empresas.Any(e => e.Id == id);
        }
    }
}
