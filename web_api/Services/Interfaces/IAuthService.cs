using web_api.ModelDto;
using web_api.Models;
using web_api.ModelViews;
using web_api.Security;

namespace web_api.Services.Interfaces
{
    public interface IAuthService
    {
        TokenSecurityModel Login(AuthDto authDto);
        Usuario SignIn(UsuarioDto usuarioDto);
    }
}
