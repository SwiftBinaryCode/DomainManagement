using AutoMapper;
using DomainManagement.Application.Features.DomainType.Commands.CreateDomainType;
using DomainManagement.Application.Features.DomainType.Commands.UpdateDomainType;
using DomainManagement.Application.Features.DomainType.Queries.GetAllDomainTypes;
using DomainManagement.Application.Features.DomainType.Queries.GetDomainTypeDetails;
using DomainManagement.Domain;

namespace DomainManagement.Application.MappingProfiles
{
    // This class is used for configuring the mapping profiles for AutoMapper,
    // facilitating the transformation between different object types in the application.
    public class DomainTypeProfile : Profile
    {
        // Constructor where the mapping configurations are defined.
        public DomainTypeProfile()
        {
            // Configures a bidirectional mapping between DomainTypeDto and DomainType.
            // This allows for easy conversion between these two types in both directions.
            CreateMap<DomainTypeDto, DomainType>().ReverseMap();

            // Configures a mapping from the DomainType entity to the DomainTypeDetailsDto.
            // This is used when transforming a DomainType entity to its detailed DTO representation.
            CreateMap<DomainType, DomainTypeDetailsDto>();

            // Configures a mapping from the CreateDomainTypeCommand to the DomainType entity.
            // This is used for creating a new DomainType entity from the command object.
            CreateMap<CreateDomainTypeCommand, DomainType>();

            // Configures a mapping from the UpdateDomainTypeCommand to the DomainType entity.
            // This is used for updating an existing DomainType entity from the command object.
            CreateMap<UpdateDomainTypeCommand, DomainType>();
        }
    }
}
