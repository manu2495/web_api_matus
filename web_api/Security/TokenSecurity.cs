using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using web_api.ModelViews;

namespace web_api.Security
{
    public class TokenSecurity : ITokenSecurity
    {
        private readonly IConfiguration _configuration;

        private DateTime expiration;
        private SigningCredentials creds;
        private SymmetricSecurityKey key;

        public TokenSecurity(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public TokenSecurityModel JwtSecurityToken(AuthView authView)
        {
            string roles = GetToken(authView.Groups);
            string permisos = GetToken(authView.Permissions);

            var claims = new[]
            {
                new Claim("app", "WEB API"),
                new Claim("roles", roles),
                new Claim("permisos", permisos),
                new Claim("username", authView.Username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            JwtSecurityToken token = GetTokenCredentials(claims);

            TokenSecurityModel tokenSecurityModel = new TokenSecurityModel
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };

            return tokenSecurityModel;
        }

        protected string GetToken(Object obj)
        {
            JwtSecurityToken token = GetTokenCredentials();

            token.Payload["payload"] = obj;
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        protected JwtSecurityToken GetTokenCredentials(Claim[] claims = null)
        {
            key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Secret_Key"]));
            creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            expiration = GetExpirationDate();

            if (claims != null)
            {
                return new JwtSecurityToken
                (
                    issuer: _configuration["issuer"],
                    audience: _configuration["audience"],
                    claims: claims,
                    expires: expiration,
                    signingCredentials: creds
                );
            }
            else
            {
                return new JwtSecurityToken
                (
                    expires: expiration,
                    signingCredentials: creds
                );
            }
        }

        protected DateTime GetExpirationDate()
        {
            return DateTime.UtcNow.AddHours(10);
        }
    }
}
