using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TPC_EcoSupport.Data;
using TPC_EcoSupport.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace TPC_EcoSupport.Controllers
{
    public class TbUsuariosController : Controller
    {
        private readonly DataContext _context;

        public TbUsuariosController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Usuarios()
        {
            return View();
        }

        public IActionResult GetUsuarios()
        {
            var usuarios = _context.Usuarios.ToListAsync();
            if (usuarios == null)
            {
                return BadRequest("Transações não encontradas!");
            }
            return (IActionResult)usuarios;
        }

        public IActionResult GetUsuariosById(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarios = _context.Usuarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuarios == null)
            {
                return NotFound();
            }

            return (IActionResult)usuarios;
        }

        [HttpPost]
        public IActionResult CreateUsuario([FromBody] TbUsuarios request)
        {
            TbUsuarios newUsuario = new TbUsuarios
            {
                Nome = request.Nome,
                Email = request.Email,
                Senha = request.Senha,
                Tipo = request.Tipo,
                IdEmpresa = request.IdEmpresa,
                IdInstituicao = request.IdInstituicao,
                IdPessoaFisica = request.IdPessoaFisica
            };
            _context.Usuarios.Add(newUsuario);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUsuario(decimal id, [FromBody] TbUsuarios request)
        {
            var usuario = _context.Usuarios.Find(id);

            if (usuario == null)
            {
                return NotFound();
            }

            usuario.Nome = request.Nome;
            usuario.Email = request.Email;
            usuario.Senha = request.Senha;
            usuario.Tipo = request.Tipo;
            usuario.IdEmpresa = request.IdEmpresa;
            usuario.IdInstituicao = request.IdInstituicao;
            usuario.IdPessoaFisica = request.IdPessoaFisica;

            _context.Usuarios.Update(usuario);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUsuario(decimal id)
        {
            var usuario = _context.Usuarios.Find(id);

            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}
