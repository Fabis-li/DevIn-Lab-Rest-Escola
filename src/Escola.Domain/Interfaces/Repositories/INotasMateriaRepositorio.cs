using Escola.Domain.Models;

namespace Escola.Domain.Interfaces.Repositories
{
    public interface INotasMateriaRepositorio
    {
        NotasMateria ObterPorId(int id);
        void Inserir(NotasMateria notasMateria);
        void Excluir (NotasMateria notasMateria);
        void Atualizar(NotasMateria notasMateria);

        NotasMateria ObterPorBoletim(int id);

        IList<NotasMateria>ObterTodos();
    }
}

        // NotasMateria ObterPorId(int id);
        // void Inserir(NotasMateria notasMateria);
        // void Excluir (NotasMateria notasMateria);
        // void Atualizar(NotasMateria notasMateria);

        // IList<NotasMateria>ObterTodos();