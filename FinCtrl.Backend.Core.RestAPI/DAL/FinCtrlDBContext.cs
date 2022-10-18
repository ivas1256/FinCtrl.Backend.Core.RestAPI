using FinCtrl.Backend.Core.RestAPI.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace FinCtrl.Backend.Core.RestAPI.DAL
{
    public class FinCtrlDBContext : DbContext
    {
        public FinCtrlDBContext(DbContextOptions<FinCtrlDBContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<PaymentSource> PaymentSources { get; set; } = null!;
        public DbSet<Payment> Payments { get; set; } = null!;
    }
}
