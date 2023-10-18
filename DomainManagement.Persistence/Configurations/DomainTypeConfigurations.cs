using DomainManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomainManagement.Persistence.Configurations
{
    // This class is responsible for configuring the model entity DomainType for Entity Framework.
    // It defines seeding data and constraints for the properties of the DomainType entity.
    public class DomainTypeConfigurations : IEntityTypeConfiguration<DomainType>
    {
        // The Configure method applies configurations to the DomainType entity using the provided builder.
        public void Configure(EntityTypeBuilder<DomainType> builder)
        {
            // Seeding data for the DomainType entity. 
            // This will insert a DomainType record with the provided details when the database is created.
            builder.HasData(
                new DomainType
                {
                    Id = 1,
                    DomainName = "example.com",
                    OwnerName = "example",
                    Ip = "127.0.0.1",
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now
                }
            );

            // Configuring the DomainName property of the DomainType entity.
            // It is set as required and has a maximum length constraint of 100 characters.
            builder.Property(q => q.DomainName)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
