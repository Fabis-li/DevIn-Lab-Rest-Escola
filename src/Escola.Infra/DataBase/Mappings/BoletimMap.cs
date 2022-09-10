using Escola.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Escola.Infra.DataBase.Mappings
{
    public class BolteimMap : IEntityTypeConfiguration<Boletim>
    {
        public void Configure(EntityTypeBuilder<Boletim> builder)
        {
            builder.ToTable("BOLETIM");

            builder.HasKey(b => b.Id);                    

             builder.Property(b => b.Id)
                    .UseIdentityColumn()
                    .ValueGeneratedOnAdd();
            
            builder.Property(b => b.Faltas)
                    .HasColumnType("int")                    
                    .HasColumnName("Faltas");

            builder.Property(b => b.Periodo)
                    .HasColumnType("varchar")  
                    .HasMaxLength(50)                  
                    .HasColumnName("Periodo");

            builder.HasOne(b => b.Aluno)
                    .WithMany(b => b.Boletins)
                    .HasForeignKey(b => b.AlunoId);

            builder.HasMany(b => b.Notas)
                    .WithOne(b => b.Boletim);

            
                    
        }
    }
}