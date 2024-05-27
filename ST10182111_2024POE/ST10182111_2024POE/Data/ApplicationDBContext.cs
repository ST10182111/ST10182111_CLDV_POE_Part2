using Microsoft.EntityFrameworkCore;
using ST10182111_2024POE.Models;

namespace ST10182111_2024POE.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<UserLeadEntity> Users { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<UserPaymentEntity> Payments { get; set; }
        
    }
}
