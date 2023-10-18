using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainManagement.Application.Features.DomainType.Queries.GetDomainTypeDetails
{
    // This record represents a query to retrieve the details of a specific domain type by its ID.
    public record GetDomainTypesDetailsQuery(int Id) : IRequest<DomainTypeDetailsDto>;
   
}
