using Escola.Domain.DTO;

namespace Escola.Domain.Interfaces.Services
{
    public interface IBoletimServico
    {
        IList<BoletimDTO> ObterTodos() ;
        BoletimDTO ObterPorId(Guid id);
        List<BoletimDTO> ObterPorIdAluno(Guid id);
        List<BoletimDTO> ObterPorNome(string nome);
        void Inserir(BoletimDTO boletim);
        void Excluir (Guid id);
        void Atualizar(BoletimDTO Boletim);
    }
}