using FinCtrl.Backend.Core.RestAPI.DAL.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace FinCtrl.Backend.Core.RestAPI.DAL.Implementation
{
    public abstract class CRUDRepository<TEntity, TDBContext> : IRepository<TEntity>
        where TEntity : class, IEntity
        where TDBContext : DbContext
    {
        protected readonly TDBContext dbContext;
        public CRUDRepository(TDBContext dbContext)
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

        public virtual async Task<TEntity> CreateAsync(TEntity entity)
        {
            dbContext.Set<TEntity>().Add(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        public virtual TEntity Create(TEntity entity)
        {
            dbContext.Set<TEntity>().Add(entity);
            dbContext.SaveChanges();
            return entity;
        }

        public virtual EntityEntry<TEntity> CreateNoCommit(TEntity entity)
        {
            return dbContext.Set<TEntity>().Add(entity);
        }

        public virtual async Task<TEntity> DeleteAsync(int id)
        {
            var entity = await dbContext.Set<TEntity>().FindAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($"Deletion Id={id} not found in DB");

            dbContext.Set<TEntity>().Remove(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        public virtual TEntity Get(int id)
        {
            return dbContext.Set<TEntity>().Find(id);
        }
        public virtual async Task<TEntity> GetAsync(int id)
        {
            return await dbContext.Set<TEntity>().FindAsync(id);
        }

        public virtual async Task<List<TEntity>> GetAllAsync(int pageIndex = 1, int pageSize = 100)
        {
            //TODO: paging
            return await dbContext.Set<TEntity>().Take(pageSize).ToListAsync();
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            dbContext.Entry(entity).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
            return entity;
        }

        public async void Commit()
        {
            await dbContext.SaveChangesAsync();
        }
    }
}
