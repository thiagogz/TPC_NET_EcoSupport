using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TPC_EcoSupport.Data;
using TPC_EcoSupport.Models;

namespace TPC_EcoSupport.Controllers
{
    public class TbServicosController : Controller
    {
        private readonly DataContext _context;

        public TbServicosController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Servicos()
        {
            return View();
        }

        public IActionResult GetServicos()
        {
            var servicos = _context.Servicos.ToListAsync();
            if (servicos == null)
            {
                return BadRequest("Serviços não encontrados!");
            }
            return (IActionResult)servicos;
        }

        public IActionResult GetServicoById(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servico = _context.Servicos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (servico == null)
            {
                return NotFound();
            }

            return (IActionResult)servico;
        }

        [HttpPost]
        public IActionResult CreateServico([FromBody] TbServicos request)
        {
            TbServicos newServico = new TbServicos
            {
                IdEmpresa = request.IdEmpresa,
                DataServico = request.DataServico,
                Descricao = request.Descricao,
                Status = request.Status
            };
            _context.Servicos.Add(newServico);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateServico(decimal id, [FromBody] TbServicos request)
        {
            var servico = _context.Servicos.Find(id);

            if (servico == null)
            {
                return NotFound();
            }

            servico.IdEmpresa = request.IdEmpresa != null ? request.IdEmpresa : servico.IdEmpresa;
            servico.DataServico = request.DataServico;
            servico.Descricao = request.Descricao != null ? request.Descricao : servico.Descricao;
            servico.Status = request.Status != null ? request.Status : servico.Status;

            _context.Servicos.Update(servico);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteServico(decimal id)
        {
            var servico = _context.Servicos.Find(id);

            if (servico == null)
            {
                return NotFound();
            }

            _context.Servicos.Remove(servico);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}
