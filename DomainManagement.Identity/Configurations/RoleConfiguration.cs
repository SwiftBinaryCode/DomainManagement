using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainManagement.Identity.Configurations
{
    // This class is responsible for configuring the default roles within the application's Identity system.
    // It implements the IEntityTypeConfiguration interface to seed default roles into the database.
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        // The Configure method is used to define the configuration of the IdentityRole entity type.
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            // Utilizing the HasData method to seed the database with default roles.
            // These roles will be added to the database upon its creation.
            builder.HasData(
                new IdentityRole
                {
                    // Creating a 'Customer' role with a specific ID, name, and normalized name.
                    // This role can be assigned to users who are customers within the application.
                    Id = "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                    Name = "Customer",
                    NormalizedName = "Customer"
                },
                new IdentityRole
                {
                    // Creating an 'Administrator' role with a specific ID, name, and normalized name.
                    // This role can be assigned to users who have administrative privileges within the application.
                    Id = "cbc43a8e-f7bb-4445-baaf-1add431ffbbf",
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR"
                }
            );
        }
    }
}
