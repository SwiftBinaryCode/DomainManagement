using DomainManagement.Application.Contracts.Persistence;
using DomainManagement.Application.Exceptions;
using MediatR;

namespace DomainManagement.Application.Features.DomainType.Commands.DeleteDomainType
{
    /*The DeleteDomainTypeCommandHandler class is a part of the implementation of the CQRS (Command Query Responsibility Segregation) pattern, used in combination with the MediatR library. 
     * It's a command handler responsible for processing the DeleteDomainTypeCommand.*/
    public class DeleteDomainTypeCommandHandler : IRequestHandler<DeleteDomainTypeCommand, Unit>
    {

        private readonly IDomainTypeRepository _domainTypeRepository;

        public DeleteDomainTypeCommandHandler(IDomainTypeRepository domainTypeRepository)
        {

            this._domainTypeRepository = domainTypeRepository;
        }
        public async Task<Unit> Handle(DeleteDomainTypeCommand request, CancellationToken cancellationToken)
        {

            //retrieve domain entity object
            var domainTypeToDelete = await _domainTypeRepository.GetByIdAsync(request.Id);

            //verify that record exists
            if (domainTypeToDelete == null)
            {
                throw new NotFoundException(nameof(DomainType), request.Id);
            }

            //remove from database
            await _domainTypeRepository.DeleteAsync(domainTypeToDelete);

            //return Unit value
            return Unit.Value;
        }
    }

}

/*DeleteDomainTypeCommand is issued, ensuring efficient handling, verification, and execution of the deletion operation.*/

