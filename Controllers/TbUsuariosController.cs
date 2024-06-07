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

        public async Task<IActionResult> Usuarios()
        {
            return View(await _context.Usuarios.ToListAsync());
        }

        public IActionResult CadastroPage()
        {
            return View();
        }

        public IActionResult LoginPage()
        {
            return View();
        }

        public async Task<IActionResult> GetByID(decimal? id)
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CadastrarUsuario([Bind("Nome,Email,Senha,Tipo")] TbUsuarios tbUsuarios)
        {
            if (ModelState.IsValid)
            {
                if (tbUsuarios.Tipo == "pf")
                {
                    tbUsuarios.IdEmpresa = null;
                    tbUsuarios.IdInstituicao = null;
                    tbUsuarios.IdPessoaFisica = 1;
                }
                else if (tbUsuarios.Tipo == "empresa")
                {
                    tbUsuarios.IdEmpresa = 1;
                    tbUsuarios.IdInstituicao = null;
                    tbUsuarios.IdPessoaFisica = null;
                }
                else if (tbUsuarios.Tipo == "instituicao")
                {
                    tbUsuarios.IdEmpresa = null;
                    tbUsuarios.IdInstituicao = 1;
                    tbUsuarios.IdPessoaFisica = null;
                }

                _context.Add(tbUsuarios);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Usuarios));
            }
            return View(tbUsuarios);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EfetuarLogin(string Email, string Senha)
        {
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Senha))
            {
                return BadRequest("E-mail ou senha não inseridos!");
            }

            var usuario = await _context.Usuarios
                .Include(u => u.Empresa)
                .Include(u => u.PessoaFisica)
                .Include(u => u.Instituicao)
                .FirstOrDefaultAsync(u => u.Email == Email);

            if (usuario == null)
            {
                return BadRequest("Usuário não encontrado.");
            }

            if (usuario.Senha != Senha)
            {
                return BadRequest("Senha incorreta.");
            }

            if (usuario.Tipo == "pf")
            {
                return RedirectToAction("DashPessoasFisicas", "TbPessoasFisicas", new { id = usuario.PessoaFisica.Id });
            }
            else if (usuario.Tipo == "empresa")
            {
                return RedirectToAction("DashEmpresas", "TbEmpresas", new { id = usuario.Empresa.Id });
            }
            else if (usuario.Tipo == "instituicao")
            {
                return RedirectToAction("DashInstituicoes", "TbInstituicoes", new { id = usuario.Instituicao.Id });
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateUsuario(decimal id, [Bind("Id,Nome,Email,Senha,Tipo,IdEmpresa,IdInstituicao,IdPessoaFisica")] TbUsuarios tbUsuarios)
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

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteUsuario(decimal id)
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
