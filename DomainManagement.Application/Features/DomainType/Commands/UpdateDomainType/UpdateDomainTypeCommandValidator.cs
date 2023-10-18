using DomainManagement.Application.Contracts.Persistence;
using FluentValidation;

namespace DomainManagement.Application.Features.DomainType.Commands.UpdateDomainType
{
    public class UpdateDomainTypeCommandValidator : AbstractValidator<UpdateDomainTypeCommand>
    {
        // Declaration of the repository that will be used for data validation.
        private readonly IDomainTypeRepository _domainTypeRepository;

        // Constructor to initialize the validator with the necessary repository for domain type validation.
        public UpdateDomainTypeCommandValidator(IDomainTypeRepository domainTypeRepository)
        {
            // Rule to validate that the ID is not null and the domain type exists in the database.
            RuleFor(p => p.Id)
                .NotNull()  // Ensures the ID is not null before proceeding to the next validation step.
                .MustAsync(DomainTypeMustExist);  // Asynchronously checks if the domain type with the provided ID exists.

            // Rule to validate the DomainName property.
            RuleFor(p => p.DomainName)
                .NotEmpty().WithMessage("{PropertyName} is required")  // Ensures that DomainName is not empty and provides a custom error message if the validation fails.
                .NotNull()  // Ensures DomainName is not null.
                .MaximumLength(70).WithMessage("{PropertyName} must be fewer than 70 characters");  // Restricts the length of DomainName to be fewer than 70 characters with a custom error message.

            // Rule to ensure that the domain type name is unique in the system.
            RuleFor(q => q)
                .MustAsync(DomainTypeNameUnique)  // Asynchronously checks if the domain type name is unique.
                .WithMessage("Domain type already exists");  // Provides a custom error message if the domain type name already exists.

            // Initializes the domain type repository to be used for validation.
            this._domainTypeRepository = domainTypeRepository;
        }

        // Asynchronous method to validate if the domain type exists in the database.
        private async Task<bool> DomainTypeMustExist(int id, CancellationToken arg2)
        {
            // Retrieves the domain type from the repository using the provided ID.
            var leaveType = await _domainTypeRepository.GetByIdAsync(id);

            // Returns true if the domain type is found, otherwise returns false.
            return leaveType != null;
        }

        // Asynchronous method to validate if the domain type name is unique.
        private async Task<bool> DomainTypeNameUnique(UpdateDomainTypeCommand command, CancellationToken token)
        {
            // Calls the repository method to check if the domain type name is unique and returns the result.
            return await _domainTypeRepository.IsDomainTypeUnique(command.DomainName);
        }
    }
}
