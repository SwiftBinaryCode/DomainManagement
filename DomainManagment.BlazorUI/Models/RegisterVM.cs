using System.ComponentModel.DataAnnotations;

namespace DomainManagment.BlazorUI.Models
{
    // This class serves as a ViewModel (VM) to handle user registration data.
    // It captures user details necessary for the registration process.

    public class RegisterVM
    {
        // The [Required] attribute specifies that a value for the FirstName property is mandatory for the registration process.
        // The user is required to enter their first name in the registration form.
        [Required]
        public string FirstName { get; set; } = string.Empty;

        // LastName property captures the last name of the user. It is also a required field,
        // meaning the user cannot proceed with registration without providing their last name.
        [Required]
        public string LastName { get; set; } = string.Empty;

        // Email property is used to capture the user's email address. The email address is essential
        // not only for communication but often as a unique identifier for the user.
        [Required]
        public string Email { get; set; } = string.Empty;

        // UserName property is for capturing the username. In many systems, the username 
        // is a unique identifier for a user, used for logging into the system.
        [Required]
        public string UserName { get; set; } = string.Empty;

        // Password property holds the user's password. It is a required field as a user must 
        // have a password to secure their account.
        [Required]
        public string Password { get; set; } = string.Empty;

    }
}
