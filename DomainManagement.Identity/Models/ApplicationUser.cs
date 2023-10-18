

using Microsoft.AspNetCore.Identity;

namespace DomainManagement.Identity.Models
{
    // This class extends the built-in IdentityUser class to include additional properties specific to the application's requirements.
    // It encapsulates attributes of a user that are beyond the default properties provided by IdentityUser.
    public class ApplicationUser : IdentityUser
    {
        // The 'FirstName' property is used to store the first name of the user. 
        // This extends the user profile information, making the user management and identification more detailed.
        public string FirstName { get; set; }

        // The 'LastName' property holds the user's last name. 
        // It complements the 'FirstName' property to provide complete name information for each user.
        public string LastName { get; set; }
    }
}
