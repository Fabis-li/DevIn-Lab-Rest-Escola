using Escola.Domain.Models;

namespace Escola.Domain.Interfaces.Repositories
{
    public interface IBoletimRepositorio
    {
        IList<Boletim> ObterTodos();
        Boletim ObterPorId(Guid id);
        List<Boletim> ObterPorNome(string nome);
        void Inserir(Boletim boletim);
        void Excluir (Boletim boletim);
        void Atualizar(Boletim boletim);
    }
    
}