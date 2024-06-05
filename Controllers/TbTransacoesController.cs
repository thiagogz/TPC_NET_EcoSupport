using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TPC_EcoSupport.Data;
using TPC_EcoSupport.Models;

namespace TPC_EcoSupport.Controllers
{
    public class TbTransacoesController : Controller
    {
        private readonly DataContext _context;

        public TbTransacoesController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Transacoes()
        {
            return View();
        }

        public IActionResult GetTransacoes()
        {
            var transacoes = _context.Transacoes.ToListAsync();
            if (transacoes == null)
            {
                return BadRequest("Transações não encontradas!");
            }
            return (IActionResult)transacoes;
        }

        public IActionResult GetTransacoesById(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transacoes = _context.Transacoes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transacoes == null)
            {
                return NotFound();
            }

            return (IActionResult)transacoes;
        }

        [HttpPost]
        public IActionResult CreateTransacao([FromBody] TbTransacoes request)
        {
            TbTransacoes newTransacoes = new TbTransacoes
            {
                IdContrato = request.IdContrato,
                Data = request.Data,
                Valor = request.Valor,
                Descricao = request.Descricao
            };
            _context.Transacoes.Add(newTransacoes);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTransacao(decimal id, [FromBody] TbTransacoes request)
        {
            var transacoes = _context.Transacoes.Find(id);

            if (transacoes == null)
            {
                return NotFound();
            }

            transacoes.IdContrato = request.IdContrato;
            transacoes.Data = request.Data;
            transacoes.Valor = request.Valor;
            transacoes.Descricao = request.Descricao != null ? request.Descricao : transacoes.Descricao;

            _context.Transacoes.Update(transacoes);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTransacoes(decimal id)
        {
            var transacao = _context.Transacoes.Find(id);

            if (transacao == null)
            {
                return NotFound();
            }

            _context.Transacoes.Remove(transacao);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}

