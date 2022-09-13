using Escola.Domain.DTO;
using Escola.Domain.Interfaces.Services;
using Escola.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Escola.Api.Controllers
{   

    [ApiController]
    [ApiVersion("2")]
    [Route("api/v{version:apiVersion}/materia")]
    public class MateriaV2Controller : ControllerBase
    {
        private readonly IMateriaServico _materiaServico;
        public MateriaV2Controller(IMateriaServico materiaServico)
        {
            _materiaServico = materiaServico;
        }
        [HttpGet]
        public IActionResult ObterTodos(
            [FromQuery] string nome,
            int skip = 0 ,
            int take = 5
        )
        {          
            var paginacao = new Paginacao(take, skip);
            var totalRegistros = _materiaServico.ObterTotal();

            Response.Headers.Add("x-paginacao-TotalRegistros", totalRegistros.ToString());
            
            if(!string.IsNullOrEmpty(nome))
                return Ok(_materiaServico.ObterPorNome(nome)
                                        .Select(m => new MateriaV2DTO(m)));
            return Ok(_materiaServico.ObterTodos(paginacao)
                                    .Select(m => new MateriaV2DTO(m)));          
        }

        [HttpGet]
         public IActionResult ObterPorId( 
            [FromRoute] int id
        )
        {            
            return Ok(new MateriaV2DTO(_materiaServico.ObterPorId(id)));
        }

        [HttpPost]
        public IActionResult Post(
            [FromBody] MateriaV2DTO materia
        )
        {
            _materiaServico.Inserir(new MateriaDTO(materia));
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put( 
            [FromRoute] int id,
            [FromBody] MateriaV2DTO materia
        )
        {
            materia.Id = id;
            _materiaServico.Atualizar(new MateriaDTO(materia));
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete( 
            [FromRoute] int id
        )
        {
            _materiaServico.Excluir(id);
            return NoContent();
        }

    }
        
}
    
