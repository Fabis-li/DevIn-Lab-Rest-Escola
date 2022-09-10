using Escola.Domain.Models;

namespace Escola.Domain.DTO
{
    public class BoletimDTO
    {
       
        public Guid Id { get; set; } = Guid.NewGuid();
        public virtual Aluno Aluno { get; set; }
        public Guid AlunoId { get; set; }
        public string Periodo { get; set; }
        public int Faltas { get; set; }


        public BoletimDTO()
        {
            
        }
        public BoletimDTO(Boletim boletim)
        {
            Id = boletim.Id;
            Aluno = boletim.Aluno;
            AlunoId = boletim.AlunoId;
            Periodo = boletim.Periodo;
            Faltas = boletim.Faltas;
        }
    }  

    
}      