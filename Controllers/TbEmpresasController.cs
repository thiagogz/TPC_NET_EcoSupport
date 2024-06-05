using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public IActionResult Empresas()
        {
            return View();
        }

        public IActionResult GetEmpresas()
        {
            var empresas = _context.Empresas.ToListAsync();
            if (empresas == null)
            {
                return BadRequest("Empresas não encontradas!");
            }
            return (IActionResult)empresas;
        }

        public IActionResult GetEmpresaById(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresa = _context.Empresas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (empresa == null)
            {
                return NotFound();
            }

            return (IActionResult)empresa;
        }

        [HttpPost]
        public IActionResult CreateEmpresa([FromBody] TbEmpresas request)
        {
            TbEmpresas newEmpresa = new TbEmpresas
            {
                Nome = request.Nome,
                Cnpj = request.Cnpj,
                Email = request.Email,
                Telefone = request.Telefone,
                Endereco = request.Endereco
            };
            _context.Empresas.Add(newEmpresa);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEmpresa(decimal id, [FromBody] TbEmpresas request)
        {
            var empresa = _context.Empresas.Find(id);

            if (empresa == null)
            {
                return NotFound();
            }

            empresa.Nome = request.Nome != null ? request.Nome : empresa.Nome;
            empresa.Cnpj = request.Cnpj != null ? request.Cnpj : empresa.Cnpj;
            empresa.Email = request.Email != null ? request.Email : empresa.Email;
            empresa.Telefone = request.Telefone != null ? request.Telefone : empresa.Telefone;
            empresa.Endereco = request.Endereco != null ? request.Endereco : empresa.Endereco;

            _context.Empresas.Update(empresa);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmpresa(decimal id)
        {
            var empresa = _context.Empresas.Find(id);

            if (empresa == null)
            {
                return NotFound();
            }

            _context.Empresas.Remove(empresa);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}
