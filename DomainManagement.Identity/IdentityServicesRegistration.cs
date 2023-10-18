using DomainManagement.Application.Contracts.Identity;
using DomainManagement.Application.Models.Identity;
using DomainManagement.Identity.DbContext;
using DomainManagement.Identity.Models;
using DomainManagement.Identity.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace DomainManagement.Identity
{
    // This static class provides extension methods to configure and register identity and authentication services to the application's dependency injection container.
    public static class IdentityServicesRegistration
    {
        // Extension method to register identity services and configurations.
        public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Configures JwtSettings from the application configuration.
            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

            // Registers and configures the DbContext for identity management, using a connection string from the application configuration.
            services.AddDbContext<DomainManagementIdentityDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DomainDatabaseConnectionString")));

            // Registers the application's user model and role model to the identity services, and configures the identity to use the specified DbContext.
            services.AddIdentity<ApplicationUser, IdentityRole>()
                 .AddEntityFrameworkStores<DomainManagementIdentityDbContext>().AddDefaultTokenProviders();

            // Registers the AuthService and UserService for dependency injection.
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IUserService, UserService>();

            // Configures the authentication services to use JWT Bearer authentication.
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                // Sets the options for JWT Bearer token validation.
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidIssuer = configuration["JwtSettings:Issuer"],
                    ValidAudience = configuration["JwtSettings:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]))

                };
            });

            // Returns the modified services collection to allow for chained configurations.
            return services;
        }
    }
}
