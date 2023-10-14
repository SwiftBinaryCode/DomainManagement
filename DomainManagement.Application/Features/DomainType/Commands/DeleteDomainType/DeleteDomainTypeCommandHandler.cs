using AutoMapper;
using DomainManagement.Application.Contracts.Persistence;
using DomainManagement.Application.Exceptions;
using DomainManagement.Application.Features.DomainType.Commands.UpdateDomainType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainManagement.Application.Features.DomainType.Commands.DeleteDomainType
{
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
                throw new NotFoundException(nameof(DomainType),request.Id);
            }

            //remove from database
            await _domainTypeRepository.DeleteAsync(domainTypeToDelete);

            //return Unit value
            return Unit.Value;
        }
    }
}
