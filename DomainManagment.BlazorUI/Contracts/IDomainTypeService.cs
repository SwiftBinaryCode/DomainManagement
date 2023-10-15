using DomainManagment.BlazorUI.Models.DomainTypes;
using DomainManagment.BlazorUI.Services.Base;

namespace DomainManagment.BlazorUI.Contracts
{
    public interface IDomainTypeService
    {
        Task<List<DomainTypeVM>> GetDomainTypes();
        Task<DomainTypeVM> GetDomainTypeDetails(int id);

        Task<Response<Guid>> CreateDomainType(DomainTypeVM domainType);
        Task<Response<Guid>> UpdateDomainType(int id, DomainTypeVM domainType);
        Task<Response<Guid>> DeleteDomainType(int id);
    }
}
