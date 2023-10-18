using DomainManagement.Application.Contracts.Identity;
using DomainManagement.Application.Exceptions;
using DomainManagement.Application.Models.Identity;
using DomainManagement.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DomainManagement.Identity.Services
{
    // This class implements the IAuthService interface to provide functionalities 
    // for user authentication and registration, integrating JWT for token generation and validation.
    public class AuthService : IAuthService
    {
        // Private fields for user management, sign-in management, and JWT settings.
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly JwtSettings _jwtSettings;

        // Constructor to initialize the AuthService with necessary dependencies.
        public AuthService(UserManager<ApplicationUser> userManager,
            IOptions<JwtSettings> jwtSettings,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _jwtSettings = jwtSettings.Value;
            _signInManager = signInManager;
        }

        // Asynchronous method to authenticate a user, validating their credentials, 
        // and generating a JWT token upon successful validation.
        public async Task<AuthResponse> Login(AuthRequest request)
        {
            // Attempt to find the user by their email address.
            var user = await _userManager.FindByEmailAsync(request.Email);

            // If the user is not found, throw a NotFoundException.
            if (user == null)
            {
                throw new NotFoundException($"User with {request.Email} not found.", request.Email);
            }

            // Validate the user's password.
            var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

            // If password validation fails, throw a BadRequestException.
            if (result.Succeeded == false)
            {
                throw new BadRequestException($"Credentials for '{request.Email} aren't valid'.");
            }

            // Generate a JWT token for the authenticated user.
            JwtSecurityToken jwtSecurityToken = await GenerateToken(user);

            // Populate the response object with user and token information.
            var response = new AuthResponse
            {
                Id = user.Id,
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                Email = user.Email,
                UserName = user.UserName
            };

            return response;
        }

        // Asynchronous method to register a new user, validate their information,
        // and assign them to a default role.
        public async Task<RegistrationResponse> Register(RegistrationRequest request)
        {
            // Create a new user entity with provided registration details.
            var user = new ApplicationUser
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
                EmailConfirmed = true
            };

            // Attempt to create the user in the identity system.
            var result = await _userManager.CreateAsync(user, request.Password);

            // If user creation is successful, assign the user to the 'Customer' role and return a response.
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Customer");
                return new RegistrationResponse() { UserId = user.Id };
            }
            else
            {
                // If user creation fails, compile error messages and throw a BadRequestException.
                StringBuilder str = new StringBuilder();
                foreach (var err in result.Errors)
                {
                    str.AppendFormat("•{0}\n", err.Description);
                }

                throw new BadRequestException($"{str}");
            }
        }

        // Private method to generate a JWT token with user claims and roles.
        private async Task<JwtSecurityToken> GenerateToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            var roleClaims = roles.Select(q => new Claim(ClaimTypes.Role, q)).ToList();

            // Combine user claims, JWT registered claims, and role claims to form the complete set of claims.
            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim("uid", user.Id)
        }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));

            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            // Create and return a JWT security token with the specified claims, expiry duration, and signing credentials.
            var jwtSecurityToken = new JwtSecurityToken(
               issuer: _jwtSettings.Issuer,
               audience: _jwtSettings.Audience,
               claims: claims,
               expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
               signingCredentials: signingCredentials);
            return jwtSecurityToken;
        }
    }
}
