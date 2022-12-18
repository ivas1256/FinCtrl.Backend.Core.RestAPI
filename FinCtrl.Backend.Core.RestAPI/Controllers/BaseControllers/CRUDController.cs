using AutoMapper;
using FinCtrl.Backend.Core.RestAPI.DAL.Implementation;
using FinCtrl.Backend.Core.RestAPI.DAL.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FinCtrl.Backend.Core.RestAPI.Controllers.BaseControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class CRUDController<TEntity, TDTO, TRep> : ControllerBase        
        where TEntity : class, IEntity
        where TDTO : class, IDTO
        where TRep : class, IRepository<TEntity, TDTO>
    {
        protected readonly TRep _repository;
        protected readonly IMapper _mapper;
        public CRUDController(TRep repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public virtual List<TDTO> GetAll(int pageIndex, int pageSize, string? filter = null)
        {            
            return _repository.GetAllDTO(pageIndex, pageSize, filter);
        }

        [HttpGet("{id}")]
        public ActionResult<TEntity> Get(int id)
        {
            var entity = _repository.Get(id);
            if (entity == null)
                return NotFound();
            return entity;
        }

        [HttpPut("{id}")]
        public virtual ActionResult Put(int id, TDTO dto)
        {
            var entity = _repository.FromDTO(dto);

            _repository.Update(entity);
            _repository.Commit();
            return NoContent();
        }

        [HttpPost]
        public ActionResult Post(TDTO dto)
        {
            var entity = _repository.FromDTO(dto);

            _repository.Create(entity);
            return CreatedAtAction(nameof(Get), new {Id = entity.ID}, entity);
        }

        [HttpDelete("{id}")]
        public ActionResult<TEntity> Delete(int id)
        {
            var entity = _repository.Delete(id);
            return entity;
        }
    }
}
