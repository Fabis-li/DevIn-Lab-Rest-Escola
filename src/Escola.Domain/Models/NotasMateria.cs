using Escola.Domain.DTO;

namespace Escola.Domain.Models
{
    public class NotasMateria
    {
        
        public int Id { get; set; }
        public virtual Materia Materia { get; set; }
        public int MateriaId { get; set; }
        public virtual Boletim Boletim { get; set; }
        public int BoletimId { get; set; }
        public double Nota { get; set; }

        public NotasMateria( )
        {
            
        }

        public NotasMateria(NotasMateriaDTO notasMateria)
        {
            Id = notasMateria.Id;
            Materia = notasMateria.Materia;
            MateriaId = notasMateria.MateriaId;
            Boletim = notasMateria.Boletim;
            BoletimId = notasMateria.BoletimId;
            Nota = notasMateria.Nota;
        }
        public void UpDate(NotasMateriaDTO notasMateria)
        {
            BoletimId = notasMateria.BoletimId;
            MateriaId = notasMateria.MateriaId;
            Nota = notasMateria.Nota;
        }


    }
}