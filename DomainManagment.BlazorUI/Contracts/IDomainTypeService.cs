using DomainManagment.BlazorUI.Models.DomainTypes;
using DomainManagment.BlazorUI.Services.Base;

namespace DomainManagment.BlazorUI.Contracts
{
    // IDomainTypeService is an interface defining the contract for domain type services.
    public interface IDomainTypeService
    {
        // GetDomainTypes method is tasked with retrieving a list of all domain types.
        // It returns a Task containing a list of DomainTypeVM objects asynchronously.
        Task<List<DomainTypeVM>> GetDomainTypes();

        // GetDomainTypeDetails method is tasked with retrieving the details of a specific domain type identified by its ID.
        // It accepts an integer ID as a parameter and returns a Task containing a DomainTypeVM object asynchronously.
        Task<DomainTypeVM> GetDomainTypeDetails(int id);

        // CreateDomainType method is tasked with creating a new domain type.
        // It accepts a DomainTypeVM object as a parameter, containing the details of the domain type to be created.
        // It returns a Task containing a Response<Guid> object asynchronously, where Guid represents the ID of the newly created domain type.
        Task<Response<Guid>> CreateDomainType(DomainTypeVM domainType);

        // UpdateDomainType method is tasked with updating the details of an existing domain type identified by its ID.
        // It accepts an integer ID and a DomainTypeVM object as parameters, containing the updated details of the domain type.
        // It returns a Task containing a Response<Guid> object asynchronously, where Guid represents the ID of the updated domain type.
        Task<Response<Guid>> UpdateDomainType(int id, DomainTypeVM domainType);

        // DeleteDomainType method is tasked with deleting a specific domain type identified by its ID.
        // It accepts an integer ID as a parameter and returns a Task containing a Response<Guid> object asynchronously,
        // where Guid represents the ID of the deleted domain type.
        Task<Response<Guid>> DeleteDomainType(int id);
    }
}
