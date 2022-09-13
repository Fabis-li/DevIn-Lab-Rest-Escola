using Escola.Domain.DTO;
using Escola.Domain.Interfaces.Services;
using Escola.Domain.Interfaces.Repositories;
using Escola.Domain.Models;
using Escola.Domain.Exceptions;

namespace Escola.Domain.Services
{
    
    public class MateriaServico : IMateriaServico
    {
        private readonly IMateriaRespositorio _materiaRepositorio;
        public MateriaServico(IMateriaRespositorio materiaRepositorio)
        {
            _materiaRepositorio = materiaRepositorio;
        }
        public void Atualizar(MateriaDTO materia)
        {
           var materiaDB =  _materiaRepositorio.ObterPorId(materia.Id);           

            if(materiaDB == null)
                throw new RegistroExistenteException("Materia não cadastrada");

           materiaDB.UpDate(materia);
           
           _materiaRepositorio.Atualizar(materiaDB);
        }

        public void Excluir(int id)
        {
           var materiaId = _materiaRepositorio.ObterPorId(id);

            if(materiaId == null)
                throw new RegistroExistenteException("Materia não encontrada");

           _materiaRepositorio.Excluir(materiaId);
        }

        public void Inserir(MateriaDTO materia)
        {
            var jaExiste = _materiaRepositorio.ObterPorNome(materia.Nome);

            if(jaExiste.Count > 0)
            throw new DuplicadoException("Materia já existe");

            _materiaRepositorio.Inserir(new Materia (materia));
            
        }

        public MateriaDTO ObterPorId(int id)
        {
            return new MateriaDTO( _materiaRepositorio.ObterPorId(id));
        }

        public List<MateriaDTO> ObterPorNome(string nome)
        {
            return _materiaRepositorio.ObterPorNome(nome)
                                        .Select(x => new MateriaDTO(x)).ToList();
        }

        public IList<MateriaDTO> ObterTodos(Paginacao paginacao)
        {
            return _materiaRepositorio.ObterTodos(paginacao)
                                        .Select(x => new MateriaDTO(x)).ToList();
        }
        

        public int ObterTotal()
        {
           return _materiaRepositorio.ObterTotal();
        }
    }
}