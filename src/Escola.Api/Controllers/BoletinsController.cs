using Escola.Domain.DTO;
using Escola.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Escola.Api.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class BolteinsController : ControllerBase
    {
        private readonly IBoletimServico _boletimServico;
        public BolteinsController(IBoletimServico boletimServico)
        {
            _boletimServico = boletimServico;
        }

        [HttpGet]
        public IActionResult ObterPorNome(
            [FromQuery] string nome
        )
        {
           return Ok(_boletimServico.ObterPorNome(nome));
        }

        [HttpGet]
        [Route("~/api/alunos/{idaluno}/boletins")]
        public IActionResult ObterPorId(
            [FromRoute] Guid idaluno
        )
        {
            return Ok(_boletimServico.ObterPorIdAluno(idaluno));
        }

        [HttpPost]
        public IActionResult Inserir(
            [FromBody] BoletimDTO boletim
        )
        {
            _boletimServico.Inserir(boletim);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Alterar( 
            [FromRoute] Guid id,
            [FromBody] BoletimDTO boletim
        )
        {
            boletim.Id = id;
            _boletimServico.Atualizar(boletim);
            return Ok();

        }

        [HttpDelete("{boletimId}")]
        public IActionResult Delete(
            [FromRoute] Guid boletimId
        )
        {       
            _boletimServico.Excluir(boletimId);
            return Ok();
        }


    }
}
