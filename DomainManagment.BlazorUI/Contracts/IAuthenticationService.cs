namespace DomainManagment.BlazorUI.Contracts
{
    // IAuthenticationService is an interface defining the contract for authentication services.
    public interface IAuthenticationService
    {
        // AuthenticateAsync method is tasked with authenticating a user given their email and password.
        // It returns a boolean value indicating the success or failure of the authentication process.
        Task<bool> AuthenticateAsync(string email, string password);

        // RegisterAsync method is tasked with registering a new user given their first name, last name, username, email, and password.
        // It returns a boolean value indicating the success or failure of the registration process.
        Task<bool> RegisterAsync(string firstName, string lastName, string userName, string email, string password);

        // Logout method is tasked with logging out the currently authenticated user.
        // It doesn’t return a value, indicating it’s a void operation but encapsulated in a Task for asynchronous operation.
        Task Logout();
    }
}
