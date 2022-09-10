using Escola.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Escola.Infra.DataBase.Mappings
{
    public class NotasMateriaMap : IEntityTypeConfiguration<NotasMateria>
    {
        public void Configure(EntityTypeBuilder<NotasMateria> builder)
        {
            builder.ToTable("NOTASMATERIA");

            builder.HasKey(n => n.Id);                    

            builder.Property(n => n.Id)
                    .UseIdentityColumn()
                    .ValueGeneratedOnAdd();
            
            builder.Property(n => n.Nota)
                    .HasColumnType("float")
                    .HasColumnName("Nota");

            builder.HasOne(n => n.Materia)
                    .WithMany(n => n.NotasMaterias)
                    .HasForeignKey(n => n.MateriaId);

            builder.HasOne(n => n.Boletim)
                    .WithMany(n => n.Notas)
                    .HasForeignKey(n => n.BoletimId);
        }
    }
}