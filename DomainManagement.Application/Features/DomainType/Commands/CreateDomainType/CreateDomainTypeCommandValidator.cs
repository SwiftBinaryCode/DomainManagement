using DomainManagement.Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainManagement.Application.Features.DomainType.Commands.CreateDomainType
{
    public class CreateDomainTypeCommandValidator : AbstractValidator<CreateDomainTypeCommand>
    {
        private readonly IDomainTypeRepository _domainTypeRepository;

        public CreateDomainTypeCommandValidator(IDomainTypeRepository domainTypeRepository)
        {
            RuleFor(p => p.DomainName)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(70).WithMessage("{PropertyName} must be fewer than 70 characters");

            RuleFor(q => q)
                .MustAsync(LeaveTypeNameUnique)
                .WithMessage("Leave type already exists");


            this._domainTypeRepository = domainTypeRepository;
        }

        private Task<bool> LeaveTypeNameUnique(CreateDomainTypeCommand command, CancellationToken token)
        {
            return _domainTypeRepository.IsLeaveTypeUnique(command.DomainName);
        }
    }
}
