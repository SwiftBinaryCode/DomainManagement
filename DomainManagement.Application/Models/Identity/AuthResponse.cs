using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainManagement.Application.Models.Identity
{
    // This class represents the response model after a successful authentication.
    // It contains properties to hold the user's information and the generated JWT token.
    public class AuthResponse
    {
        // The 'Id' property holds the unique identifier of the authenticated user.
        // This can be used to reference the user in the system.
        public string Id { get; set; }

        // The 'UserName' property holds the username of the authenticated user.
        // It provides a way to identify and display the user's name in the application.
        public string UserName { get; set; }

        // The 'Email' property holds the email address of the authenticated user,
        // serving as both a user identifier and a point of contact for the user.
        public string Email { get; set; }

        // The 'Token' property holds the JWT token generated upon successful authentication.
        // This token can be used for authorization and to maintain the user's session.
        public string Token { get; set; }
    }
}
