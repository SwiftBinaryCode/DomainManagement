using AutoMapper;
using DomainManagement.Application.Contracts.Persistence;
using DomainManagement.Application.Exceptions;
using DomainManagement.Application.Features.DomainType.Queries.GetAllDomainTypes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainManagement.Application.Features.DomainType.Queries.GetDomainTypeDetails
{
    // This class handles the processing of GetDomainTypesDetailsQuery to retrieve specific domain type details.
    public class GetDomainTypeDetailsQueryHandler : IRequestHandler<GetDomainTypesDetailsQuery, DomainTypeDetailsDto>
    {
        // Declaration of dependencies, including a mapper for object transformations, 
        // and a domain type repository for data access.
        private readonly IMapper _mapper;
        private readonly IDomainTypeRepository _domainTypeRepository;

        // Constructor that initializes the handler with its required dependencies.
        public GetDomainTypeDetailsQueryHandler(IMapper mapper, IDomainTypeRepository domainTypeRepository)
        {
            this._mapper = mapper; // Initializes the AutoMapper instance for transforming domain entities to DTOs.
            this._domainTypeRepository = domainTypeRepository; // Initializes the repository for data retrieval.
        }

        // This method handles the GetDomainTypesDetailsQuery asynchronously and returns details of a specific domain type.
        public async Task<DomainTypeDetailsDto> Handle(GetDomainTypesDetailsQuery request, CancellationToken cancellationToken)
        {
            // Query the database to retrieve the domain type based on the ID provided in the request.
            var domainType = await _domainTypeRepository.GetByIdAsync(request.Id);

            // Check if the domain type is not found in the database, and if so, throw a NotFoundException.
            if (domainType == null)
            {
                throw new NotFoundException(nameof(DomainType), request.Id);
            }

            // Use AutoMapper to convert the retrieved domain type into a DomainTypeDetailsDto object.
            var data = _mapper.Map<DomainTypeDetailsDto>(domainType);

            // Return the DomainTypeDetailsDto object containing the detailed information of the retrieved domain type.
            return data;
        }
    }
}
