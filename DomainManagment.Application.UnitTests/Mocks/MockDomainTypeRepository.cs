using DomainManagement.Application.Contracts.Persistence;
using DomainManagement.Domain;
using Moq;

namespace DomainManagment.Application.UnitTests.Mocks
{
    public class MockDomainTypeRepository
    {
        // This method creates a mock of the IDomainTypeRepository interface for testing purposes.
        public static Mock<IDomainTypeRepository> GetMockDomainTypeRepository()
        {
            // Simulate a list of DomainType objects as test data.
            var domainTypes = new List<DomainType>
        {
            new DomainType
            {
                Id = 1,
                DomainName = "Test.com",
                OwnerName = "Test",
                Ip = "127.0.0.1"
            },
            new DomainType
            {
                Id = 2,
                DomainName = "Testing.com",
                OwnerName = "Testing",
                Ip = "127.0.2.1"
            }
        };

            // Create a mock repository for the IDomainTypeRepository interface.
            var mockRepo = new Mock<IDomainTypeRepository>();

            // Set up behavior for the GetAsync method.
            mockRepo.Setup(r => r.GetAsync()).ReturnsAsync(domainTypes);

            // Set up behavior for the CreateAsync method.
            mockRepo.Setup(r => r.CreateAsync(It.IsAny<DomainType>()))
                .Returns((DomainType domainType) =>
                {
                    // Add the provided DomainType object to the domainTypes list.
                    domainTypes.Add(domainType);
                    return Task.CompletedTask; // Return a completed Task.
                });

            // Return the mock repository for use in tests.
            return mockRepo;
        }
    }
}
