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
    public class RacaController : Controller
    {
        RacaRepository repository = new RacaRepository();
        [HttpGet]
        public List<Raca> Get()
        {
            return repository.LerTodos();
        }

        [HttpGet("{id}")]
        public Raca Get(int id)
        {
            return repository.BuscarPorId(id);
        }

        public Raca Post([FromBody] Raca novaRaca)
        {
            return repository.Cadastrar(novaRaca);
        }

        [HttpPut("{id}")]
        public Raca Put(int id, [FromBody] Raca novaRaca)
        {
            return repository.Alterar(id, novaRaca);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repository.Excluir(id);
        }
    }
}