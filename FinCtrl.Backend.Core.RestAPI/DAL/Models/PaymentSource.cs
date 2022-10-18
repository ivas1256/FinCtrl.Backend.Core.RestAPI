using FinCtrl.Backend.Core.RestAPI.DAL.Interface;

namespace FinCtrl.Backend.Core.RestAPI.DAL.Models
{
    public class PaymentSource : IEntity, ITimeLoggingEntity
    {
        public PaymentSource() { }
        public PaymentSource(int paymentSourceId, string paymentSourceName, Category? category = null) : this(paymentSourceId, paymentSourceName)
        {            
            Category = category;
        }
        private PaymentSource(int paymentSourceId, string paymentSourceName)
        {
            PaymentSourceId = paymentSourceId;
            PaymentSourceName = paymentSourceName;
        }

        public int PaymentSourceId { get; set; }
        public string PaymentSourceName { get; set; }
        public Category? Category { get; set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime LastUpdatedAt { get; private set; }

        public int ID => PaymentSourceId;
        public List<Payment> Payments { get; set; }
    }
}
