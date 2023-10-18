using DomainManagement.Application.Contracts.Identity;
using DomainManagement.Application.Models.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DomainManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    /// <summary>
    /// Handles user authentication operations including login and registration.
    /// </summary>
    public class AuthController : ControllerBase
    {
        /// <summary>
        /// The service responsible for executing authentication operations.
        /// </summary>
        private readonly IAuthService _authenticationService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthController"/> class.
        /// </summary>
        /// <param name="authenticationService">The service for authentication operations.</param>
        public AuthController(IAuthService authenticationService)
        {
            this._authenticationService = authenticationService;
        }

        /// <summary>
        /// Logs a user in by validating their credentials and generating a token if valid.
        /// </summary>
        /// <param name="request">The login request containing user credentials.</param>
        /// <returns>An ActionResult containing the authentication response with a token and other details.</returns>
        [HttpPost("login")]
        public async Task<ActionResult<AuthResponse>> Login(AuthRequest request)
        {
            return Ok(await _authenticationService.Login(request));
        }

        /// <summary>
        /// Registers a new user with the provided details.
        /// </summary>
        /// <param name="request">The registration request containing user details.</param>
        /// <returns>An ActionResult containing the registration response with success status and potential errors.</returns>
        [HttpPost("register")]
        public async Task<ActionResult<RegistrationResponse>> Register(RegistrationRequest request)
        {
            return Ok(await _authenticationService.Register(request));
        }
    }
}
