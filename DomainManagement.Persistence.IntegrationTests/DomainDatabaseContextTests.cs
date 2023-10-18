using DomainManagement.Domain;
using DomainManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using Xunit;

namespace DomainManagement.Persistence.IntegrationTests
{
    // This class is for testing the DomainDatabaseContext to ensure it functions as expected.
    public class DomainDatabaseContextTests
    {
        // A private field to hold an instance of DomainDatabaseContext for testing.
        private DomainDatabaseContext _domainDatabaseContext;

        // The constructor initializes the testing context, using an in-memory database
        // to avoid affecting a real database.
        public DomainDatabaseContextTests()
        {
            var dbOptions = new DbContextOptionsBuilder<DomainDatabaseContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            _domainDatabaseContext = new DomainDatabaseContext(dbOptions);
        }

        // This test checks if DateCreated property is being set when a new domain type is added.
        [Fact]
        public async void Save_SetDateCreatedValue()
        {
            // Arrange: create a domain type object to be saved.
            var domainType = new DomainType
            {
                Id = 1,
                DomainName = "example.com",
                OwnerName = "example",
                Ip = "127.0.0.1"
            };

            // Act: add the domain type to the context and save changes to set DateCreated.
            await _domainDatabaseContext.DomainTypes.AddAsync(domainType);
            await _domainDatabaseContext.SaveChangesAsync();

            // Assert: check if DateCreated property has been set.
            domainType.DateCreated.ShouldNotBeNull();
        }

        // This test is similar to the above but checks the DateModified property instead.
        [Fact]
        public async void Save_SetDateModifiedValue()
        {
            // Arrange: create a domain type object to be saved.
            var domainType = new DomainType
            {
                Id = 1,
                DomainName = "example.com",
                OwnerName = "example",
                Ip = "127.0.0.1"
            };

            // Act: add the domain type to the context and save changes to set DateModified.
            await _domainDatabaseContext.DomainTypes.AddAsync(domainType);
            await _domainDatabaseContext.SaveChangesAsync();

            // Assert: check if DateModified property has been set.
            domainType.DateModified.ShouldNotBeNull();
        }
    }

}