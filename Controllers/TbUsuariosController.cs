using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TPC_EcoSupport.Data;
using TPC_EcoSupport.Models;

namespace TPC_EcoSupport.Controllers
{
    public class TbUsuariosController : Controller
    {
        private readonly DataContext _context;

        public TbUsuariosController(DataContext context)
        {
            _context = context;
        }

        // GET: TbUsuarios
        public async Task<IActionResult> Usuarios()
        {
            return View(await _context.Usuarios.ToListAsync());
        }

        // GET: TbUsuarios/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbUsuarios = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tbUsuarios == null)
            {
                return NotFound();
            }

            return View(tbUsuarios);
        }

        // GET: TbUsuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TbUsuarios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Email,Senha,Tipo,IdEmpresa,IdInstituicao,IdPessoaFisica")] TbUsuarios tbUsuarios)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbUsuarios);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbUsuarios);
        }

        // GET: TbUsuarios/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbUsuarios = await _context.Usuarios.FindAsync(id);
            if (tbUsuarios == null)
            {
                return NotFound();
            }
            return View(tbUsuarios);
        }

        // POST: TbUsuarios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Id,Nome,Email,Senha,Tipo,IdEmpresa,IdInstituicao,IdPessoaFisica")] TbUsuarios tbUsuarios)
        {
            if (id != tbUsuarios.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbUsuarios);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbUsuariosExists(tbUsuarios.Id))
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
            return View(tbUsuarios);
        }

        // GET: TbUsuarios/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbUsuarios = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tbUsuarios == null)
            {
                return NotFound();
            }

            return View(tbUsuarios);
        }

        // POST: TbUsuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var tbUsuarios = await _context.Usuarios.FindAsync(id);
            _context.Usuarios.Remove(tbUsuarios);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbUsuariosExists(decimal id)
        {
            return _context.Usuarios.Any(e => e.Id == id);
        }
    }
}
