using DomainManagement.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DomainManagement.Identity.DbContext
{
    // This class represents the application's identity context, extending the built-in IdentityDbContext with custom configurations.
    // It encapsulates the identity-related entities and configurations of the application.
    public class DomainManagementIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        // Constructor accepts options to configure the DbContext and passes them to the base IdentityDbContext.
        public DomainManagementIdentityDbContext(DbContextOptions<DomainManagementIdentityDbContext> options)
            : base(options)
        {
        }

        // Overrides the OnModelCreating method to apply custom configurations for identity entities.
        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Calls the base OnModelCreating method to apply default configurations provided by ASP.NET Core Identity.
            base.OnModelCreating(builder);

            // Applies custom configurations for identity entities that are defined in the same assembly as the current DbContext.
            // This is used to apply configurations for seeding default users, roles, etc., into the database.
            builder.ApplyConfigurationsFromAssembly(typeof(DomainManagementIdentityDbContext).Assembly);
        }
    }
}
