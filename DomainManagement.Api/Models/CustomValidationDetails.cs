using Microsoft.AspNetCore.Mvc;

namespace DomainManagement.Api.Models
{
    public class CustomValidationDetails : ProblemDetails
    {
        public IDictionary<string, string[]> Errors { get; set; } = new Dictionary<string, string[]>();
    }
}
