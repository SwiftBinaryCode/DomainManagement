using AutoMapper;
using DomainManagement.Application.Contracts.Persistence;
using MediatR;

namespace DomainManagement.Application.Features.DomainType.Commands.UpdateDomainType
{
    public class UpdateDomainTypeCommandHandler : IRequestHandler<UpdateDomainTypeCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IDomainTypeRepository _domainTypeRepository;

        public UpdateDomainTypeCommandHandler(IMapper mapper, IDomainTypeRepository domainTypeRepository)
        {
            this._mapper = mapper;
            this._domainTypeRepository = domainTypeRepository;
        }
        public async Task<Unit> Handle(UpdateDomainTypeCommand request, CancellationToken cancellationToken)
        {
            //Validate incoming data

            //convert to domain entity object
            var domainTypeToUpdate = _mapper.Map<Domain.DomainType>(request);

            //add to database
            await _domainTypeRepository.UpdateAsync(domainTypeToUpdate);
            //return Unit value
            return Unit.Value;
        }
    }
}
