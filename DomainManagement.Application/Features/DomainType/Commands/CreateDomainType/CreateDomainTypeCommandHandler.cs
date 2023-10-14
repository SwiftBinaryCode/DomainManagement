using AutoMapper;
using DomainManagement.Application.Contracts.Persistence;
using DomainManagement.Application.Exceptions;
using MediatR;

namespace DomainManagement.Application.Features.DomainType.Commands.CreateDomainType
{
    public class CreateDomainTypeCommandHandler : IRequestHandler<CreateDomainTypeCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IDomainTypeRepository _domainTypeRepository;

        public CreateDomainTypeCommandHandler(IMapper mapper, IDomainTypeRepository domainTypeRepository)
        {
            this._mapper = mapper;
            this._domainTypeRepository = domainTypeRepository;
        }
        public async Task<int> Handle(CreateDomainTypeCommand request, CancellationToken cancellationToken)
        {
            //Validate incoming datal
            var validator = new CreateDomainTypeCommandValidator(_domainTypeRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid Domain type", validationResult);

            //convert to domain entity object
            var domainTypeToCreate = _mapper.Map<Domain.DomainType>(request);

            //add to database
            await _domainTypeRepository.CreateAsync(domainTypeToCreate);
            //return record id
            return domainTypeToCreate.Id;
        }
    }
}
