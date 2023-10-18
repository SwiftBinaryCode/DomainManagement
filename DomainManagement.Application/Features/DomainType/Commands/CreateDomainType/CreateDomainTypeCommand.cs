using MediatR;

namespace DomainManagement.Application.Features.DomainType.Commands.CreateDomainType
{
    //Used to invoke the handler
    //implements the IRequest<int> interface, from the MediatR library for handling command and query messaging.
    //The <int> indicates that when this command is handled, it will return the ID of the newly created domain type.
    public class CreateDomainTypeCommand : IRequest<int>
    {
        public string DomainName { get; set; } = string.Empty;

        public string OwnerName { get; set; } = string.Empty;

        public string Ip { get; set; }
    }
}
