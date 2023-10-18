namespace DomainManagement.Application.Models.Identity
{
    // This class represents the data model for authentication requests.
    // It contains properties to hold the user's email and password for authentication purposes.
    public class AuthRequest
    {
        // The 'Email' property is used to hold the user's email address, 
        // which is one of the credentials required for authentication.
        public string Email { get; set; }

        // The 'Password' property holds the user's password, 
        // which is the second credential required to authenticate the user.
        public string Password { get; set; }
    }
}
