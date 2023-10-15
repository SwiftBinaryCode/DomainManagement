using DomainManagement.Application.Contracts.Persistence;
using DomainManagement.Domain;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainManagment.Application.UnitTests.Mocks
{
    public class MockDomainTypeRepository
    {
        public static Mock<IDomainTypeRepository> GetMockDomainTypeRepository()
        {
            var domainTypes = new List<DomainType>
            {
                new DomainType
                {
                    Id = 1,
                    DomainName = "Test.com",
                    OwnerName = "Test",
                    Ip="127.0.0.1"
                    
                },
                new DomainType
                {
                    Id = 2,
                    DomainName = "Testing.com",
                    OwnerName = "Testing",
                    Ip="127.0.2.1"
                },
               
            };

            var mockRepo = new Mock<IDomainTypeRepository>();

            mockRepo.Setup(r => r.GetAsync()).ReturnsAsync(domainTypes);

            mockRepo.Setup(r => r.CreateAsync(It.IsAny<DomainType>()))
                .Returns((DomainType domainType) =>
                {
                    domainTypes.Add(domainType);
                    return Task.CompletedTask;
                });

            return mockRepo;
        }
    }
}
