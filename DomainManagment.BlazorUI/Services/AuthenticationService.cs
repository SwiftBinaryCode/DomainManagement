using Blazored.LocalStorage;
using DomainManagment.BlazorUI.Contracts;
using DomainManagment.BlazorUI.Providers;
using DomainManagment.BlazorUI.Services.Base;
using Microsoft.AspNetCore.Components.Authorization;

namespace DomainManagment.BlazorUI.Services
{
    // AuthenticationService class that implements IAuthenticationService and extends BaseHttpService.
    // It provides methods for authenticating and registering users.
    public class AuthenticationService : BaseHttpService, IAuthenticationService
    {
        // Instance of AuthenticationStateProvider to manage and interact with the authentication state.
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        // Constructor to initialize the AuthenticationService with necessary dependencies.
        public AuthenticationService(IClient client,
            ILocalStorageService localStorage,
            AuthenticationStateProvider authenticationStateProvider) : base(client, localStorage)
        {
            // Assigning the AuthenticationStateProvider instance to the _authenticationStateProvider field.
            _authenticationStateProvider = authenticationStateProvider;
        }

        // Asynchronous method to authenticate a user using their email and password.
        public async Task<bool> AuthenticateAsync(string email, string password)
        {
            try
            {
                // Creating an authentication request object with the provided email and password.
                AuthRequest authenticationRequest = new AuthRequest() { Email = email, Password = password };

                // Sending an authentication request to the API and getting the response.
                var authenticationResponse = await _client.LoginAsync(authenticationRequest);

                // Checking if the received token is not empty, indicating successful authentication.
                if (authenticationResponse.Token != string.Empty)
                {
                    // Storing the received token in the local storage.
                    await _localStorage.SetItemAsync("token", authenticationResponse.Token);

                    // Updating the authentication state to logged in.
                    await ((ApiAuthenticationStateProvider)_authenticationStateProvider).LoggedIn();

                    // Returning true to indicate successful authentication.
                    return true;
                }

                // Returning false to indicate failed authentication if the token is empty.
                return false;
            }
            catch (Exception)
            {
                // Handling exceptions and returning false to indicate failed authentication.
                return false;
            }
        }

        // Asynchronous method to log the user out.
        public async Task Logout()
        {
            // Updating the authentication state to logged out.
            await ((ApiAuthenticationStateProvider)_authenticationStateProvider).LoggedOut();
        }

        // Asynchronous method to register a new user with the provided details.
        public async Task<bool> RegisterAsync(string firstName, string lastName, string userName, string email, string password)
        {
            // Creating a registration request object with the provided user details.
            RegistrationRequest registrationRequest = new RegistrationRequest() { FirstName = firstName, LastName = lastName, Email = email, UserName = userName, Password = password };

            // Sending a registration request to the API and getting the response.
            var response = await _client.RegisterAsync(registrationRequest);

            // Checking if the UserId is not null or empty, indicating successful registration.
            if (!string.IsNullOrEmpty(response.UserId))
            {
                // Returning true to indicate successful registration.
                return true;
            }

            // Returning false to indicate failed registration if the UserId is null or empty.
            return false;
        }
    }
}
