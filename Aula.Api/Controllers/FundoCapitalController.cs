using System;
using Aula.Api.Models;
using Aula.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Aula.Api.Controllers
{
    public class FundoCapitalController : Controller
    {

        private readonly IFundoCapitalRepository _repository;

        public FundoCapitalController(IFundoCapitalRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("v1/fundoscapital")]
        public IActionResult ListarFundos()
        {
            return Ok(_repository.ListarFundos());
        }

        [HttpPost("v1/fundoscapital")]
        public IActionResult AddFundo([FromBody]FundoCapital fundo)
        {
            _repository.AddFundo(fundo);
            return Ok();
        }

        [HttpPut("v1/fundoscapital/{id}")]
        public IActionResult UpdateFundo(Guid id, [FromBody]FundoCapital newFundo)
        {
            var fundoAntigo = _repository.GetById(id);
            if (fundoAntigo == null)
            {
                return NotFound();
            }
            fundoAntigo.Nome = newFundo.Nome;
            fundoAntigo.ValorAtual = newFundo.ValorAtual;
            fundoAntigo.ValorNecessario = newFundo.ValorNecessario;
            fundoAntigo.DataResgate = newFundo.DataResgate;
            _repository.UpdateFundo(fundoAntigo);
            return Ok();
        }

        [HttpGet("v1/fundoscapital/{id}")]
        public IActionResult GetFundo(Guid id)
        {
            var fundo = _repository.GetById(id);
            if (fundo == null)
            {
                return NotFound();
            }
            return Ok(fundo);
        }

        [HttpDelete("v1/fundoscapital/{id}")]
        public IActionResult DelFundo(Guid id)
        {
            var fundo = _repository.GetById(id);
            if (fundo == null)
            {
                return NotFound();
            }
            _repository.DelFundo(fundo);
            return Ok();
        }



    }
}