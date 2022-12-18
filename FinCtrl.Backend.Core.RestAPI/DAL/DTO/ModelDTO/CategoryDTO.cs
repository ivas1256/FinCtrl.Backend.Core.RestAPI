using FinCtrl.Backend.Core.RestAPI.DAL.Interface;
using FinCtrl.Backend.Core.RestAPI.DAL.Models;

namespace FinCtrl.Backend.Core.RestAPI.DAL.DTO.ModelDTO
{
    public class CategoryDTO : IDTO
    {
        public CategoryDTO(int categoryId, string categoryName)
        {
            CategoryId = categoryId;
            CategoryName = categoryName;
        }

        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public CategoryDTO? ParentCategory { get; set; }
        public List<CategoryDTO>? ChildCategories { get; set; } = new List<CategoryDTO>();
    }
}