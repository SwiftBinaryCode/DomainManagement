using System.ComponentModel.DataAnnotations;

namespace DomainManagment.BlazorUI.Models.DomainTypes
{
    public class DomainTypeVM
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Domain Name")]
        public string DomainName { get; set; } = string.Empty;

        [Required]
        public string OwnerName { get; set; } = string.Empty;

        [Required]
        public string Ip { get; set; } = string.Empty;

    }
}
