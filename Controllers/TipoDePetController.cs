using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Pets.Domains;
using API_Pets.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Pets.Controllers
{
    [Route("pets/[controller]")]
    public class TipoDePetController : Controller
    {
        TipoDePetRepository repository = new TipoDePetRepository();
        [HttpGet]
        public List<TipoDePet> Get()
        {
            return repository.LerTodos();
        }

        [HttpGet("{id}")]
        public TipoDePet Get(int id)
        {
            return repository.BuscarPorId(id);
        }

        //[HttpPost("{id}")]
        public TipoDePet Post([FromBody] TipoDePet novoTipo)
        {
            return repository.Cadastrar(novoTipo);
        }

        [HttpPut("{id}")]
        public TipoDePet Put(int id, [FromBody] TipoDePet novoTipo)
        {
            return repository.Alterar(id, novoTipo);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repository.Excluir(id);
        }
    }
}