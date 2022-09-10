using Escola.Domain.Models;

namespace Escola.Domain.DTO
{
    public class NotasMateriaDTO
    {
        
        public int Id { get; set; }
        public virtual Materia Materia { get; set; }
        public int MateriaId { get; set; }
        public virtual Boletim Boletim { get; set; }
        public int BoletimId { get; set; }
        public double Nota { get; set; }

        public NotasMateriaDTO()
        {
            
        }

        public NotasMateriaDTO(NotasMateria notasMateria)
        {
            Id = notasMateria.Id;
            Materia = notasMateria.Materia;
            MateriaId = notasMateria.MateriaId;
            Boletim = notasMateria.Boletim;
            BoletimId = notasMateria.BoletimId;
            Nota = notasMateria.Nota;
        }

    }
}
