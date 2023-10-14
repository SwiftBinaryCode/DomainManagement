using DomainManagement.Domain;
using DomainManagement.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace DomainManagement.Persistence.DatabaseContext
{
    public class DomainDatabaseContext : DbContext
    {
        public DomainDatabaseContext(DbContextOptions<DomainDatabaseContext> options) : base(options) 
        
        { 
        
        
        }
        
        public DbSet<DomainType> DomainTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DomainDatabaseContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in base.ChangeTracker.Entries<BaseEntity>()
                .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
            {
                entry.Entity.DateModified = DateTime.Now;

                if (entry.State == EntityState.Added)
                {
                    entry.Entity.DateCreated = DateTime.Now;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
