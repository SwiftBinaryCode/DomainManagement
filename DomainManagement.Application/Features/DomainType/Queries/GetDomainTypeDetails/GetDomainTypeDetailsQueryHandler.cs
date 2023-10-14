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
    public class GetDomainTypeDetailsQueryHandler : IRequestHandler<GetDomainTypesDetailsQuery, DomainTypeDetailsDto>
    {
        private readonly IMapper _mapper;
        private readonly IDomainTypeRepository _domainTypeRepository;

        public GetDomainTypeDetailsQueryHandler(IMapper mapper, IDomainTypeRepository domainTypeRepository)
        {
            this._mapper = mapper;
            this._domainTypeRepository = domainTypeRepository;
        }
        public async Task<DomainTypeDetailsDto> Handle(GetDomainTypesDetailsQuery request, CancellationToken cancellationToken)
        {
            //query the database
            var domainType = await _domainTypeRepository.GetByIdAsync(request.Id);

            //verify that record exists
            if (domainType == null)
            {
                throw new NotFoundException(nameof(DomainType), request.Id);
            }

            //convert data objects to DTO objects
            var data = _mapper.Map<DomainTypeDetailsDto>(domainType);

            //return list of DTO objects
            return data;
        }
    }
}
