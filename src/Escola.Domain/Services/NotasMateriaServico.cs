
using Escola.Domain.DTO;
using Escola.Domain.Models;
using Escola.Domain.Interfaces.Repositories;
using Escola.Domain.Interfaces.Services;
using Escola.Domain.Exceptions;

namespace Escola.Domain.Services
{
    public class NotasMateriaServico : INotasMateriaServico
    {
        private readonly INotasMateriaRepositorio _notasMateriaRepositorio;
        public NotasMateriaServico(INotasMateriaRepositorio notasMateriaRepositorio)
        {
            _notasMateriaRepositorio = notasMateriaRepositorio;
        }        

        public void Atualizar(NotasMateriaDTO notasMateria)
        {
            var notasDb =  _notasMateriaRepositorio.ObterPorId(notasMateria.Id);

             if(notasDb == null)
             throw new RegistroExistenteException("Nota não existe");

            notasDb.UpDate(notasMateria);
            _notasMateriaRepositorio.Atualizar(notasDb);

        }

        public void Excluir(int id)
        {
            var notasId = _notasMateriaRepositorio.ObterPorId(id);

            if(notasId == null)
                throw new RegistroExistenteException("Materia não encontrada");

            _notasMateriaRepositorio.Excluir(notasId);
        }

        public void Inserir(NotasMateriaDTO notasMateria)
        {
            _notasMateriaRepositorio.Inserir(new NotasMateria(notasMateria));
        }

        public List<NotasMateriaDTO> ObterPorBoletim(Guid alunoId, int boletimId)
        {
            var boletimDb = _notasMateriaRepositorio
                        .ObterTodos()
                        .Where(b => b.BoletimId == boletimId && b.Boletim.AlunoId == alunoId);

            return boletimDb.Select(b => new NotasMateriaDTO(b)).ToList();
        }       

        public NotasMateriaDTO ObterPorId(int id)
        {
           return new NotasMateriaDTO( _notasMateriaRepositorio.ObterPorId(id));
        }

        
    }
}
