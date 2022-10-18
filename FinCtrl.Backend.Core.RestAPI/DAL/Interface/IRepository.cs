using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace FinCtrl.Backend.Core.RestAPI.DAL.Interface
{
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        TEntity FindFirst(Expression<Func<TEntity, bool>> predicte);
        TEntity CreateOrGet(TEntity entity);
        Task<List<TEntity>> GetAllAsync(int pageIndex = 1, int pageSize = 100);
        Task<TEntity> GetAsync(int id);
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<TEntity> DeleteAsync(int id);
        EntityEntry<TEntity> CreateNoCommit(TEntity entity);
        void Commit();
    }
}
