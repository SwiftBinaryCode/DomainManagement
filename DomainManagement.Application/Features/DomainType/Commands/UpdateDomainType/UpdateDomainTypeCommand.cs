using MediatR;
namespace DomainManagement.Application.Features.DomainType.Commands.UpdateDomainType
{
    //The UpdateDomainTypeCommand class is a command designed to encapsulate the data needed to update a domain type in your system or application.
    //It is associated with the Command and Query Responsibility Segregation (CQRS) pattern and the MediatR library. 

    public class UpdateDomainTypeCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string DomainName { get; set; } = string.Empty;
        public string OwnerName { get; set; } = string.Empty;
        public string Ip { get; set; }
    }
}
