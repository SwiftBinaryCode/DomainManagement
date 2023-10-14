using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainManagement.Application.Features.DomainType.Commands.DeleteDomainType
{
    public class DeleteDomainTypeCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
