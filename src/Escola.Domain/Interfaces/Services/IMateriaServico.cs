using Escola.Domain.DTO;

namespace Escola.Domain.Interfaces.Services
{
    public interface IMateriaServico
    {
        IList<MateriaDTO> ObterTodos() ;
        MateriaDTO ObterPorId(int id);
        List<MateriaDTO> ObterPorNome(string nome);
        void Inserir(MateriaDTO materia);
        void Excluir (int id);
        void Atualizar(MateriaDTO materia);
        
    }
}