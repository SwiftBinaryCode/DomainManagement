using DomainManagement.Domain;
using DomainManagement.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace DomainManagement.Persistence.DatabaseContext
{
    // The DomainDatabaseContext class represents a session with the database and can be used 
    // to query and save instances of the entities. It's a concrete class that inherits from DbContext.
    public class DomainDatabaseContext : DbContext
    {
        // Constructor accepting DbContextOptions, allowing configurations to be passed in, e.g. connecting string.
        public DomainDatabaseContext(DbContextOptions<DomainDatabaseContext> options)
            : base(options)
        {
        }

        // Represents a collection of all DomainType entities in the context, or that can be queried from the database.
        public DbSet<DomainType> DomainTypes { get; set; }

        // Overrides the base OnModelCreating method to apply configurations from an assembly.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Applies all configurations provided in the same assembly as the context.
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DomainDatabaseContext).Assembly);

            // Calls the base method to complete the model creation.
            base.OnModelCreating(modelBuilder);
        }

        // Overrides the base SaveChangesAsync method to add date/time stamping to entities.
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            // Iterates over entities that are being added or updated.
            foreach (var entry in base.ChangeTracker.Entries<BaseEntity>()
                .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
            {
                // Sets the DateModified property to the current date/time.
                entry.Entity.DateModified = DateTime.Now;

                // If the entity is being added, sets the DateCreated property to the current date/time.
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.DateCreated = DateTime.Now;
                }
            }

            // Calls the base method to save changes in the context.
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
