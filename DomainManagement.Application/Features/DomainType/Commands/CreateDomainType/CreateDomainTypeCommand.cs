using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainManagement.Application.Features.DomainType.Commands.CreateDomainType
{
    //Used to invoke the handler
    public class CreateDomainTypeCommand : IRequest<int>
    {
        public string DomainName { get; set; } = string.Empty;

        public string OwnerName { get; set; } = string.Empty;

        public int Ip { get; set; }
    }
}
