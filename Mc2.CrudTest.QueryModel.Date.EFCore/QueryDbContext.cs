using System.Diagnostics.CodeAnalysis;
using Mc2.CrudTest.QueryModel.Models.Models.Customers;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.QueryModel.Date.EFCore
{
    public class QueryDbContext : DbContext
    {
        public QueryDbContext([NotNull] DbContextOptions options) : base(options)
        {
        }

        public DbSet<CustomerQueryModel> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}