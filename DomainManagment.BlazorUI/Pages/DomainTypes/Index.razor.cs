using Blazored.Toast.Services;
using DomainManagment.BlazorUI.Contracts;
using DomainManagment.BlazorUI.Models.DomainTypes;
using Microsoft.AspNetCore.Components;

namespace DomainManagment.BlazorUI.Pages.DomainTypes
{
    public partial class Index
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IDomainTypeService DomainTypeService { get; set; }

        [Inject]
        IToastService toastService { get; set; }

        public List<DomainTypeVM> DomainTypes { get; private set; }
        public string Message { get; set; } = string.Empty;

        protected void CreateDomainType()
        {
            NavigationManager.NavigateTo("/domaintypes/create/");
        }

        protected void EditDomainType(int id)
        {
            NavigationManager.NavigateTo($"/domaintypes/edit/{id}");
        }

        protected void DetailsDomainType(int id)
        {
            NavigationManager.NavigateTo($"/domaintypes/details/{id}");
        }

        protected async Task DeleteDomainType(int id)
        {
            var response = await DomainTypeService.DeleteDomainType(id);
            if (response.Success)
            {
                toastService.ShowSuccess("Domain deleted Successfully");
                await OnInitializedAsync();
            }
            else
            {
                Message = response.Message;
            }
        }

        protected override async Task OnInitializedAsync()
        {
            
            DomainTypes = await DomainTypeService.GetDomainTypes();
        }
    }
}