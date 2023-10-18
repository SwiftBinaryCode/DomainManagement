using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainManagement.Application.Models.Identity
{
    // This class represents the data model for user registration requests.
    // It contains properties to capture the necessary information required to register a new user.
    public class RegistrationRequest
    {
        // The 'FirstName' property holds the user's first name.
        // It is marked as required, meaning the user must provide a value for successful registration.
        [Required]
        public string FirstName { get; set; }

        // The 'LastName' property holds the user's last name.
        // Like the first name, this is also a required field.
        [Required]
        public string LastName { get; set; }

        // The 'Email' property holds the user's email address.
        // It's marked as required and is additionally validated to ensure it's in a valid email format.
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        // The 'UserName' property is used as a unique identifier for the user in the system.
        // It is required and must be at least 6 characters long.
        [Required]
        [MinLength(6)]
        public string UserName { get; set; }

        // The 'Password' property holds the user's password.
        // It is also required and must be at least 6 characters long for security reasons.
        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }
}
