using FinCtrl.Backend.Core.RestAPI.DAL.Interface;

namespace FinCtrl.Backend.Core.RestAPI.DAL.DTO.ModelDTO
{
    public class CategoryEditDTO : IDTO
    {
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public int? ParentCategoryId { get; set; }
    }
}
