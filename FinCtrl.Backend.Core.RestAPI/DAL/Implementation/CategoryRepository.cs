using FinCtrl.Backend.Core.RestAPI.DAL.DTO.ModelDTO;
using FinCtrl.Backend.Core.RestAPI.DAL.Interface;
using FinCtrl.Backend.Core.RestAPI.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FinCtrl.Backend.Core.RestAPI.DAL.Implementation
{
    public class CategoryRepository : CRUDRepository<Category, CategoryDTO, FinCtrlDBContext>
    {
        public CategoryRepository(FinCtrlDBContext dbContext) : base(dbContext)
        {
        }

        public override Category Get(int id)
        {
            return dbContext.Categories.Include(x => x.ParentCategory).FirstOrDefault(x => x.CategoryId == id);
        }

        public override List<CategoryDTO> GetAllDTO(int pageIndex = 1, int pageSize = 100, object filter = null)
        {
            var e = dbContext.Categories
                .Include(x => x.ParentCategory)
                .Include(x => x.ChildCategories)
                .ToList();

            var res = new List<CategoryDTO>();
            foreach (var cat in e)
                res.Add(ConvertToDTO(cat));

            return res.Where(x => x.ParentCategory == null).ToList();
        }

        public List<CategoryDTO> GetPlainList()
        {
            return dbContext.Categories
                .Select(x => new CategoryDTO(x.CategoryId, x.CategoryName))
                .ToList();
        }

        CategoryDTO ConvertToDTO(Category category)
        {
            var dto = new CategoryDTO(category.ID, category.CategoryName);
            if (category.ParentCategory != null)
                dto.ParentCategory = new CategoryDTO(category.ParentCategory.ID, category.ParentCategory.CategoryName);
            foreach (var child in category.ChildCategories)
                dto.ChildCategories.Add(ConvertToDTO(child));
            return dto;
        }

        public override Category FromDTO(CategoryDTO dto)
        {
            var entity = dto.CategoryId <= 0 ? new Category() : Get(dto.CategoryId);

            entity.CategoryName = dto.CategoryName;
            if (dto.ParentCategory != null)
                entity.ParentCategory = dbContext.Categories.Find(dto.ParentCategory.CategoryId);
            else
                entity.ParentCategory = null;

            return entity;
        }
    }
}
