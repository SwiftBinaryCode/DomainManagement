namespace DomainManagment.BlazorUI.Services.Base
{
    // Defines the IClient interface, a contract that classes implementing it should adhere to.
    // This interface is used for classes that manage HTTP client instances for making HTTP requests.
    public partial interface IClient
    {
        // Gets the instance of HttpClient that is used to make HTTP requests.
        // HttpClient is a class provided by .NET to send HTTP requests and receive HTTP responses
        // from a URI identified resource (like APIs).
        public HttpClient HttpClient { get; }
    }
}
