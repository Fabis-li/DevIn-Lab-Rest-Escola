using System.Diagnostics.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Escola.Domain.DTO;
using Escola.Domain.Interfaces.Services;
using Escola.Domain.Exceptions;
using Escola.Domain.Models;
using Microsoft.Extensions.Caching.Memory;
using Escola.Api.Config;

namespace Escola.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunosController : ControllerBase
    {

        private readonly IAlunoServico _alunoServico;
        
        private readonly CacheService<AlunoDTO> _alunoCache;
        
        public AlunosController(IAlunoServico alunoServico, CacheService<AlunoDTO> alunoCache)
        {
            alunoCache.Config("aluno", new TimeSpan(0,2,0));
            _alunoCache = alunoCache;
            _alunoServico = alunoServico;
            
        }

        [HttpGet]
        public IActionResult ObterTodos (int skip = 0, int take = 5){
            try{
                var paginacao = new Paginacao(take, skip) ;

                var totalRegistros = _alunoServico.ObterTotal();

                Response.Headers.Add("x-paginacao-TotalRegistros", totalRegistros.ToString());

                Response.Cookies.Append("TesteCookie", 
                                    Newtonsoft.Json.JsonConvert.SerializeObject(paginacao),
                                    new CookieOptions(){
                                        Expires = DateTimeOffset.Now.AddDays(5),
                                        //MaxAge = new TimeSpan(5,0,0,0)
                                    });              

                var uri = $"{Request.Scheme}://{Request.Host}";
                var alunos = new BaseDTO<IList<AlunoDTO>>(){
                    Data = _alunoServico.ObterTodos(paginacao),
                    Links = GetHateoasForAll(uri,take,skip, totalRegistros)};

                foreach(var aluno in alunos.Data){
                    aluno.Links = GetHateoas(aluno, uri);
                }

                return Ok(alunos);
            }
            catch{
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId (Guid id)
        {
            var cookie = Request.Cookies["TesteCookie"];
            var uri = $"{Request.Scheme}://{Request.Host}";
            AlunoDTO aluno;
            //var aluno = _cache.Get<AlunoDTO>($"aluno:{id}");

            if(!_alunoCache.TryGetValue($"aluno:{id}", out aluno)){
                 aluno = _alunoServico.ObterPorId(id);
                _alunoCache.Set(id.ToString(), aluno); 
                aluno.Links = GetHateoas(aluno, uri);               
            }
           
            return Ok(aluno);
        }

        [HttpPost]
        public IActionResult Inserir (AlunoDTO aluno){
           
            _alunoServico.Inserir(aluno);
                        
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(Guid id, [FromBody] AlunoDTO aluno){
            aluno.Id = id;
            _alunoServico.Atualizar(aluno);
            _alunoCache.Set(id.ToString(), aluno);
            //_cache.Remove($"aluno{id}");
            return Ok();          
           
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(Guid id){
            _alunoServico.Excluir(id);
            _alunoCache.Remove($"{id}");
            return StatusCode(StatusCodes.Status204NoContent);
            
        }

        private List<HateoasDTO> GetHateoas(AlunoDTO aluno, string baseUri){
            var hateoas = new List<HateoasDTO>(){
                new HateoasDTO(){
                    Rel = "self",
                    Type = "Get",
                    URI = $"{baseUri}/api/alunos/{aluno.Id}"
                },               
                new HateoasDTO(){
                    Rel = "aluno",
                    Type = "PUT",
                    URI = $"{baseUri}/api/alunos/{aluno.Id}"
                },
                new HateoasDTO(){
                    Rel = "aluno",
                    Type = "DELETE",
                    URI = $"{baseUri}/api/alunos/{aluno.Id}"
                }
            };

            if((DateTime.Now.Year - aluno.DataNascimento.Year) >= 24){
                hateoas.Add(
                    new HateoasDTO(){
                        Rel = "aluno",
                        Type = "POST",
                        URI = $"{baseUri}/api/alunos/{aluno.Id}/Matricular"
                    }
                );
            }
            return hateoas;
        }     
         private List<HateoasDTO> GetHateoasForAll(string baseUri, int take, int skip){
            var hateoas = new List<HateoasDTO>(){
                new HateoasDTO(){
                    Rel = "self",
                    Type = "Get",
                    URI = $"{baseUri}/api/alunos?skip={skip}take={take}"
                },               
                new HateoasDTO(){
                    Rel = "aluno",
                    Type = "POST",
                    URI = $"{baseUri}/api/alunos/"
                }
                
            };  
            var razao = skip - take;
            if(skip != 0){
                var newSkip = skip - razao;
                if(newSkip < 0)
                    newSkip = 0;  

                hateoas.Add(new HateoasDTO(){
                    Rel = "Prev",
                    Type = "Get",
                    URI = $"{baseUri}/api/alunos?skip={newSkip}take={take - razao}"
                });
            }

            if(take < ultimo){
                hateoas.Add(new HateoasDTO(){
                    Rel = "Prev",
                    Type = "Get",
                    URI = $"{baseUri}/api/alunos?skip={skip+razao}take={take+razao}"
                });
            }           

            return hateoas;
         } 
    }
}