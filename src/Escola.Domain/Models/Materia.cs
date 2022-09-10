using Escola.Domain.DTO;

namespace Escola.Domain.Models
{
    public class Materia
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public IList<NotasMateria> NotasMaterias { get; set; }

        public Materia( )
        {
            
        }

        public Materia(MateriaDTO materia)
        {
            Id = materia.Id;
            Nome = materia.Nome;
        }

        public void UpDate(MateriaDTO materia)
        {
             
            Nome = materia.Nome;
        }
    }
}