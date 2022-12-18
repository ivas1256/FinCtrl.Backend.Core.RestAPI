using FinCtrl.Backend.Core.RestAPI.DAL.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace FinCtrl.Backend.Core.RestAPI.DAL.Implementation
{
    public abstract class CRUDRepository<TEntity, TDTO, TDbcontext> : IRepository<TEntity,TDTO>
        where TEntity : class, IEntity        
        where TDTO : class, IDTO
        where TDbcontext : DbContext
    {
        public readonly TDbcontext dbContext;
        public CRUDRepository(TDbcontext dbContext)
        {
            this.dbContext = dbContext;
        }

        public virtual TEntity FindFirst(Expression<Func<TEntity, bool>> predicte)
        {
            return dbContext.Set<TEntity>().FirstOrDefault(predicte);
        }

        public virtual TEntity CreateOrGet(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual TEntity Create(TEntity entity)
        {
            dbContext.Set<TEntity>().Add(entity);
            Commit();
            return entity;
        }

        public virtual EntityEntry<TEntity> CreateNoCommit(TEntity entity)
        {
            return dbContext.Set<TEntity>().Add(entity);
        }

        public virtual TEntity Delete(int id)
        {
            var entity = dbContext.Set<TEntity>().Find(id);
            if (entity == null)
                throw new KeyNotFoundException($"Deletion Id={id} not found in DB");

            dbContext.Set<TEntity>().Remove(entity);
            Commit();
            return entity;
        }

        public virtual TEntity Get(int id)
        {            
            return dbContext.Set<TEntity>().Find(id);
        }

        public virtual List<TEntity> GetAll()
        {
            //TODO: paging
            return dbContext.Set<TEntity>().ToList();
        }

        public virtual TEntity Update(TEntity entity)
        {
            dbContext.Entry(entity).State = EntityState.Modified;
            
            return entity;
        }

        public void Commit()
        {
            dbContext.SaveChanges();
        }

        public virtual List<TDTO> GetAllDTO(int pageIndex, int pageSize, object filter = null)
        {
            throw new NotImplementedException();
        }

        public virtual TEntity FromDTO(TDTO dto)
        {
            throw new NotImplementedException();
        }

        public virtual TDTO ToDTO(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public DbContext GetContext()
        {
            return dbContext;
        }
    }
}
