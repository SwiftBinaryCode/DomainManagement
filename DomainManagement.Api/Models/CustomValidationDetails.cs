using Microsoft.AspNetCore.Mvc;

namespace DomainManagement.Api.Models
{
    /// <summary>
    /// Represents a custom validation details class that extends the problem details 
    /// to include detailed validation error information.
    /// </summary>
    public class CustomValidationDetails : ProblemDetails
    {
        /// <summary>
        /// Gets or sets a dictionary containing the validation errors.
        /// The dictionary keys represent the names of the fields that have errors,
        /// and the associated values are string arrays containing the error messages for each field.
        /// </summary>
        public IDictionary<string, string[]> Errors { get; set; } = new Dictionary<string, string[]>();
    }
}
