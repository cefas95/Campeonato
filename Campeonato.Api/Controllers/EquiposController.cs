using Campeonato.Entities;
using Campeotano.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Campeonato.Api.Controllers
{
    [ApiController]
    [Route("api/equipos")]
    public class EquiposController : ControllerBase
    {
        private readonly IEquipRepository repository;

        public EquiposController(IEquipRepository repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        public async Task<IActionResult> Get() 
        {
            var data =await repository.GetAsync();
            return Ok(data);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var item = await repository.GetAsync(id);
            return item is not null? Ok(item) : NotFound();
        }

        [HttpPost]
        public async Task <IActionResult> Post(Equipo equipo)
        { 
            await repository.AddAsync(equipo);
            return Ok(equipo);
        }
        [HttpPut("{id:int}")]
        public async Task <IActionResult> Put(int id, Equipo equipo)
        { 
           await repository.UpdateAsync(id, equipo);
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id) 
        {
           await  repository.DeleteAsync(id);
            return Ok();

        }
    }
}
