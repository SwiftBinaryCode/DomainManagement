using Blazored.LocalStorage;
using System.Net.Http.Headers;

namespace DomainManagment.BlazorUI.Handlers
{
    // The JwtAuthorizationMessageHandler class is responsible for adding JWT (JSON Web Token) authorization 
    // headers to outgoing HTTP requests. It inherits from the DelegatingHandler class, allowing it to process 
    // HTTP requests and responses.

    public class JwtAuthorizationMessageHandler : DelegatingHandler
    {
        // _localStorageService is used for accessing local storage where the JWT is stored.
        private readonly ILocalStorageService _localStorageService;

        // The constructor takes an ILocalStorageService instance, which will be used to retrieve 
        // the JWT from the client's local storage.
        public JwtAuthorizationMessageHandler(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }

        // This overridden method is called for every HTTP request that’s made. It’s where the JWT 
        // is added to the Authorization header of the outgoing HTTP request.
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // Retrieve the JWT from local storage.
            var token = await _localStorageService.GetItemAsync<string>("token");

            // If the token exists and is not null or empty, add it to the Authorization header of the request.
            if (!string.IsNullOrEmpty(token))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            // Pass the modified request (with the added Authorization header) along the chain of 
            // delegating handlers, until it reaches the innermost handler which sends the request 
            // to the server and returns the server’s response.
            return await base.SendAsync(request, cancellationToken);
        }
    }
}
