    using FinCtrl.Backend.Core.RestAPI.DAL.Interface;
using FinCtrl.Backend.Core.RestAPI.DAL.Models;

namespace FinCtrl.Backend.Core.RestAPI.DAL.DTO.ModelDTO
{
    public class PaymentDTO : IDTO
    {
        public int PaymentId { get; set; }
        public PaymentTypes? PaymentType { get; set; }
        public decimal? PaymentSum { get; set; }
        public DateTime? PaymentDate { get; set; }
        public PaymentSourceDTO? PaymentSource { get; set; }
        public CategoryDTO? PaymentCategory { get; set; }
        public string? PaymentDescription { get; set; }
    }
}
