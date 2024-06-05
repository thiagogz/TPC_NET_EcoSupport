using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TPC_EcoSupport.Data;
using TPC_EcoSupport.Models;

namespace TPC_EcoSupport.Controllers
{
    public class TbInstituicoesController : Controller
    {
        private readonly DataContext _context;

        public TbInstituicoesController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Instituicoes()
        {
            return View();
        }

        public IActionResult GetInstituicoes()
        {
            var instituicoes = _context.Instituicoes.ToListAsync();
            if (instituicoes == null)
            {
                return BadRequest("Instituições não encontradas!");
            }
            return (IActionResult)instituicoes;
        }

        public IActionResult GetInstituicaoById(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instituicao = _context.Instituicoes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (instituicao == null)
            {
                return NotFound();
            }

            return (IActionResult)instituicao;
        }

        [HttpPost]
        public IActionResult CreateInstituicao([FromBody] TbInstituicoes request)
        {
            TbInstituicoes newInstituicao = new TbInstituicoes
            {
                Nome = request.Nome,
                Cnpj = request.Cnpj,
                Email = request.Email,
                Telefone = request.Telefone,
                Endereco = request.Endereco
            };
            _context.Instituicoes.Add(newInstituicao);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateInstituicao(decimal id, [FromBody] TbInstituicoes request)
        {
            var instituicao = _context.Instituicoes.Find(id);

            if (instituicao == null)
            {
                return NotFound();
            }

            instituicao.Nome = request.Nome != null ? request.Nome : instituicao.Nome;
            instituicao.Cnpj = request.Cnpj != null ? request.Cnpj : instituicao.Cnpj;
            instituicao.Email = request.Email != null ? request.Email : instituicao.Email;
            instituicao.Telefone = request.Telefone != null ? request.Telefone : instituicao.Telefone;
            instituicao.Endereco = request.Endereco != null ? request.Endereco : instituicao.Endereco;

            _context.Instituicoes.Update(instituicao);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteInstituicao(decimal id)
        {
            var instituicao = _context.Instituicoes.Find(id);

            if (instituicao == null)
            {
                return NotFound();
            }

            _context.Instituicoes.Remove(instituicao);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}
