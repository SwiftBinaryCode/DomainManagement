using AutoMapper;
using DomainManagement.Application.Contracts.Logging;
using DomainManagement.Application.Contracts.Persistence;
using MediatR;

namespace DomainManagement.Application.Features.DomainType.Queries.GetAllDomainTypes
{
    // This class handles the processing of the GetDomainTypesQuery to retrieve domain types.
    public class GetDomainTypesQueryHandler : IRequestHandler<GetDomainTypesQuery, List<DomainTypeDto>>
    {
        // Declaration of dependencies: a mapper, domain type repository, and logger.
        private readonly IMapper _mapper;
        private readonly IDomainTypeRepository _domainTypeRepository;
        private readonly IAppLogger<GetDomainTypesQueryHandler> _logger;

        // Constructor to initialize the handler with its dependencies.
        public GetDomainTypesQueryHandler(IMapper mapper, IDomainTypeRepository domainTypeRepository, IAppLogger<GetDomainTypesQueryHandler> logger)
        {
            this._mapper = mapper;  // Initializes the AutoMapper instance for data mapping.
            this._domainTypeRepository = domainTypeRepository;  // Initializes the domain type repository for querying domain types.
            this._logger = logger;  // Initializes the logger for logging information and errors.
        }

        // This method handles the GetDomainTypesQuery asynchronously and returns a list of domain type DTOs.
        public async Task<List<DomainTypeDto>> Handle(GetDomainTypesQuery request, CancellationToken cancellationToken)
        {
            // Query the database to retrieve all domain types.
            var domainTypes = await _domainTypeRepository.GetAsync();

            // Use AutoMapper to convert the retrieved domain types into a list of DomainTypeDto objects.
            var data = _mapper.Map<List<DomainTypeDto>>(domainTypes);

            // Log information indicating the successful retrieval of domain types.
            _logger.LogInformation("Domain types were retrieved successfully");

            // Return the list of DomainTypeDto objects to the caller.
            return data;
        }
    }
}
