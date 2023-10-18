using DomainManagement.Application.Contracts.Persistence;
using DomainManagement.Persistence.DatabaseContext;
using DomainManagement.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DomainManagement.Persistence
{
    // Static class that contains extension methods for IServiceCollection to register persistence services and configurations.
    public static class PersistenceServiceRegistration
    {
        // Extension method that allows the registration of domain-specific services, database context and repositories.
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Registering DomainDatabaseContext with SQL Server and specific connection string from the configuration.
            services.AddDbContext<DomainDatabaseContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DomainDatabaseConnectionString"));
            });

            // Registering the generic repository implementation for use whenever IGenericRepository is required.
            // This supports dependency injection of repositories for various entity types.
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            // Registering the domain type-specific repository to provide additional, domain-specific query capabilities
            // beyond the generic repository interface.
            services.AddScoped<IDomainTypeRepository, DomainTypeRepository>();

            return services;
        }
    }
}
