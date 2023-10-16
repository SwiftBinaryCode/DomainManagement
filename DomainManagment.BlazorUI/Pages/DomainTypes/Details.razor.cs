using DomainManagment.BlazorUI.Contracts;
using DomainManagment.BlazorUI.Models.DomainTypes;
using global::Microsoft.AspNetCore.Components;

namespace DomainManagment.BlazorUI.Pages.DomainTypes
{
    public partial class Details
    {
        [Inject]
        IDomainTypeService _client { get; set; }

        [Parameter]
        public int id { get; set; }

        DomainTypeVM domainType = new DomainTypeVM();

        protected async override Task OnParametersSetAsync()
        {
            domainType = await _client.GetDomainTypeDetails(id);
        }
    }
}