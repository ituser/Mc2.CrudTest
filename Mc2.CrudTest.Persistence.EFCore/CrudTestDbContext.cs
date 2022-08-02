using System.Threading;
using System.Threading.Tasks;
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

        public DbSet<EventModel> EventModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            modelBuilder.Ignore<DomainEvent>();

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken())
        {
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}