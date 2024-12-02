using System.Xml;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Repository;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IRepository<Entity> _repository;

        public WeatherForecastController(IRepository<Entity> repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Entity entity)
        {
            var createdEntity = await _repository.CreateAsync(entity);
            return Ok(createdEntity);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(string id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return NotFound();
            return Ok(entity);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return Ok(entities);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(string id, Entity entity)
        {
            var success = await _repository.UpdateAsync(id, entity);
            if (!success) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            var success = await _repository.DeleteAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
