using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Escola.Domain.Models;
using Escola.Infra.DataBase.Mappings;
using Microsoft.Extensions.Configuration;

namespace Escola.Infra.DataBase
{
    public class EscolaDBContexto : DbContext
    {
        
        public DbSet<Aluno> Alunos {get; set;}
        public DbSet<Materia> Materias{get; set;}
        public DbSet<Boletim> Boletins {get; set;}
        public DbSet<NotasMateria> NotasMaterias {get; set;}
        
        
        private readonly IConfiguration _configuration;
        public EscolaDBContexto(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options){
            options.UseSqlServer(_configuration.GetConnectionString("DB_Escola"));
            //options.UseSqlServer("Password=YourStrong@Passw0rd;Persist Security Info=True;User ID=sa;Initial Catalog=EscolaDB;Data Source=tcp:localhost,1433");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.ApplyConfiguration(new AlunoMap());
            modelBuilder.ApplyConfiguration(new BolteimMap());
            modelBuilder.ApplyConfiguration(new MateriaMap());
            modelBuilder.ApplyConfiguration(new NotasMateriaMap());
        }

              
    }
}