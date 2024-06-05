using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TPC_EcoSupport.Data;
using TPC_EcoSupport.Models;

namespace TPC_EcoSupport.Controllers
{
    public class TbExibicoesController : Controller
    {
        private readonly DataContext _context;

        public TbExibicoesController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Exibicoes()
        {
            return View();
        }

        public IActionResult GetExibicoes()
        {
            var exibicoes = _context.Exibicoes.ToListAsync();
            if (exibicoes == null)
            {
                return BadRequest("Exibicoes não encontradas!");
            }
            return (IActionResult)exibicoes;
        }

        public IActionResult GetExibicaoById(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exibicao = _context.Exibicoes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (exibicao == null)
            {
                return NotFound();
            }

            return (IActionResult)exibicao;
        }

        [HttpPost]
        public IActionResult CreateExibicao([FromBody] TbExibicoes request)
        {
            TbExibicoes newExibicao = new TbExibicoes
            {
                IdTransacao = request.IdTransacao,
                Valor = request.Valor,
                DataExibicao = request.DataExibicao,
                Descricao = request.Descricao
            };
            _context.Exibicoes.Add(newExibicao);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateExibicao(decimal id, [FromBody] TbExibicoes request)
        {
            var exibicao = _context.Exibicoes.Find(id);

            if (exibicao == null)
            {
                return NotFound();
            }

            exibicao.IdTransacao = request.IdTransacao != null ? request.IdTransacao : exibicao.IdTransacao;
            exibicao.Valor = request.Valor;
            exibicao.DataExibicao = request.DataExibicao;
            exibicao.Descricao = request.Descricao != null ? request.Descricao : exibicao.Descricao;

            _context.Exibicoes.Update(exibicao);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteExibicao(decimal id)
        {
            var exibicao = _context.Exibicoes.Find(id);

            if (exibicao == null)
            {
                return NotFound();
            }

            _context.Exibicoes.Remove(exibicao);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}
