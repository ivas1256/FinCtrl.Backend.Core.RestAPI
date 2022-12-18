using FinCtrl.Backend.Core.RestAPI.DAL.Interface;

namespace FinCtrl.Backend.Core.RestAPI.DAL.DTO.ModelDTO
{
    public class PaymentSourceDTO : IDTO
    {
        public PaymentSourceDTO(int paymentSourceId, string paymentSourceName)
        {
            PaymentSourceId = paymentSourceId;
            PaymentSourceName = paymentSourceName;
        }

        public int PaymentSourceId { get; set; }
        public string? PaymentSourceName { get; set; }
        public CategoryDTO? Category { get; set; }
    }
}