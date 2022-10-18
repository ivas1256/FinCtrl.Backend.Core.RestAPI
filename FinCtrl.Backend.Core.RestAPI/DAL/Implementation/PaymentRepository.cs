using FinCtrl.Backend.Core.RestAPI.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace FinCtrl.Backend.Core.RestAPI.DAL.Implementation
{
    public class PaymentRepository : CRUDRepository<Payment, FinCtrlDBContext>
    {
        public PaymentRepository(FinCtrlDBContext dbContext) : base(dbContext)
        {
        }

        public override async Task<Payment> GetAsync(int id)
        {
            return await dbContext.Set<Payment>()
                .Include(e => e.PaymentSource)
                .Include(e => e.PaymentCategory)
                .Where(x => x.PaymentId == id)
                .Select(x => new Payment(
                    x.PaymentId,
                    PaymentTypes.Spending, // TODO: it's for test
                    x.PaymentSum,
                    x.PaymentDate,
                    x.PaymentSource)
                {
                    PaymentCategory = x.PaymentCategory,
                    PaymentDescription = x.PaymentDescription
                })
                .FirstOrDefaultAsync();
        }

        public override async Task<List<Payment>> GetAllAsync(int pageIndex = 1, int pageSize = 100)
        {
            return await dbContext.Set<Payment>()
                .Include(e => e.PaymentSource)
                .Include(e => e.PaymentCategory)
                .OrderByDescending(x => x.PaymentDate)
                .Select(x => new Payment(
                    x.PaymentId,
                    PaymentTypes.Spending, // TODO: it's for test
                    x.PaymentSum,
                    x.PaymentDate,
                    x.PaymentSource)
                {
                    PaymentCategory = x.PaymentCategory,
                    PaymentDescription = x.PaymentDescription
                }
                )
                .Take(100)                
                .ToListAsync();
        }

        public bool Exists(Payment payment)
        {
            var date = payment.PaymentDate;
            var sum = payment.PaymentSum;

            return dbContext.Set<Payment>().Any(x => x.PaymentDate == date && x.PaymentSum == sum);
        }
    }
}