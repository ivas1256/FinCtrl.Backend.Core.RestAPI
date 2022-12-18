using FinCtrl.Backend.Core.RestAPI.DAL.DTO.ModelDTO;
using FinCtrl.Backend.Core.RestAPI.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinCtrl.Backend.Core.RestAPI.DAL.Implementation
{
    public class PaymentSourceRepository : CRUDRepository<PaymentSource, PaymentSourceDTO, FinCtrlDBContext>
    {
        CategoryRepository categoryRepository;
        public PaymentSourceRepository(FinCtrlDBContext dbContext, CategoryRepository categoryRepository) : base(dbContext)
        {
            this.categoryRepository = categoryRepository;
        }
        public override List<PaymentSource> GetAll()
        {
            return dbContext.Set<PaymentSource>()
                .OrderBy(x => x.PaymentSourceId)
                .Include(e => e.Category)
                .ToList();
        }

        public override PaymentSource Get(int id)
        {
            return dbContext.PaymentSources.Include(x => x.Category).FirstOrDefault(x => x.PaymentSourceId == id);
        }

        public override PaymentSource CreateOrGet(PaymentSource entity)
        {
            var check = FindFirst(x => x.PaymentSourceName == entity.PaymentSourceName);
            if (check != null)
                return check;
            return Create(entity);
        }

        public int SetCategory(int id, int categoryId)
        {
            var entity = Get(id);
            entity.Category = categoryRepository.Get(categoryId);

            return dbContext.SaveChanges();
        }

        public override List<PaymentSourceDTO> GetAllDTO(int pageIndex = 1, int pageSize = 100, object filter = null)
        {
            return dbContext.PaymentSources.Include("Category")
                .Select(x => new PaymentSourceDTO(x.PaymentSourceId, x.PaymentSourceName)
                {
                    Category = x.Category != null ? new CategoryDTO(x.Category.ID, x.Category.CategoryName) : null
                })
                .ToList();
        }

        public override PaymentSource FromDTO(PaymentSourceDTO dto)
        {
            var entity = Get(dto.PaymentSourceId);

            if (!string.IsNullOrEmpty(dto.PaymentSourceName))
                entity.PaymentSourceName = dto.PaymentSourceName;
            if (dto.Category != null || dto.Category?.CategoryId != entity.Category?.CategoryId)
                entity.Category = dbContext.Categories.Find(dto.Category.CategoryId);

            return entity;
        }
    }
}
