using AutoMapper;
using DomainManagment.BlazorUI.Models.DomainTypes;
using DomainManagment.BlazorUI.Services.Base;

namespace DomainManagment.BlazorUI.MappingProfiles
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<DomainTypeDto, DomainTypeVM>().ReverseMap();
            CreateMap<CreateDomainTypeCommand, DomainTypeVM>().ReverseMap();
            CreateMap<UpdateDomainTypeCommand, DomainTypeVM>().ReverseMap();
        }
    }
}
