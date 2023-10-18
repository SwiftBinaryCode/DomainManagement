using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace DomainManagment.BlazorUI.Providers
{
    // The ApiAuthenticationStateProvider class is an implementation of AuthenticationStateProvider, 
    // which is used to determine the authentication state of the user in a Blazor application.
    public class ApiAuthenticationStateProvider : AuthenticationStateProvider
    {
        // Fields to store instances of the local storage service and JWT security token handler.
        private readonly ILocalStorageService localStorage;
        private readonly JwtSecurityTokenHandler jwtSecurityTokenHandler;

        // The constructor accepts an instance of ILocalStorageService and initializes the fields.
        public ApiAuthenticationStateProvider(ILocalStorageService localStorage)
        {
            this.localStorage = localStorage;
            jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        }

        // An override of the GetAuthenticationStateAsync method to get the current authentication state of the user.
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            // Creates an unauthenticated user by default.
            var user = new ClaimsPrincipal(new ClaimsIdentity());

            // Checks if a token is present in local storage.
            var isTokenPresent = await localStorage.ContainKeyAsync("token");
            if (isTokenPresent == false)
            {
                return new AuthenticationState(user);
            }

            // Retrieves the saved token from local storage.
            var savedToken = await localStorage.GetItemAsync<string>("token");

            // Reads the JWT token content.
            var tokenContent = jwtSecurityTokenHandler.ReadJwtToken(savedToken);

            // Checks if the token is expired.
            if (tokenContent.ValidTo < DateTime.UtcNow)
            {
                // Removes the expired token from local storage and returns an unauthenticated user.
                await localStorage.RemoveItemAsync("token");
                return new AuthenticationState(user);
            }

            // Retrieves claims from the token and creates an authenticated user.
            var claims = await GetClaims();
            user = new ClaimsPrincipal(new ClaimsIdentity(claims, "jwt"));

            // Returns the authenticated user.
            return new AuthenticationState(user);
        }

        // Method to be called when the user is successfully logged in.
        public async Task LoggedIn()
        {
            // Retrieves the claims from the token and creates an authenticated user.
            var claims = await GetClaims();
            var user = new ClaimsPrincipal(new ClaimsIdentity(claims, "jwt"));

            // Notifies the system of the change in authentication state.
            var authState = Task.FromResult(new AuthenticationState(user));
            NotifyAuthenticationStateChanged(authState);
        }

        // Method to be called when the user logs out.
        public async Task LoggedOut()
        {
            // Removes the token from local storage and creates an unauthenticated user.
            await localStorage.RemoveItemAsync("token");
            var nobody = new ClaimsPrincipal(new ClaimsIdentity());

            // Notifies the system of the change in authentication state.
            var authState = Task.FromResult(new AuthenticationState(nobody));
            NotifyAuthenticationStateChanged(authState);
        }

        // A private method to get the claims from the stored JWT token.
        private async Task<List<Claim>> GetClaims()
        {
            // Retrieves the token from local storage and reads its content.
            var savedToken = await localStorage.GetItemAsync<string>("token");
            var tokenContent = jwtSecurityTokenHandler.ReadJwtToken(savedToken);

            // Retrieves the claims and adds the username as a claim.
            var claims = tokenContent.Claims.ToList();
            claims.Add(new Claim(ClaimTypes.Name, tokenContent.Subject));

            return claims;
        }
    }
}
