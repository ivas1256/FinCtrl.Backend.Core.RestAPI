using FinCtrl.Backend.Core.RestAPI.DAL.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FinCtrl.Backend.Core.RestAPI.Controllers.BaseControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class CRUDController<TEntity, TRepository> : ControllerBase
        where TEntity : class, IEntity
        where TRepository : IRepository<TEntity>
    {
        protected readonly TRepository repository;
        public CRUDController(TRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<TEntity>>> Get()
        {
            return await repository.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TEntity>> Get(int id)
        {
            var entity = await repository.GetAsync(id);
            if (entity == null)
                return NotFound();
            return entity;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, TEntity entity)
        {
            if (id != entity.ID)
                return BadRequest();

            await repository.UpdateAsync(entity);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult> Post(TEntity entity)
        {
            await repository.CreateAsync(entity);
            return CreatedAtAction(nameof(Get), new {Id = entity.ID}, entity);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TEntity>> Delete(int id)
        {
            var entity = await repository.DeleteAsync(id);
            return entity;
        }
    }
}
