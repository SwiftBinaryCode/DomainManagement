namespace DomainManagment.BlazorUI.Services.Base
{
    // Defines a generic Response<T> class to standardize the structure of responses returned from various operations or API calls.
    public class Response<T>
    {
        // A property to hold any message associated with the response, 
        // such as error messages or informational messages indicating the result of an operation.
        public string Message { get; set; }

        // A property to hold validation errors, if any, that occurred during an operation.
        // This helps in conveying specific issues with the request/data to the client for correction.
        public string ValidationErrors { get; set; }

        // A boolean property to indicate the success or failure of an operation.
        // True means the operation was successful, and false means it failed.
        public bool Success { get; set; } = true;

        // A generic property to hold the data returned from an operation.
        // Being generic, it can hold any type of data, making this class reusable for various data types.
        public T Data { get; set; }
    }
}
