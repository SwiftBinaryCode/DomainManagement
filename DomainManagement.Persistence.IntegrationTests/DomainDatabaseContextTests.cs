using DomainManagement.Domain;
using DomainManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Shouldly;

namespace DomainManagement.Persistence.IntegrationTests
{
    public class DomainDatabaseContextTests
    {
    
        private DomainDatabaseContext _domainDatabaseContext;

        public DomainDatabaseContextTests()
        {
            var dbOptions = new DbContextOptionsBuilder<DomainDatabaseContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            _domainDatabaseContext = new DomainDatabaseContext(dbOptions);
        }

        [Fact]
        public async void Save_SetDateCreatedValue()
        {
            // Arrange
            var domainType = new DomainType
            {
                Id = 1,
                DomainName = "example.com",
                OwnerName = "example",
                Ip = "127.0.0.1"

            };

            // Act
            await _domainDatabaseContext.DomainTypes.AddAsync(domainType);
            await _domainDatabaseContext.SaveChangesAsync();

            // Assert
            domainType.DateCreated.ShouldNotBeNull();
        }

        [Fact]
        public async void Save_SetDateModifiedValue()
        {
            // Arrange
            var domainType = new DomainType
            {
                Id = 1,
                DomainName = "example.com",
                OwnerName = "example",
                Ip = "127.0.0.1"

            };

            // Act
            await _domainDatabaseContext.DomainTypes.AddAsync(domainType);
            await _domainDatabaseContext.SaveChangesAsync();

            // Assert
            domainType.DateModified.ShouldNotBeNull();
        }
    }
    
}