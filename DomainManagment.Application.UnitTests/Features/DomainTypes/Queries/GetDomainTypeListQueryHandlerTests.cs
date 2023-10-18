using AutoMapper;
using DomainManagement.Application.Contracts.Logging;
using DomainManagement.Application.Contracts.Persistence;
using DomainManagement.Application.Features.DomainType.Queries.GetAllDomainTypes;
using DomainManagement.Application.MappingProfiles;
using DomainManagment.Application.UnitTests.Mocks;
using Moq;
using Shouldly;
using Xunit;

namespace DomainManagment.Application.UnitTests.Features.DomainTypes.Queries
{
    public class GetDomainTypeListQueryHandlerTests
    {
        private readonly Mock<IDomainTypeRepository> _mockRepo;
        private IMapper _mapper;
        private Mock<IAppLogger<GetDomainTypesQueryHandler>> _mockAppLogger;

        public GetDomainTypeListQueryHandlerTests()
        {
            // Create a mock repository with test data.
            _mockRepo = MockDomainTypeRepository.GetMockDomainTypeRepository();

            // Configure AutoMapper for mapping objects.
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<DomainTypeProfile>();
            });
            _mapper = mapperConfig.CreateMapper();

            // Create a mock logger for logging in the handler.
            _mockAppLogger = new Mock<IAppLogger<GetDomainTypesQueryHandler>>();
        }

        [Fact]
        public async Task GetDomainTypeListTest()
        {
            // Create an instance of the GetDomainTypesQueryHandler with dependencies.
            var handler = new GetDomainTypesQueryHandler(_mapper, _mockRepo.Object, _mockAppLogger.Object);

            // Call the Handle method to execute the query.
            var result = await handler.Handle(new GetDomainTypesQuery(), CancellationToken.None);

            // Assertions for the test result.
            result.ShouldBeOfType<List<DomainTypeDto>>(); // Ensure the result is a list of DomainTypeDto.
            result.Count.ShouldBe(2); // Check if the list contains 2 items.
        }
    }
}
