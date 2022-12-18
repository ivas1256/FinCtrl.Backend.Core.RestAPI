using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace FinCtrl.Backend.Core.RestAPI.DAL.Interface
{
    public interface IRepository<TEntity,TDTO> 
        where TEntity : class, IEntity
        where TDTO: class, IDTO
    {        
        TEntity FindFirst(Expression<Func<TEntity, bool>> predicte);
        TEntity CreateOrGet(TEntity entity);
        List<TEntity> GetAll();        
        TEntity Get(int id);
        TEntity Create(TEntity entity);
        TEntity Update(TEntity entity);
        TEntity Delete(int id);
        EntityEntry<TEntity> CreateNoCommit(TEntity entity);
        void Commit();

        TEntity FromDTO(TDTO dto);
        TDTO ToDTO(TEntity entity);
        List<TDTO> GetAllDTO(int pageIndex = 1, int pageSize = 100, object filter = null);

        DbContext GetContext();
    }
}
