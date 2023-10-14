using MediatR;

namespace DomainManagement.Application.Features.DomainType.Queries.GetAllDomainTypes
{
    public record GetDomainTypesQuery : IRequest<List<DomainTypeDto>>;
   
}
