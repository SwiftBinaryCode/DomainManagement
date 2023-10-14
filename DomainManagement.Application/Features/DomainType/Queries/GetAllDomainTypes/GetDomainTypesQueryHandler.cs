using AutoMapper;
using DomainManagement.Application.Contracts.Logging;
using DomainManagement.Application.Contracts.Persistence;
using MediatR;

namespace DomainManagement.Application.Features.DomainType.Queries.GetAllDomainTypes
{
    public class GetDomainTypesQueryHandler : IRequestHandler<GetDomainTypesQuery, List<DomainTypeDto>>
    {
        private readonly IMapper _mapper;
        private readonly IDomainTypeRepository _domainTypeRepository;
        private readonly IAppLogger<GetDomainTypesQueryHandler> _logger;

        public GetDomainTypesQueryHandler(IMapper mapper, IDomainTypeRepository domainTypeRepository, IAppLogger<GetDomainTypesQueryHandler> logger)
        {
            this._mapper = mapper;
            this._domainTypeRepository = domainTypeRepository;
            this._logger = logger;
        }

        public async Task<List<DomainTypeDto>> Handle(GetDomainTypesQuery request, CancellationToken cancellationToken)
        {
            //query the database
            var domainTypes = await  _domainTypeRepository.GetAsync();

            //convert data objects to DTO objects
            var data = _mapper.Map<List<DomainTypeDto>>(domainTypes);

            //return list of DTO objects
            _logger.LogInformation("Domain types where retrieved successfully");
            return data;
        }
    }
}
