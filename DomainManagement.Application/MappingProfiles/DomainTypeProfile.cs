using AutoMapper;
using DomainManagement.Application.Features.DomainType.Commands.CreateDomainType;
using DomainManagement.Application.Features.DomainType.Commands.UpdateDomainType;
using DomainManagement.Application.Features.DomainType.Queries.GetAllDomainTypes;
using DomainManagement.Application.Features.DomainType.Queries.GetDomainTypeDetails;
using DomainManagement.Domain;

namespace DomainManagement.Application.MappingProfiles
{
    public class DomainTypeProfile : Profile
    {
        public DomainTypeProfile()
        {
            CreateMap<DomainTypeDto, DomainType>().ReverseMap();
            CreateMap<DomainType, DomainTypeDetailsDto>();
            CreateMap<CreateDomainTypeCommand, DomainType>();
            CreateMap<UpdateDomainTypeCommand, DomainType>();
        }
    }
}
