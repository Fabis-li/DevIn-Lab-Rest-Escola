
using Escola.Domain.Models;

namespace Escola.Domain.DTO
{
    public class AlunoV2DTO
    {
        public AlunoV2DTO()
        {
            
        }
        public AlunoV2DTO(Aluno aluno)
        {
            Id = aluno.Id;
            Nome = aluno.Nome;
            Email = aluno.Email;
            Matricula = aluno.Matricula;
            Sobrenome = aluno.Sobrenome;
            DataNascimento = aluno.DataNascimento;
        }

        public Guid Id { get; set; } = Guid.NewGuid();
        public int Matricula { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        
    }
}