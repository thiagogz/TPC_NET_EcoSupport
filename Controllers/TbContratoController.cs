using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TPC_EcoSupport.Data;
using TPC_EcoSupport.Models;

namespace TPC_EcoSupport.Controllers
{
    public class TbContratosController : Controller
    {
        private readonly DataContext _context;

        public TbContratosController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Contratos()
        {
            return View();
        }

        public IActionResult GetContratos()
        {
            var contratos = _context.Contratos.ToListAsync();
            if (contratos == null)
            {
                return BadRequest("Pontos não encontrados!");
            }
            return (IActionResult)contratos;
        }

        public IActionResult GetContratosById(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contratoSelecionado = _context.Contratos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contratoSelecionado == null)
            {
                return NotFound();
            }

            return (IActionResult)contratoSelecionado;
        }

        [HttpPost]
        public IActionResult CreateContrato([FromBody] TbContratos request)
        {
            TbContratos newContrato = new TbContratos
            {
                IdEmpresa = request.IdEmpresa,
                TipoContrato = request.TipoContrato,
                DataInicio = request.DataInicio,
                DataFim = request.DataFim,
                Valor = request.Valor,
                Status = request.Status,
                AssinaturaPendente = request.AssinaturaPendente
            };
            _context.Add(newContrato);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateContrato(decimal id, [FromBody] TbContratos request)
        {
            var getContrato = _context.Contratos.Find(id);

            if (getContrato == null)
            {
                return NotFound();
            }

            getContrato.IdEmpresa = request.IdEmpresa != null ? request.IdEmpresa : getContrato.IdEmpresa;
            getContrato.TipoContrato = request.TipoContrato != null ? request.TipoContrato : getContrato.TipoContrato;
            getContrato.DataInicio = request.DataInicio != null ? request.DataInicio : getContrato.DataInicio;
            getContrato.DataFim = request.DataFim != null ? request.DataFim : getContrato.DataFim;
            getContrato.Valor = request.Valor != null ? request.Valor : getContrato.Valor;
            getContrato.Status = request.Status != null ? request.Status : getContrato.Status;
            getContrato.AssinaturaPendente = request.AssinaturaPendente != null ? request.AssinaturaPendente : getContrato.AssinaturaPendente;

            _context.Contratos.Update(getContrato);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteContrato(decimal id)
        {
            var getContrato = _context.Contratos.Find(id);

            if (getContrato == null)
            {
                return NotFound();
            }

            getContrato.Status = "Cancelado";

            _context.Contratos.Update(getContrato);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}
