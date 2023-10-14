using DomainManagement.Application.Contracts.Persistence;
using DomainManagement.Persistence.DatabaseContext;
using DomainManagement.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DomainManagement.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DomainDatabaseContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("DomainDatabaseConnectionString"));
            });

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IDomainTypeRepository, DomainTypeRepository>();
            return services;

        }
    }
}
