using Blazored.LocalStorage;
using System.Net.Http.Headers;

namespace DomainManagment.BlazorUI.Services.Base
{
    // The BaseHttpService class is meant to serve as a foundational class for other HTTP service classes.
    // It encapsulates common functionalities that will be shared across derived service classes.
    public class BaseHttpService
    {
        // Protected field that holds the instance of the IClient interface.
        // This interface abstracts the operations of the HttpClient used to make HTTP requests.
        protected IClient _client;

        // A protected readonly field to hold an instance of the ILocalStorageService interface.
        // This service provides methods to interact with the browser's local storage.
        protected readonly ILocalStorageService _localStorage;

        // Constructor that takes instances of IClient and ILocalStorageService as parameters.
        // It initializes the corresponding fields with the provided instances.
        public BaseHttpService(IClient client, ILocalStorageService localStorage)
        {
            _client = client;
            _localStorage = localStorage;
        }

        // A protected method that converts API exceptions into a more friendly and interpretable format.
        // It takes an ApiException as a parameter and returns a Response<Guid> object.
        protected Response<Guid> ConvertApiExceptions<Guid>(ApiException ex)
        {
            // Checks if the exception's status code is 400, which usually denotes a bad request.
            // If so, it creates and returns a response indicating that invalid data was submitted.
            if (ex.StatusCode == 400)
            {
                return new Response<Guid>() { Message = "Invalid data was submitted", ValidationErrors = ex.Response, Success = false };
            }
            // Checks if the status code is 404, meaning the requested resource could not be found.
            // If so, it creates and returns a response indicating that the record was not found.
            else if (ex.StatusCode == 404)
            {
                return new Response<Guid>() { Message = "The record was not found.", Success = false };
            }
            // For other status codes, it returns a generic error message indicating something went wrong.
            else
            {
                return new Response<Guid>() { Message = "Something went wrong, please try again later.", Success = false };
            }
        }

        // A protected asynchronous method to add the Bearer token to the HTTP request headers for authentication.
        protected async Task AddBearerToken()
        {
            // Checks if a token exists in the local storage.
            if (await _localStorage.ContainKeyAsync("token"))
            {
                // If a token is found, it is added to the DefaultRequestHeaders of the HttpClient as a Bearer token.
                _client.HttpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", await _localStorage.GetItemAsync<string>("token"));
            }
        }
    }
}
