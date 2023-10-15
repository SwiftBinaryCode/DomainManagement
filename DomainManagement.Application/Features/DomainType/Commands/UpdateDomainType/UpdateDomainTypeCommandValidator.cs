using DomainManagement.Application.Contracts.Persistence;
using FluentValidation;

namespace DomainManagement.Application.Features.DomainType.Commands.UpdateDomainType
{
    public class UpdateDomainTypeCommandValidator : AbstractValidator<UpdateDomainTypeCommand>
    {
        private readonly IDomainTypeRepository _domainTypeRepository;

        public UpdateDomainTypeCommandValidator(IDomainTypeRepository domainTypeRepository)
        {
            RuleFor(p => p.Id)
            .NotNull()
            .MustAsync(DomainTypeMustExist);

            RuleFor(p => p.DomainName)
               .NotEmpty().WithMessage("{PropertyName} is required")
               .NotNull()
               .MaximumLength(70).WithMessage("{PropertyName} must be fewer than 70 characters");


            RuleFor(q => q)
                .MustAsync(DomainTypeNameUnique)
                .WithMessage("Leave type already exists");


            this._domainTypeRepository = domainTypeRepository;


           
        }

        private async Task<bool> DomainTypeMustExist(int id, CancellationToken arg2)
        {
            var leaveType = await _domainTypeRepository.GetByIdAsync(id);
            return leaveType != null;
        }

        private async Task<bool> DomainTypeNameUnique(UpdateDomainTypeCommand command, CancellationToken token)
        {
            return await _domainTypeRepository.IsDomainTypeUnique(command.DomainName);
        }
    }
}
