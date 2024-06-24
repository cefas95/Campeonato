using Campeonato.Entities;
using Campeotano.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Campeonato.Api.Controllers
{
    [ApiController]
    [Route("api/equipos")]
    public class EquiposController : ControllerBase
    {
        private readonly EquipRepository repository;

        public EquiposController(EquipRepository repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        public ActionResult<List<Equipo>> Get() 
        {
            var data = repository.Get();
            return Ok(data);
        }
        [HttpGet("{id:int}")]
        public ActionResult<Equipo> Get(int id)
        {
            var item = repository.Get(id);
            return item is not null? Ok(item) : NotFound();
        }

        [HttpPost]
        public ActionResult<Equipo> Post(Equipo equipo)
        { 
            repository.Add(equipo);
            return Ok(equipo);
        }
        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Equipo equipo)
        { 
            repository.Update(id, equipo);
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id) 
        {
            repository.Delete(id);
            return Ok();

        }
    }
}
