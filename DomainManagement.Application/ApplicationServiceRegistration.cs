using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DomainManagement.Application
{
    // This static class is used for registering application-level services 
    // into the dependency injection container, enhancing modularity and maintainability.
    public static class ApplicationServiceRegistration
    {
        // This extension method allows for the easy addition of application services 
        // by extending the IServiceCollection interface.
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Registering the AutoMapper service and configuring it to use 
            // the current executing assembly to scan for profiles.
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // Registering the MediatR service and configuring it to 
            // register handlers, pre-processors, and post-processors from the current executing assembly.
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            // Returning the modified service collection with the added services.
            return services;
        }
    }
}
