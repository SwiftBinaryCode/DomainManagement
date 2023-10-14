using AutoMapper;
using DomainManagement.Application.Features.DomainType.Queries.GetAllDomainTypes;
using DomainManagement.Domain;

namespace DomainManagement.Application.MappingProfiles
{
    public class DomainTypeProfile : Profile
    {
        public DomainTypeProfile()
        {
            CreateMap<DomainTypeDto, DomainType>().ReverseMap();
            CreateMap<DomainType, DomainTypeDto>();
        }
    }
}
