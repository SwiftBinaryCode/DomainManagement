using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainManagement.Application.Models.Identity
{
    // This class represents the configuration settings needed for generating JWT (JSON Web Tokens).
    // It contains properties that hold the key, issuer, audience, and duration for the tokens.
    public class JwtSettings
    {
        // The 'Key' property is used to hold the secret key for signing the JWT.
        public string Key { get; set; }

        // The 'Issuer' property holds the issuer of the JWT. 
        // It's a claim in the JWT that identifies the principal that issued the JWT.
        public string Issuer { get; set; }

        // The 'Audience' property holds the audience claim, which identifies the recipients that the JWT is intended for.
        public string Audience { get; set; }

        // The 'DurationInMinutes' property indicates how long the JWT token is valid.
        // It's used to set the expiration time for the token.
        public double DurationInMinutes { get; set; }
    }
}
