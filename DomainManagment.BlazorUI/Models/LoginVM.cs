using System.ComponentModel.DataAnnotations;

namespace DomainManagment.BlazorUI.Models
{
    // This class represents a ViewModel (VM) specifically designed for the login process.
    // A ViewModel in application architecture is often used to hold only the data and validation attributes 
    // required for the view layer, catering to user interface rendering and interactions.

    public class LoginVM
    {
        // This property holds the email address entered by the user during the login process. 
        // The [Required] attribute indicates that the email must be provided to successfully 
        // proceed with the login. If it's missing, a validation error will be triggered.
        [Required]
        public string Email { get; set; } = string.Empty;

        // This property holds the password entered by the user during the login process.
        // Just like the email, the password is marked as [Required], meaning it must be provided 
        // for the user to proceed with the login.
        [Required]
        public string Password { get; set; } = string.Empty;

    }

}
