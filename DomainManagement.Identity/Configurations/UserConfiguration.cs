using DomainManagement.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomainManagement.Identity.Configurations
{
    // This class is responsible for configuring the default users within the application's Identity system.
    // It implements the IEntityTypeConfiguration interface to seed default users into the database.
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        // The Configure method is used to define the configuration of the ApplicationUser entity type.
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            // Creating an instance of PasswordHasher to hash the passwords of the seeded users.
            var hasher = new PasswordHasher<ApplicationUser>();

            // Utilizing the HasData method to seed the database with default users.
            // These users will be added to the database upon its creation.
            builder.HasData(
                new ApplicationUser
                {
                    // Creating an 'Admin' user with specific details including hashed password.
                    // This user has administrative privileges within the application.
                    Id = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                    Email = "admin@localhost.com",
                    NormalizedEmail = "ADMIN@LOCALHOST.COM",
                    FirstName = "System",
                    LastName = "Admin",
                    UserName = "admin@localhost.com",
                    NormalizedUserName = "ADMIN@LOCALHOST.COM",
                    PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                    EmailConfirmed = true
                },
                new ApplicationUser
                {
                    // Creating a 'User' with specific details including hashed password.
                    // This user represents a general user role within the application.
                    Id = "9e224968-33e4-4652-b7b7-8574d048cdb9",
                    Email = "user@localhost.com",
                    NormalizedEmail = "USER@LOCALHOST.COM",
                    FirstName = "System",
                    LastName = "User",
                    UserName = "user@localhost.com",
                    NormalizedUserName = "USER@LOCALHOST.COM",
                    PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                    EmailConfirmed = true
                }
            );
        }
    }
}
