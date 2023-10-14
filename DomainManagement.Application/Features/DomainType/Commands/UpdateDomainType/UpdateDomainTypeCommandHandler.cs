using AutoMapper;
using DomainManagement.Application.Contracts.Logging;
using DomainManagement.Application.Contracts.Persistence;
using DomainManagement.Application.Exceptions;
using MediatR;

namespace DomainManagement.Application.Features.DomainType.Commands.UpdateDomainType
{
    public class UpdateDomainTypeCommandHandler : IRequestHandler<UpdateDomainTypeCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IDomainTypeRepository _domainTypeRepository;
        private readonly IAppLogger<UpdateDomainTypeCommandHandler> _logger;

        public UpdateDomainTypeCommandHandler(IMapper mapper, IDomainTypeRepository domainTypeRepository, IAppLogger<UpdateDomainTypeCommandHandler> logger)
        {
            this._mapper = mapper;
            this._domainTypeRepository = domainTypeRepository;
            this._logger = logger;
        }
        public async Task<Unit> Handle(UpdateDomainTypeCommand request, CancellationToken cancellationToken)
        {
            // Validate incoming data
            var validator = new UpdateDomainTypeCommandValidator(_domainTypeRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
            {
                _logger.LogWarning("Validation errors in update request for {0} - {1}", nameof(DomainType), request.Id);
                throw new BadRequestException("Invalid Domain type", validationResult);
            }
            //convert to domain entity object
            var domainTypeToUpdate = _mapper.Map<Domain.DomainType>(request);

            //add to database
            await _domainTypeRepository.UpdateAsync(domainTypeToUpdate);
            //return Unit value
            return Unit.Value;
        }
    }
}
