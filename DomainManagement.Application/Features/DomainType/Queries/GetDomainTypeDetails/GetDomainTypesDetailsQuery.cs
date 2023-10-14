using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainManagement.Application.Features.DomainType.Queries.GetDomainTypeDetails
{
    public record GetDomainTypesDetailsQuery(int Id) : IRequest<DomainTypeDetailsDto>;
   
}
