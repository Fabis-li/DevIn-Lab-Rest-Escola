using Escola.Domain.DTO;
using Escola.Domain.Interfaces.Repositories;
using Escola.Domain.Interfaces.Services;
using Escola.Domain.Models;
using Escola.Domain.Exceptions;

namespace Escola.Domain.Services
{

    public class BoletimServico : IBoletimServico
    {
        private readonly IBoletimRepositorio _boletimRepositorio;
        public BoletimServico(IBoletimRepositorio boletimRepositorio)
        {
            _boletimRepositorio = boletimRepositorio;
        }
        public void Atualizar(BoletimDTO boletim)
        {
            var boletimDb = _boletimRepositorio.ObterPorId(boletim.Id);

            if(boletim == null)
                throw new RegistroExistenteException("Boletim não cadastrado");

            _boletimRepositorio.Atualizar(boletimDb);
        }

        public void Excluir(Guid id)
        {
            var boletimId =_boletimRepositorio.ObterPorId(id);

            if(boletimId == null)
                throw new RegistroExistenteException("Boletim não encontrado");

            _boletimRepositorio.Excluir(boletimId);
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public void Inserir(BoletimDTO boletim)
        {
           var existeBoletim = _boletimRepositorio.ObterPorId(boletim.Id);

            if(existeBoletim != null)
                throw new RegistroExistenteException("Boletim já existe");

            _boletimRepositorio.Inserir(new Boletim (boletim));
        }

        public BoletimDTO ObterPorId(Guid id)
        {
            return new BoletimDTO(_boletimRepositorio.ObterPorId(id));
        }
        

        public List<BoletimDTO> ObterPorIdAluno(Guid id)
        {
            var alunoId = _boletimRepositorio.ObterTodos().Where(b => b.AlunoId == id);

            return alunoId.Select(b => new BoletimDTO(b)).ToList();
        }

        
        public List<BoletimDTO> ObterPorNome(string nome)
        {
            return _boletimRepositorio.ObterPorNome(nome)
                                        .Select(x => new BoletimDTO(x)).ToList();
        }

        public IList<BoletimDTO> ObterTodos()
        {
            return _boletimRepositorio.ObterTodos()
                                        .Select(x => new BoletimDTO(x)).ToList();
        }
    }
}