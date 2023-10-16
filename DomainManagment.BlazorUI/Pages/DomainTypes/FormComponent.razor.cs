using DomainManagment.BlazorUI.Models.DomainTypes;
using global::Microsoft.AspNetCore.Components;

namespace DomainManagment.BlazorUI.Pages.DomainTypes
{
    public partial class FormComponent
    {
        [Parameter] public bool Disabled { get; set; } = false;
        [Parameter] public DomainTypeVM DomainType { get; set; }
        [Parameter] public string ButtonText { get; set; } = "Save";
        [Parameter] public EventCallback OnValidSubmit { get; set; }
    }
}