using DomainManagement.Api.Models;
using DomainManagement.Application.Exceptions;
using Newtonsoft.Json;
using System.Net;

namespace DomainManagement.Api.Middleware
{
    //This ExceptionMiddleware class is a custom middleware in an ASP.NET Core
    //application designed to catch and handle exceptions that occur during the processing of HTTP requests.
    //It provides a centralized location for exception handling, logging,
    //and returning customized error responses to the client.
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        //Used for logging
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            this._logger = logger;
        }

        //This method is invoked for each HTTP request.
        //It attempts to process the request by calling the next middleware in the pipeline.
        //If an exception occurs during this process, it’s caught,
        //and the HandleExceptionAsync method is called to handle the exception.
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        /*This method is responsible for handling exceptions. It creates a CustomValidationDetails object and sets the HTTP status code depending on the type of exception.
        It then logs the error details and writes the error details back to the HTTP response.*/
        private async Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
            CustomValidationDetails problem = new();

            switch (ex)
            {
                case BadRequestException badRequestException:
                    statusCode = HttpStatusCode.BadRequest;
                    problem = new CustomValidationDetails
                    {
                        Title = badRequestException.Message,
                        Status = (int)statusCode,
                        Detail = badRequestException.InnerException?.Message,
                        Type = nameof(BadRequestException),
                        Errors = badRequestException.ValidationErrors
                    };
                    break;
                case NotFoundException NotFound:
                    statusCode = HttpStatusCode.NotFound;
                    problem = new CustomValidationDetails
                    {
                        Title = NotFound.Message,
                        Status = (int)statusCode,
                        Type = nameof(NotFoundException),
                        Detail = NotFound.InnerException?.Message,
                    };
                    break;
                default:
                    problem = new CustomValidationDetails
                    {
                        Title = ex.Message,
                        Status = (int)statusCode,
                        Type = nameof(HttpStatusCode.InternalServerError),
                        Detail = ex.StackTrace,
                    };
                    break;
            }

            httpContext.Response.StatusCode = (int)statusCode;
            var logMessage = JsonConvert.SerializeObject(problem);
            _logger.LogError(logMessage);
            await httpContext.Response.WriteAsJsonAsync(problem);

        }
    }
}

