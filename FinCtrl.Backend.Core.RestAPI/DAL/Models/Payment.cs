using FinCtrl.Backend.Core.RestAPI.DAL.Interface;

namespace FinCtrl.Backend.Core.RestAPI.DAL.Models
{
    public enum PaymentTypes { Income, Spending, InvocieTransfer, CardTransfer }

    public class Payment : IEntity, ITimeLoggingEntity
    {
        public Payment(DateTime date, decimal sum)
        {
            PaymentDate = date;
            PaymentSum = sum;
        }

        public Payment(int paymentId, PaymentTypes paymentType, decimal paymentSum, DateTime paymentDate, PaymentSource paymentSource)
            : this(paymentId, paymentType, paymentSum, paymentDate)
        {
            PaymentSource = paymentSource;
        }
        private Payment(int paymentId, PaymentTypes paymentType, decimal paymentSum, DateTime paymentDate)
        {
            PaymentId = paymentId;
            PaymentType = paymentType;
            PaymentSum = paymentSum;
            PaymentDate = paymentDate;
        }        

        public int PaymentId { get; set; }
        public PaymentTypes PaymentType { get; set; }
        public decimal PaymentSum { get; set; }
        public DateTime PaymentDate { get; set; }
        public PaymentSource PaymentSource { get; set; }
        public Category? PaymentCategory { get; set; }
        public string? PaymentDescription { get; set; }

        public DateTime CreatedAt { get; private set; }
        public DateTime LastUpdatedAt { get; private set; }

        public int ID => PaymentId;
    }
}
