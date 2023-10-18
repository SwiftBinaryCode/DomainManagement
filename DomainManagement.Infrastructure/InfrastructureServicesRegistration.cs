using DomainManagement.Application.Contracts.Logging;
using DomainManagement.Infrastructure.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DomainManagement.Infrastructure
{
    // This static class provides extension methods to configure and register infrastructure services to the application's dependency injection container.
    public static class InfrastructureServicesRegistration
    {
        // Extension method to register infrastructure services and configurations.
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            // Registers a scoped generic application logger service to the services collection. 
            // The LoggerAdapter class is used as an adapter to plug in the actual logging implementation.
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

            // Returns the modified services collection to allow for chained configurations.
            return services;
        }
    }
}