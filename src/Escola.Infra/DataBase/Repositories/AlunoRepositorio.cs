using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Escola.Domain.Interfaces.Repositories;
using Escola.Domain.Models;

namespace Escola.Infra.DataBase.Repositories
{
    public class AlunoRepositorio : IAlunoRepositorio
    {
        private readonly EscolaDBContexto _contexto;
        public AlunoRepositorio(EscolaDBContexto contexto)
        {
            _contexto = contexto;
        }

        public void Atualizar(Aluno aluno)
        {
            _contexto.Alunos.Update(aluno);
            _contexto.SaveChanges();
        }

        public void Excluir(Aluno aluno)
        {
            _contexto.Alunos.Remove(aluno);
            _contexto.SaveChanges();
        }

        public bool ExisteMatricula(int matricula)
        {
            return _contexto.Alunos.Any(x => x.Matricula == matricula);
        }

        public void Inserir(Aluno aluno)
        {
            _contexto.Alunos.Add(aluno);
            _contexto.SaveChanges();
        }

        public Aluno ObterPorId(Guid id)
        {
            return _contexto.Alunos.Find(id);          

        }

        public IList<Aluno> ObterTodos(Paginacao paginacao)
        {
           return _contexto.Alunos.Take(paginacao.take).Skip(paginacao.skip).ToList();
        }

        public int ObterTotal(Paginacao paginacao)
        {
           return _contexto.Alunos.Count();
        }

        public int ObterTotal()
        {
            throw new NotImplementedException();
        }
    }

        
}