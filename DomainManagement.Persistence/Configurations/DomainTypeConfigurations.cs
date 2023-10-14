using DomainManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomainManagement.Persistence.Configurations
{
    public class DomainTypeConfigurations : IEntityTypeConfiguration<DomainType>
    {
        public void Configure(EntityTypeBuilder<DomainType> builder)
        {
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

            builder.Property(q => q.DomainName)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
