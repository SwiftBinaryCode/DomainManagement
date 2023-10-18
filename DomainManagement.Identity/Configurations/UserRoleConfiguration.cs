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
    // This class configures the default user-role mappings within the application's Identity system.
    // It implements the IEntityTypeConfiguration interface to seed default user-role associations into the database.
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        // The Configure method defines the configuration of the IdentityUserRole entity type.
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            // Utilizing the HasData method to seed the database with default user-role mappings.
            // These mappings associate users with their respective roles.
            builder.HasData(
                new IdentityUserRole<string>
                {
                    // Associating the 'Admin' user with the 'Administrator' role.
                    // The UserId and RoleId are specified to create this association.
                    RoleId = "cbc43a8e-f7bb-4445-baaf-1add431ffbbf",
                    UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9"
                },
                new IdentityUserRole<string>
                {
                    // Associating a general 'User' with the 'Customer' role.
                    // Specific UserId and RoleId values are provided to establish this mapping.
                    RoleId = "cac43a6e-f7bb-4448-baaf-1add431ccbbf",
                    UserId = "9e224968-33e4-4652-b7b7-8574d048cdb9"
                }
            );
        }
    }
}
