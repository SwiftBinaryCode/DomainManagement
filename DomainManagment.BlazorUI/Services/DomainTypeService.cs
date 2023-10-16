using AutoMapper;
using Blazored.LocalStorage;
using DomainManagment.BlazorUI.Contracts;
using DomainManagment.BlazorUI.Models.DomainTypes;
using DomainManagment.BlazorUI.Services.Base;

namespace DomainManagment.BlazorUI.Services
{
    public class DomainTypeService : BaseHttpService, IDomainTypeService
    {
        private readonly IMapper _mapper;

        public DomainTypeService(IClient client, IMapper mapper, ILocalStorageService localStorageService) : base(client, localStorageService)
        {
            this._mapper = mapper;
        }

        public async Task<Response<Guid>> CreateDomainType(DomainTypeVM domainType)
        {
        
            try
            {
                await AddBearerToken();
                var createDomainTypeCommand = _mapper.Map<CreateDomainTypeCommand>(domainType);
                await _client.DomainTypePOSTAsync(createDomainTypeCommand);
                return new Response<Guid>()
                {
                    Success = true,
                };
            }
            catch (ApiException ex)
            {

                return ConvertApiExceptions<Guid>(ex);
            }
        }

        public async Task<Response<Guid>> DeleteDomainType(int id)
        {
            try
            {
                await AddBearerToken();
                await _client.DomainTypeDELETEAsync(id);
                return new Response<Guid>() { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }

        public async Task<DomainTypeVM> GetDomainTypeDetails(int id)
        {
            await AddBearerToken();
            var domainType = await _client.DomainTypeGETAsync(id);
            return _mapper.Map<DomainTypeVM>(domainType);
        }

        public async Task<List<DomainTypeVM>> GetDomainTypes()
        {
            await AddBearerToken();
            var domainTypes = await _client.DomainTypeAllAsync();
           return _mapper.Map<List<DomainTypeVM>>(domainTypes);
        }

        public async Task<Response<Guid>> UpdateDomainType(int id, DomainTypeVM domainType)
        {
            try
            {
                await AddBearerToken();
                var updateDomainTypeCommand = _mapper.Map<UpdateDomainTypeCommand>(domainType);
                await _client.DomainTypePUTAsync(id.ToString(), updateDomainTypeCommand);
                return new Response<Guid>()
                {
                    Success = true,
                };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }
    }
}
