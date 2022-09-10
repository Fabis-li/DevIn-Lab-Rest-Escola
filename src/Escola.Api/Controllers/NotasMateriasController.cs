using Escola.Domain.DTO;
using Escola.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Escola.Api.Controllers
{
    [Controller]
    [Route("api/[controller]")]

    public class NotasMateriasController : ControllerBase
    {
        private readonly INotasMateriaServico _notasMateriaServico;
        public NotasMateriasController(INotasMateriaServico notasMateriaServico)
        {
            _notasMateriaServico = notasMateriaServico;
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(
            [FromRoute] int id
        )
        {
            return Ok(_notasMateriaServico.ObterPorId(id));
        }

        [HttpGet]
        [Route("~api/alunos/{idaluno}/boletims/{IdBoletim}/NotasMateria/")]
        public IActionResult ObterPorBoletim(
            [FromRoute] Guid alunoId,
            [FromRoute] int boletimId
        )
        {
            return Ok(_notasMateriaServico.ObterPorBoletim((Guid)alunoId, (int)boletimId));
        }

        [HttpPost]
        public IActionResult Inserir(
            [FromBody] NotasMateriaDTO nostaMateria
        )
        {
            _notasMateriaServico.Inserir(nostaMateria);
            return Ok();
        }

        [HttpPut("{id}")]        
        public IActionResult Atualizar(
            [FromRoute] int id,
            [FromBody] NotasMateriaDTO notasMateria            
        )
        {
            notasMateria.Id =  id;
            _notasMateriaServico.Atualizar(notasMateria);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(
            [FromRoute] int id
        )
        {
            _notasMateriaServico.Excluir(id);
            return NoContent();
        }

    }

}