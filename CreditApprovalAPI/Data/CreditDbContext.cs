using CreditApprovalAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CreditApprovalAPI.Data
{
    /// <summary>
    /// Represents the application's database context for managing credit-related data.
    /// </summary>
    public class CreditDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreditDbContext"/> class.
        /// </summary>
        /// <param name="options">Options used to configure the context.</param>
        public CreditDbContext(DbContextOptions<CreditDbContext> options)
            : base(options) { }

        /// <summary>
        /// Gets or sets the <see cref="DbSet{TEntity}"/> for credit requests.
        /// </summary>
        public DbSet<CreditRequest> CreditRequests { get; set; }

        /// <summary>
        /// Configures entity mappings and constraints using the model builder.
        /// </summary>
        /// <param name="modelBuilder">The model builder used to configure entities.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CreditRequest>()
                .HasIndex(r => r.RequestNumber)
                .IsUnique();
        }
    }
}
