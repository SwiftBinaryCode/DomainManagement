using AutoMapper;
using DomainManagment.BlazorUI.Models.DomainTypes;
using DomainManagment.BlazorUI.Services.Base;

namespace DomainManagment.BlazorUI.MappingProfiles
{
    public class MappingConfig : Profile
    {
        // The constructor is where you set up the mapping configurations.
        public MappingConfig()
        {
            // This line sets up a bidirectional mapping between DomainTypeDto and DomainTypeVM.
            // The ReverseMap method is used to map not only DomainTypeDto to DomainTypeVM but also 
            // DomainTypeVM back to DomainTypeDto.
            CreateMap<DomainTypeDto, DomainTypeVM>().ReverseMap();

            // This line is mapping CreateDomainTypeCommand to DomainTypeVM and vice versa. 
            // It means you can easily convert an object of type CreateDomainTypeCommand to DomainTypeVM 
            // and the other way around without manually setting each property.
            CreateMap<CreateDomainTypeCommand, DomainTypeVM>().ReverseMap();

            // Similar to above, this is mapping UpdateDomainTypeCommand to DomainTypeVM and vice versa.
            CreateMap<UpdateDomainTypeCommand, DomainTypeVM>().ReverseMap();
        }

    }
