using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TPC_EcoSupport.Data;
using TPC_EcoSupport.Models;

namespace TPC_EcoSupport.Controllers
{
    public class TbTermosCondicoesController : Controller
    {
        private readonly DataContext _context;

        public TbTermosCondicoesController(DataContext context)
        {
            _context = context;
        }

        public IActionResult TermosCondicoes()
        {
            return View();
        }

        public IActionResult GetTermosCondicoes()
        {
            var termosCondicoes = _context.TermosCondicoes.ToListAsync();
            if (termosCondicoes == null)
            {
                return BadRequest("Termos e Condições não encontrados!");
            }
            return (IActionResult)termosCondicoes;
        }

        public IActionResult GetTermoCondicaoById(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var termoCondicao = _context.TermosCondicoes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (termoCondicao == null)
            {
                return NotFound();
            }

            return (IActionResult)termoCondicao;
        }

        [HttpPost]
        public IActionResult CreateTermoCondicao([FromBody] TbTermosCondicoes request)
        {
            TbTermosCondicoes newTermoCondicao = new TbTermosCondicoes
            {
                IdUsuario = request.IdUsuario,
                Aceitou = request.Aceitou,
                DataAceite = request.DataAceite
            };
            _context.TermosCondicoes.Add(newTermoCondicao);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTermoCondicao(decimal id, [FromBody] TbTermosCondicoes request)
        {
            var termoCondicao = _context.TermosCondicoes.Find(id);

            if (termoCondicao == null)
            {
                return NotFound();
            }

            termoCondicao.IdUsuario = request.IdUsuario != null ? request.IdUsuario : termoCondicao.IdUsuario;
            termoCondicao.Aceitou = request.Aceitou != null ? request.Aceitou : termoCondicao.Aceitou;
            termoCondicao.DataAceite = request.DataAceite != null ? request.DataAceite : termoCondicao.DataAceite;

            _context.TermosCondicoes.Update(termoCondicao);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTermoCondicao(decimal id)
        {
            var termoCondicao = _context.TermosCondicoes.Find(id);

            if (termoCondicao == null)
            {
                return NotFound();
            }

            _context.TermosCondicoes.Remove(termoCondicao);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}
