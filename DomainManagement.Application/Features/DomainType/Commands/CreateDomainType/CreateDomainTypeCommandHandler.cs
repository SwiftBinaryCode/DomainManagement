using AutoMapper;
using DomainManagement.Application.Contracts.Persistence;
using DomainManagement.Application.Exceptions;
using MediatR;

namespace DomainManagement.Application.Features.DomainType.Commands.CreateDomainType
{

    //This is a command handler for processing the CreateDomainTypeCommand
    public class CreateDomainTypeCommandHandler : IRequestHandler<CreateDomainTypeCommand, int>
    {
        //Imapper is an auotmapper instance used for maping objects
        // It's used to transform the CreateDomainTypeCommand request into a DomainType entity.
        private readonly IMapper _mapper;
        //A repository interface for handling domain type entities,
        //allowing the handler to interact with the underlying database or datastore.
        private readonly IDomainTypeRepository _domainTypeRepository;

        //Used to inject the dependiniceis needed to porcess the command
        public CreateDomainTypeCommandHandler(IMapper mapper, IDomainTypeRepository domainTypeRepository)
        {
            this._mapper = mapper;
            this._domainTypeRepository = domainTypeRepository;
        }
        public async Task<int> Handle(CreateDomainTypeCommand request, CancellationToken cancellationToken)
        {
            //Validate incoming data
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
