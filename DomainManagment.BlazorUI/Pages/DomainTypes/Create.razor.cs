using DomainManagment.BlazorUI.Contracts;
using DomainManagment.BlazorUI.Models.DomainTypes;
using global::Microsoft.AspNetCore.Components;

namespace DomainManagment.BlazorUI.Pages.DomainTypes
{
    public partial class Create
    {
        [Inject]
        NavigationManager _navManager { get; set; }
        [Inject]
        IDomainTypeService _client { get; set; }
        public string Message { get; private set; }

        DomainTypeVM domainType = new DomainTypeVM();
        async Task CreateDomainType()
        {
            var response = await _client.CreateDomainType(domainType);
            if (response.Success)
            {
                _navManager.NavigateTo("/domaintypes/");
            }
            Message = response.Message;
        }
    }
}