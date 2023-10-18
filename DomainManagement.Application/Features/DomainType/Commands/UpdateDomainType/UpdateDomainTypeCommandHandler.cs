using AutoMapper;
using DomainManagement.Application.Contracts.Logging;
using DomainManagement.Application.Contracts.Persistence;
using DomainManagement.Application.Exceptions;
using MediatR;

namespace DomainManagement.Application.Features.DomainType.Commands.UpdateDomainType
{
    // This class handles the processing of the UpdateDomainTypeCommand.
    public class UpdateDomainTypeCommandHandler : IRequestHandler<UpdateDomainTypeCommand, Unit>
    {
        // Declaration of dependencies that will be injected into the handler.
        private readonly IMapper _mapper;
        private readonly IDomainTypeRepository _domainTypeRepository;
        private readonly IAppLogger<UpdateDomainTypeCommandHandler> _logger;

        // Constructor to initialize the handler with its dependencies.
        public UpdateDomainTypeCommandHandler(IMapper mapper, IDomainTypeRepository domainTypeRepository, IAppLogger<UpdateDomainTypeCommandHandler> logger)
        {
            this._mapper = mapper;  // Initializes the AutoMapper instance used for data mapping.
            this._domainTypeRepository = domainTypeRepository;  // Initializes the domain type repository for data operations.
            this._logger = logger;  // Initializes the logger for logging information and errors.
        }

        // This method handles the UpdateDomainTypeCommand asynchronously.
        public async Task<Unit> Handle(UpdateDomainTypeCommand request, CancellationToken cancellationToken)
        {
            // Validate the incoming update request using a custom validator.
            var validator = new UpdateDomainTypeCommandValidator(_domainTypeRepository);
            var validationResult = await validator.ValidateAsync(request);

            // If there are validation errors, log a warning and throw an exception with detailed error information.
            if (validationResult.Errors.Any())
            {
                _logger.LogWarning("Validation errors in update request for {0} - {1}", nameof(DomainType), request.Id);
                throw new BadRequestException("Invalid Domain type", validationResult);
            }

            // Map the incoming request data to the DomainType entity for updating the database.
            var domainTypeToUpdate = _mapper.Map<Domain.DomainType>(request);

            // Perform the update operation in the database asynchronously.
            await _domainTypeRepository.UpdateAsync(domainTypeToUpdate);

            // Return a Unit value indicating that the operation has completed successfully without a specific return value.
            return Unit.Value;
        }
    }
}
