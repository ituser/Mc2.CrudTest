using Mc2.CrudTest.Domain.Models.Customers;
using Mc2.CrudTest.Framework;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Persistence.EFCore
{
    public class CrudTestDbContext : DbContext
    {
        public CrudTestDbContext(DbContextOptions options) : base(options)
        {
        }

        public CrudTestDbContext()
        {
            
        }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            modelBuilder.Ignore<DomainEvent>();

            base.OnModelCreating(modelBuilder);
        }
    }
}