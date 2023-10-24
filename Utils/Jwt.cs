using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using MyProject.Exceptions;

namespace MyProject.Utils
{
    public class Jwt
    {
        public readonly string Token;
        public readonly IEnumerable<Claim> Claims;

        public Jwt(string token)
        {
            if (token.IsNullOrEmpty())
            {
                throw new JWTTokenNotProvidedException();
            }

            Token = token;

            try
            {
                Claims = new JwtSecurityTokenHandler().ReadJwtToken(token).Claims;
            }
            catch (Exception)
            {
                throw new UnauthorizedException("Invalid token");
            }
        }

        public static Jwt GetFromRequest(HttpRequest request)
        {
            var token = request.Headers["Authorization"].ToString().Replace("Bearer ", "");

            return new Jwt(token);
        }

        public string? GetClaim(string key)
        {
            return Claims.FirstOrDefault(c => c.Type == key)?.Value;
        }

        public Guid Jti()
        {
            return Guid.Parse(GetClaim("jti")!);
        }

        public Guid Subject()
        {
            return Guid.Parse(GetClaim("sub")!);
        }

        public string? Role()
        {
            return GetClaim("role");
        }
    }
}
