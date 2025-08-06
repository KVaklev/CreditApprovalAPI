using CreditApprovalAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CreditApprovalAPI.Data
{
    public class CreditDbContext : DbContext
    {
        public CreditDbContext(DbContextOptions<CreditDbContext> options)
            : base(options) { }

        public DbSet<CreditRequest> CreditRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CreditRequest>()
                .HasIndex(r => r.RequestNumber)
                .IsUnique();
        }
    }
}


