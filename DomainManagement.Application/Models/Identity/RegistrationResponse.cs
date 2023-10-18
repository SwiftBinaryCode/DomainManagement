namespace DomainManagement.Application.Models.Identity
{
    // This class represents the response model after a successful user registration.
    // It contains a property to hold the unique identifier of the newly registered user.
    public class RegistrationResponse
    {
        // The 'UserId' property holds the unique identifier assigned to the user upon successful registration.
        // This ID can be used for user identification and retrieval purposes in the system.
        public string UserId { get; set; }
    }
}
