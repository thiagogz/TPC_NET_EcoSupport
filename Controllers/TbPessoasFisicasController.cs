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

        public IActionResult PessoasFisicas()
        {
            return View();
        }

        public IActionResult GetPessoasFisicas()
        {
            var pessoasFisicas = _context.PessoasFisicas.ToListAsync();
            if (pessoasFisicas == null)
            {
                return BadRequest("Pessoas físicas não encontradas!");
            }
            return (IActionResult)pessoasFisicas;
        }

        public IActionResult GetPessoaFisicaById(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoaFisica = _context.PessoasFisicas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pessoaFisica == null)
            {
                return NotFound();
            }

            return (IActionResult)pessoaFisica;
        }

        [HttpPost]
        public IActionResult CreatePessoaFisica([FromBody] TbPessoasFisicas request)
        {
            TbPessoasFisicas newPessoaFisica = new TbPessoasFisicas
            {
                Nome = request.Nome,
                Cpf = request.Cpf,
                Email = request.Email,
                Senha = request.Senha
            };
            _context.PessoasFisicas.Add(newPessoaFisica);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePessoaFisica(decimal id, [FromBody] TbPessoasFisicas request)
        {
            var pessoaFisica = _context.PessoasFisicas.Find(id);

            if (pessoaFisica == null)
            {
                return NotFound();
            }

            pessoaFisica.Nome = request.Nome != null ? request.Nome : pessoaFisica.Nome;
            pessoaFisica.Cpf = request.Cpf != null ? request.Cpf : pessoaFisica.Cpf;
            pessoaFisica.Email = request.Email != null ? request.Email : pessoaFisica.Email;
            pessoaFisica.Senha = request.Senha != null ? request.Senha : pessoaFisica.Senha;

            _context.PessoasFisicas.Update(pessoaFisica);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePessoaFisica(decimal id)
        {
            var pessoaFisica = _context.PessoasFisicas.Find(id);

            if (pessoaFisica == null)
            {
                return NotFound();
            }

            _context.PessoasFisicas.Remove(pessoaFisica);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}
