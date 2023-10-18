using System.ComponentModel.DataAnnotations;

namespace DomainManagment.BlazorUI.Models.DomainTypes
{
    public class DomainTypeVM
    {
        // This property holds the unique identifier for each DomainType.
        public int Id { get; set; }

        // This property represents the name of the domain. It is a required field, meaning that the user 
        // must provide a value for it when creating or editing a DomainType. The Display attribute 
        // changes the label of the field in the view to "Domain Name".
        [Required]
        [Display(Name = "Domain Name")]
        public string DomainName { get; set; } = string.Empty;

        // This property holds the name of the domain's owner. It is a required field, ensuring that every 
        // DomainType has an associated owner. The default value is an empty string to avoid null reference issues.
        [Required]
        public string OwnerName { get; set; } = string.Empty;

        // This property holds the IP address associated with the domain. It's also required, ensuring 
        // that every DomainType has an associated IP address. The default value is an empty string to avoid null issues.
        [Required]
        public string Ip { get; set; } = string.Empty;

    }

}
