using Microsoft.AspNetCore.Mvc;
using web_api.ModelDto;
using web_api.Models;
using web_api.ModelViews;
using web_api.Security;
using web_api.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthenticationController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] AuthDto authDto)
        {
            try
            {
                TokenSecurityModel tokenSecurityModel = _authService.Login(authDto);
                return Ok(tokenSecurityModel);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("sigin")]
        public IActionResult SignIn([FromBody] UsuarioDto usuarioDto)
        {
            try
            {
                Usuario usuario = _authService.SignIn(usuarioDto);
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
