using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using web_api.ModelViews;

namespace web_api.Security
{
    public interface ITokenSecurity
    {
        TokenSecurityModel JwtSecurityToken(AuthView authView);
    }
}
