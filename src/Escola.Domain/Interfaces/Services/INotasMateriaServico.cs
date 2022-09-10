using Escola.Domain.DTO;
using Escola.Domain.Models;


namespace Escola.Domain.Interfaces.Services
{
    public interface INotasMateriaServico
    {
        NotasMateriaDTO ObterPorId(int id);
        void Inserir(NotasMateriaDTO notasMateria);
        void Excluir (int id);
        void Atualizar(NotasMateriaDTO notasMateria);
        List<NotasMateriaDTO> ObterPorBoletim(Guid alunoId, int boletimId);
    }
}