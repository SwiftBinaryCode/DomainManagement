using global::System;
using global::System.Collections.Generic;
using global::System.Linq;
using global::System.Threading.Tasks;
using global::Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using Microsoft.JSInterop;
using DomainManagment.BlazorUI;
using DomainManagment.BlazorUI.Shared;
using DomainManagment.BlazorUI.Models;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Authorization;
using DomainManagment.BlazorUI.Contracts;
using DomainManagment.BlazorUI.Models.DomainTypes;

namespace DomainManagment.BlazorUI.Pages.DomainTypes
{
    public partial class Edit
    {
        [Inject]
        IDomainTypeService _client { get; set; }

        [Inject]
        NavigationManager _navManager { get; set; }

        [Parameter]
        public int id { get; set; }
        public string Message { get; private set; }

        DomainTypeVM domainType = new DomainTypeVM();

        protected async override Task OnParametersSetAsync()
        {
            domainType = await _client.GetDomainTypeDetails(id);
        }

        async Task EditDomainType()
        {
            var response = await _client.UpdateDomainType(id, domainType);
            if (response.Success)
            {
                _navManager.NavigateTo("/domaintypes/");
            }
            Message = response.Message;
        }
    }
}