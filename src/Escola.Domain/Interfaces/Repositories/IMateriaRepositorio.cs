using Escola.Domain.Models;

namespace Escola.Domain.Interfaces.Repositories
{
    public interface IMateriaRespositorio
    {
        IList<Materia> ObterTodos(Paginacao paginacao);
        Materia ObterPorId(int id);
        List<Materia> ObterPorNome(string nome);
        void Inserir(Materia materia);
        void Excluir (Materia materia);
        void Atualizar(Materia materia);
        public int ObterTotal();
    }
}