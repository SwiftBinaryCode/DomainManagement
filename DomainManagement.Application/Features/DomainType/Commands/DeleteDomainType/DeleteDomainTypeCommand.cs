using MediatR;

namespace DomainManagement.Application.Features.DomainType.Commands.DeleteDomainType
{
    //This DeleteDomainTypeCommand class is a simple C# class used within the context of the MediatR library and the Command and Query Responsibility Segregation (CQRS) pattern.
    //It represents a command to delete a domain type from your system or application.
    public class DeleteDomainTypeCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
