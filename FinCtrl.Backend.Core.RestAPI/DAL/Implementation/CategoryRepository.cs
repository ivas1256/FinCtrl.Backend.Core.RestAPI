using FinCtrl.Backend.Core.RestAPI.DAL.Models;

namespace FinCtrl.Backend.Core.RestAPI.DAL.Implementation
{
    public class CategoryRepository : CRUDRepository<Category, FinCtrlDBContext>
    {
        public CategoryRepository(FinCtrlDBContext dbContext) : base(dbContext)
        {
        }
    }
}
