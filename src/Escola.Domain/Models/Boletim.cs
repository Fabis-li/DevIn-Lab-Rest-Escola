using Escola.Domain.DTO;

namespace Escola.Domain.Models
{
    public class Boletim
    {
       
        public Guid Id { get; set; } = Guid.NewGuid();
        public virtual Aluno Aluno { get; set; }
        public Guid AlunoId { get; set; }
        public string Periodo { get; set; }
        public int Faltas { get; set; }

        public IList<NotasMateria> Notas { get; set; }

         public Boletim()
        {
            
        }
         public Boletim(BoletimDTO boletim)
        {
            Id = boletim.Id;
            Aluno = boletim.Aluno;
            AlunoId = boletim.AlunoId;
            Periodo = boletim.Periodo;
            Faltas = boletim.Faltas;
        }

        public void Update(BoletimDTO boletim)
        {
            Aluno = boletim.Aluno;
            Periodo = boletim.Periodo;
            Faltas = boletim.Faltas;
        }

    }
}