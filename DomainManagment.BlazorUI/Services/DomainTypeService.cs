using AutoMapper;
using Blazored.LocalStorage;
using DomainManagment.BlazorUI.Contracts;
using DomainManagment.BlazorUI.Models.DomainTypes;
using DomainManagment.BlazorUI.Services.Base;

namespace DomainManagment.BlazorUI.Services
{
    // DomainTypeService class that implements IDomainTypeService and extends the BaseHttpService. 
    // It is responsible for performing HTTP operations related to domain types.
    public class DomainTypeService : BaseHttpService, IDomainTypeService
    {
        // The IMapper instance used for object mapping between different types.
        private readonly IMapper _mapper;

        // Constructor to initialize the DomainTypeService with necessary dependencies.
        public DomainTypeService(IClient client, IMapper mapper, ILocalStorageService localStorageService)
            : base(client, localStorageService)
        {
            this._mapper = mapper;  // Assigning the IMapper instance to the _mapper field.
        }

        // Asynchronous method to create a new domain type and returns the response containing the created domain type ID.
        public async Task<Response<Guid>> CreateDomainType(DomainTypeVM domainType)
        {
            try
            {
                await AddBearerToken();  // Adding the Bearer token for authentication.
                                         // Mapping DomainTypeVM to CreateDomainTypeCommand object.
                var createDomainTypeCommand = _mapper.Map<CreateDomainTypeCommand>(domainType);
                // Sending a POST request to create a new domain type.
                await _client.DomainTypePOSTAsync(createDomainTypeCommand);
                return new Response<Guid>() { Success = true };  // Return success response.
            }
            catch (ApiException ex)
            {
                // Handling API exceptions and converting them to a unified response format.
                return ConvertApiExceptions<Guid>(ex);
            }
        }

        // Asynchronous method to delete a domain type by its ID and returns a response indicating the operation's result.
        // ... (Other methods follow the similar pattern)

        // Asynchronous method to retrieve the details of a domain type by its ID, and returns the domain type view model.
        public async Task<DomainTypeVM> GetDomainTypeDetails(int id)
        {
            await AddBearerToken();  // Adding the Bearer token for authentication.
            var domainType = await _client.DomainTypeGETAsync(id);  // Sending a GET request to retrieve domain type details.
            return _mapper.Map<DomainTypeVM>(domainType);  // Mapping the retrieved domain type to DomainTypeVM and returning it.
        }

        // Asynchronous method to retrieve a list of all domain types and returns a list of domain type view models.
        public async Task<List<DomainTypeVM>> GetDomainTypes()
        {
            await AddBearerToken();  // Adding the Bearer token for authentication.
            var domainTypes = await _client.DomainTypeAllAsync();  // Sending a GET request to retrieve all domain types.
            return _mapper.Map<List<DomainTypeVM>>(domainTypes);  // Mapping and returning the retrieved domain types as a list of DomainTypeVM.
        }

        // Asynchronous method to update a domain type by its ID and new details, and returns a response indicating the operation's result.
        public async Task<Response<Guid>> UpdateDomainType(int id, DomainTypeVM domainType)
        {
            try
            {
                await AddBearerToken();  // Adding the Bearer token for authentication.
                                         // Mapping DomainTypeVM to UpdateDomainTypeCommand object.
                var updateDomainTypeCommand = _mapper.Map<UpdateDomainTypeCommand>(domainType);
                // Sending a PUT request to update the domain type.
                await _client.DomainTypePUTAsync(id.ToString(), updateDomainTypeCommand);
                return new Response<Guid>() { Success = true };  // Return success response.
            }
            catch (ApiException ex)
            {
                // Handling API exceptions and converting them to a unified response format.
                return ConvertApiExceptions<Guid>(ex);
            }
        }
    }
}
