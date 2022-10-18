using FinCtrl.Backend.Core.RestAPI.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinCtrl.Backend.Core.RestAPI.DAL.Implementation
{
    public class PaymentSourceRepository : CRUDRepository<PaymentSource, FinCtrlDBContext>
    {
        CategoryRepository categoryRepository;
        public PaymentSourceRepository(FinCtrlDBContext dbContext, CategoryRepository categoryRepository) : base(dbContext)
        {
            this.categoryRepository = categoryRepository;
        }
        public override async Task<List<PaymentSource>> GetAllAsync(int pageIndex = 1, int pageSize = 100)
        {
            return await dbContext.Set<PaymentSource>()
                .OrderBy(x => x.PaymentSourceId)
                .Include(e => e.Category)
                .ToListAsync();
        }

        public override PaymentSource CreateOrGet(PaymentSource entity)
        {
            var check = FindFirst(x => x.PaymentSourceName == entity.PaymentSourceName);
            if (check != null)
                return check;
            return Create(entity);
        }

        public async Task<int> SetCategoryAsync(int id, int categoryId)
        {
            var entity = Get(id);
            entity.Category = categoryRepository.Get(categoryId);

            return await dbContext.SaveChangesAsync();
        }
    }
}
