using AutoMapper;
using DomainManagement.Application.Contracts.Logging;
using DomainManagement.Application.Contracts.Persistence;
using DomainManagement.Application.Features.DomainType.Queries.GetAllDomainTypes;
using DomainManagement.Application.MappingProfiles;
using DomainManagment.Application.UnitTests.Mocks;
using Moq;
using Shouldly;

namespace DomainManagment.Application.UnitTests.Features.DomainTypes.Queries
{
    public class GetDomainTypeListQueryHandlerTests
    {
        private readonly Mock<IDomainTypeRepository> _mockRepo;
        private IMapper _mapper;
        private Mock<IAppLogger<GetDomainTypesQueryHandler>> _mockAppLogger;

        public GetDomainTypeListQueryHandlerTests()
        {
            _mockRepo = MockDomainTypeRepository.GetMockDomainTypeRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<DomainTypeProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _mockAppLogger = new Mock<IAppLogger<GetDomainTypesQueryHandler>>();
        }

        [Fact]
        public async Task GetDomainTypeListTest()
        {
            var handler = new GetDomainTypesQueryHandler(_mapper, _mockRepo.Object, _mockAppLogger.Object);

            var result = await handler.Handle(new GetDomainTypesQuery(), CancellationToken.None);

            result.ShouldBeOfType<List<DomainTypeDto>>();
            result.Count.ShouldBe(2);
        }
    }
}
